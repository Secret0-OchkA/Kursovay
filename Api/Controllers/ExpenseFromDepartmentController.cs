using Context;
using Context.Queryable;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DockerTestBD.Api.Controllers
{
    [Route(ApiRoute.baseRoute +
        ApiRoute.Company + ApiRoute.FromCompany +
        ApiRoute.Deparment + ApiRoute.FromDepartment +
        ApiRoute.controller)]
    [ApiController]
    [Produces("application/json")]
    [Authorize(Roles = "owner,accountant")]
    public class ExpenseFromDepartmentController : ControllerBase
    {
        readonly ApplicationDbContext dbContext;
        readonly DbSet<Expense> expenses;
        public ExpenseFromDepartmentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            expenses = dbContext.expenses;
        }
        /// <summary>
        /// get expenses in department
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmnetId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<Expense>),200)]
        [HttpGet(Name = "GetExpesesInDepartment")]
        public IActionResult Get(int companyId, int departmnetId)
            => Ok(expenses.ByCompany(companyId).ByDepartment(departmnetId).ToList());
        /// <summary>
        /// get expense in department by id
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmnetId"></param>
        /// <param name="expenseId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Expense),200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpGet("{expenseId}", Name = "GetExpenseInDeparment")]
        public IActionResult Get(int companyId, int departmnetId, int expenseId)
        {
            Expense? expense = expenses.ByCompany(companyId).ByDepartment(departmnetId).GetObj(expenseId);
            if (expense == null) return BadRequest("not exist expense");

            return Ok(expense);
        }
    }
}
