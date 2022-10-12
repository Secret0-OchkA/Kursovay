using Context;
using Context.Queryable;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace DockerTestBD.Api.Controllers
{
    [Route(ApiRoute.baseRoute +
        ApiRoute.Employee + ApiRoute.FromEmployee +
        ApiRoute.controller)]
    [ApiController]
    public class ExpenseFromEmployeeController : ControllerBase
    {
        readonly ApplicationDbContext dbContext;
        readonly DbSet<Expense> expenses;
        public ExpenseFromEmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            expenses = dbContext.expenses;
        }

        [HttpPost]
        [Authorize(Roles = "user")]
        public IActionResult CreateExpense(int employeeId, Expense value)
        {
            Employee? employee = dbContext.employees.GetObj(employeeId);
            if (employee == null || employee.Department == null) return BadRequest();
            if (value.amount < 0 || value.amount > value.expenseType.Limit) return BadRequest();

            Expense expense = new Expense
            {
                expenseType = value.expenseType,
                amount = value.amount,
                department = employee.Department,
                date = DateTime.UtcNow,
            };
            expenses.Add(expense);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get(int employeeId)
            => Ok(expenses.ByEmployee(employeeId).ToList());
        [HttpGet("{expenseId}")]
        [Authorize]
        public IActionResult Get(int employeeId, int expenseId)
        {
            Expense? expense = expenses.ByEmployee(employeeId).GetObj(expenseId);
            if (expense == null) return BadRequest(new Expense());

            return Ok(expense);
        }

        [HttpPut("{expenseId}/Confirm")]
        [Authorize(Roles = "accountant")]
        public IActionResult Confirm(int employeeId, int expenseId)
        {
            Expense? expense = expenses.ByEmployee(employeeId).GetObj(expenseId);

            if (expense == null || expense.Valid == false) return BadRequest(new Expense());

            expense.Confirm = true;

            expenses.Update(expense);
            dbContext.SaveChanges();

            return Ok(expense);
        }
        [HttpPut("{expenseId}/Validate")]
        [Authorize(Roles = "accountant")]
        public IActionResult Validate(int employeeId, int expenseId)
        {
            Expense? expense = expenses.ByEmployee(employeeId).GetObj(expenseId);
            if (expense == null) return BadRequest(new Exception());

            expense.Valid = true;

            expenses.Update(expense);
            dbContext.SaveChanges();
            return Ok(expense);
        }
        [HttpPut("{expenseId}/ChangeAmmount")]
        [Authorize(Roles = "user")]
        public IActionResult ChangeAmmount(int employeeId, int expenseId, decimal amount)
        {
            Expense? expense = expenses.ByEmployee(employeeId).GetObj(expenseId);
            if (expense == null || expense.Confirm == true) return BadRequest(new Expense());
            if (amount < 0 || amount > expense.expenseType.Limit) return BadRequest(new Expense());

            expense.Valid = false;
            expense.amount = amount;
            expense.date = DateTime.UtcNow;

            expenses.Update(expense);
            dbContext.SaveChanges();
            return Ok(expense);
        }
        [HttpPut("{expenseId}/SetType/{expenseTypeId}")]
        [Authorize(Roles = "user")]
        public IActionResult SetExpenseType(int employeeId, int expenseId, int expenseTypeId)
        {
            Expense? expense = expenses.ByEmployee(employeeId).GetObj(expenseId);
            if (expense == null || expense.Confirm == true) return BadRequest(new Expense());

            ExpenseType? expenseType = dbContext.expenseTypes.ByCompany(employeeId).GetObj(expenseTypeId);
            if (expenseType == null || expense.amount > expenseType.Limit) return BadRequest(new Expense());

            expense.Valid = false;
            expense.expenseType = expenseType;
            expense.date = DateTime.UtcNow;

            expenses.Update(expense);
            dbContext.SaveChanges();

            return Ok(expense);
        }
    }
}
