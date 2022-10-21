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
        /// <param name="departmentId"></param>
        /// <response code="200"></response>
        /// <returns></returns>
        [HttpGet(Name = "GetExpesesInDepartment")]
        public IActionResult Get(int companyId, int departmentId)
            => Ok(expenses.ByCompany(companyId).ByDepartment(departmentId).ToList());
        /// <summary>
        /// get expense in department by id
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmentId"></param>
        /// <param name="expenseId"></param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <returns></returns>
        [HttpGet("{expenseId}", Name = "GetExpenseInDeparment")]
        public IActionResult Get(int companyId, int departmentId, int expenseId)
        {
            Expense? expense = expenses.ByCompany(companyId).ByDepartment(departmentId).GetObj(expenseId);
            if (expense == null) return BadRequest("not exist expense");

            return Ok(expense);
        }
    }
}
