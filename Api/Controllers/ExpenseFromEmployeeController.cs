using Context;
using Context.Queryable;
using Domain.ApiModel;
using Domain.ApiModels;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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
        public IActionResult Create(int employeeId, ExpenseView value)
        {
            Employee? employee = dbContext.employees.GetObj(employeeId);
            if (employee == null) return BadRequest("not exist employee");
            if (employee.Department == null) return BadRequest("employee not work in department");
            if (employee.Department.budget < value.amount) return BadRequest("few department budget");
            ExpenseType? expenseType = dbContext.expenseTypes.GetObj(value.expenseTypeId);
            if (expenseType == null) return BadRequest("not exist expenseType");
            if (value.amount < 0 || value.amount > expenseType.Limit) return BadRequest("amout < 0 || amout > limit");

            employee.Department.budget -= value.amount;

            Expense expense = new Expense
            {
                expenseType = expenseType,
                employee = employee,
                EmploeeId = employee.Id,
                amount = value.amount,
                department = employee.Department,
                date = DateTime.UtcNow,
            };
            expenses.Add(expense);
            dbContext.departments.Update(employee.Department);
            dbContext.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// get expenses in emploee
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<ExpenseView>),200)]
        [HttpGet(Name = "GetExpenses")]
        public IActionResult Get(int employeeId)
            => Ok(expenses.ByEmployee(employeeId).ToList().ConvertAll(new Converter<Expense, ExpenseView>(Expense.ToView)));
        /// <summary>
        /// get expense in employee
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="expenseId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ExpenseView),200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpGet("{expenseId}",Name ="GetExpense")]
        public IActionResult Get(int employeeId, int expenseId)
        {
            Expense? expense = expenses.ByEmployee(employeeId).GetObj(expenseId);
            if (expense == null) return BadRequest("not exist expense");

            return Ok(Expense.ToView(expense));
        }
        /// <summary>
        /// confirm expense if expense is valid
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="expenseId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ExpenseView),200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpPut("{expenseId}/Confirm",Name = "ConfirmExpense")]
        public IActionResult Confirm(int employeeId, int expenseId)
        {
            Expense? expense = expenses.ByEmployee(employeeId).GetObj(expenseId);

            if (expense == null) return BadRequest("not exist expense");
            if (expense.Valid == false) return BadRequest("expense not valid");
            if (expense.department.budget < expense.amount) return BadRequest("few department budget");

            expense.Confirm = true;

            dbContext.departments.Update(expense.department);
            expenses.Update(expense);
            dbContext.SaveChanges();

            return Ok(Expense.ToView(expense));
        }
        /// <summary>
        /// validate expense
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="expenseId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ExpenseView),200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpPut("{expenseId}/Validate",Name = "ValidateEpxense")]
        public IActionResult Validate(int employeeId, int expenseId)
        {
            Expense? expense = expenses.ByEmployee(employeeId).GetObj(expenseId);
            if (expense == null) return BadRequest("not exist expense");

            expense.Valid = true;

            expenses.Update(expense);
            dbContext.SaveChanges();
            return Ok(Expense.ToView(expense));
        }
        /// <summary>
        /// Change ammout if not confirmed
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="expenseId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ExpenseView),200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpPut("{expenseId}/ChangeAmmount",Name = "ChangeAmmount")]
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
            return Ok(Expense.ToView(expense));
        }
        /// <summary>
        /// change type if not confirmed
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="expenseId"></param>
        /// <param name="expenseTypeId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ExpenseView),200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpPut("{expenseId}/SetType/{expenseTypeId}",Name = "SetExpenseType")]
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

            return Ok(Expense.ToView(expense));
        }
        /// <summary>
        /// Delete expense
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpDelete("{id}", Name = "DeleteExpense")]
        public IActionResult Delete(int id)
        {
            Expense? expense = expenses.GetObj(id);
            if (expense == null) return BadRequest("not exist employee");

            expenses.Remove(expense);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
