using Context;
using Context.Queryable;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public IActionResult Get(int employeeId)
            => Ok(expenses.ByEmployee(employeeId).ToList());
        [HttpGet("{expenseId}")]
        public IActionResult Get(int employeeId, int expenseId)
        {
            Expense? expense = expenses.ByEmployee(employeeId).GetObj(expenseId);
            if (expense == null) return BadRequest(new Expense());

            return Ok(expense);
        }

        [HttpPut("{expenseId}/Confirm")]
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
        public IActionResult ChangeAmmount(int employeeId, int expenseId, decimal amount)
        {
            Expense? expense = expenses.ByEmployee(employeeId).GetObj(expenseId);
            if (expense == null || expense.Confirm == true) return BadRequest(new Exception());

            expense.Valid = false;
            expense.amount = amount;
            expense.date = DateTime.Now;

            expenses.Update(expense);
            dbContext.SaveChanges();
            return Ok(expense);
        }
        [HttpPut("{expenseId}/SetType/{expenseTypeId}")]
        public IActionResult SetExpenseType(int employeeId, int expenseId, int expenseTypeId)
        {
            Expense? expense = expenses.ByEmployee(employeeId).GetObj(expenseId);
            if (expense == null || expense.Confirm == true) return BadRequest(new Expense());

            ExpenseType? expenseType = dbContext.expenseTypes.ByCompany(employeeId).GetObj(expenseTypeId);
            if (expenseType == null) return BadRequest(new Expense());

            expense.Valid = false;
            expense.expenseType = expenseType;
            expense.date = DateTime.Now;

            expenses.Update(expense);
            dbContext.SaveChanges();

            return Ok(expense);
        }
    }
}
