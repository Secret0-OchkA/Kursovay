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
    [Produces("application/json")]
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
        /// <summary>
        /// create expense for employee
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpPost(Name = "CreateExpense")]
        [Authorize(Roles = "user")]
        public IActionResult Create(int employeeId, Expense value)
        {
            Employee? employee = dbContext.employees.GetObj(employeeId);
            if (employee == null) return BadRequest("not exist employee");
            if (employee.Department == null) return BadRequest("employee not work in department");
            if (value.amount < 0 || value.amount > value.expenseType.Limit) return BadRequest("amout < 0 || amout > limit");

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
        /// <summary>
        /// get expenses in emploee
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<Expense>),200)]
        [HttpGet(Name = "GetExpenses")]
        [Authorize]
        public IActionResult Get(int employeeId)
            => Ok(expenses.ByEmployee(employeeId).ToList());
        /// <summary>
        /// get expense in employee
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="expenseId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Expense),200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpGet("{expenseId}",Name ="GetExpense")]
        [Authorize]
        public IActionResult Get(int employeeId, int expenseId)
        {
            Expense? expense = expenses.ByEmployee(employeeId).GetObj(expenseId);
            if (expense == null) return BadRequest("not exist expense");

            return Ok(expense);
        }
        /// <summary>
        /// confirm expense if expense is valid
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="expenseId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Expense),200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpPut("{expenseId}/Confirm",Name = "ConfirmExpense")]
        [Authorize(Roles = "accountant")]
        public IActionResult Confirm(int employeeId, int expenseId)
        {
            Expense? expense = expenses.ByEmployee(employeeId).GetObj(expenseId);

            if (expense == null) return BadRequest("not exist expense");
            if (expense.Valid == false) return BadRequest("expense not valid");

            expense.Confirm = true;

            expenses.Update(expense);
            dbContext.SaveChanges();

            return Ok(expense);
        }
        /// <summary>
        /// validate expense
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="expenseId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Expense),200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpPut("{expenseId}/Validate",Name = "ValidateEpxense")]
        [Authorize(Roles = "accountant")]
        public IActionResult Validate(int employeeId, int expenseId)
        {
            Expense? expense = expenses.ByEmployee(employeeId).GetObj(expenseId);
            if (expense == null) return BadRequest("not exist expense");

            expense.Valid = true;

            expenses.Update(expense);
            dbContext.SaveChanges();
            return Ok(expense);
        }
        /// <summary>
        /// Change ammout if not confirmed
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="expenseId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Expense),200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpPut("{expenseId}/ChangeAmmount",Name = "ChangeAmmount")]
        [Authorize(Roles = "user")]
        public IActionResult ChangeAmmount(int employeeId, int expenseId, decimal amount)
        {
            Expense? expense = expenses.ByEmployee(employeeId).GetObj(expenseId);
            if (expense == null) return BadRequest("not exist expense");
            if (expense.Confirm == true) return BadRequest("expense confirmed");
            if (amount < 0 || amount > expense.expenseType.Limit) return BadRequest("amout < 0 || amout > limit");

            expense.Valid = false;
            expense.amount = amount;
            expense.date = DateTime.UtcNow;

            expenses.Update(expense);
            dbContext.SaveChanges();
            return Ok(expense);
        }
        /// <summary>
        /// change type if not confirmed
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="expenseId"></param>
        /// <param name="expenseTypeId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Expense),200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpPut("{expenseId}/SetType/{expenseTypeId}",Name = "SetExpenseType")]
        [Authorize(Roles = "user")]
        public IActionResult SetExpenseType(int employeeId, int expenseId, int expenseTypeId)
        {
            Expense? expense = expenses.ByEmployee(employeeId).GetObj(expenseId);
            if (expense == null) return BadRequest("expense not exist");
            if (expense.Confirm == true) return BadRequest("expense confirmed");

            ExpenseType? expenseType = dbContext.expenseTypes.ByCompany(employeeId).GetObj(expenseTypeId);
            if (expenseType == null) return BadRequest("expenseType not exist");
            if (expense.amount > expenseType.Limit) return BadRequest("amout < 0 || amout > limit");

            expense.Valid = false;
            expense.expenseType = expenseType;
            expense.date = DateTime.UtcNow;

            expenses.Update(expense);
            dbContext.SaveChanges();

            return Ok(expense);
        }
    }
}
