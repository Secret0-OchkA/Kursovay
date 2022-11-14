using Context;
using Context.Queryable;
using Domain.ApiModel;
using Domain.ApiModels;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DockerTestBD.Api.Controllers
{
    [Route(ApiRoute.baseRoute +
        ApiRoute.Company + ApiRoute.FromCompany +
        ApiRoute.controller)]
    [ApiController]
    [Produces("application/json")]
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
        /// get expenses in company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<ExpenseView>), 200)]
        [HttpGet(Name = "GetExpesesInCompany")]
        public IActionResult Get(int companyId)
            => Ok(expenses.ByCompany(companyId).ToList().ConvertAll(new Converter<Expense, ExpenseView>(Expense.ToView)));
        /// <summary>
        /// get expenses in department
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmnetId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<ExpenseView>),200)]
        [HttpGet("department/{departmnetId}", Name = "GetExpesesInDepartment")]
        public IActionResult Get(int companyId, int departmnetId)
            => Ok(expenses.ByCompany(companyId).ByDepartment(departmnetId).ToList().ConvertAll(new Converter<Expense, ExpenseView>(Expense.ToView)));
        /// <summary>
        /// get expense in department by id
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmnetId"></param>
        /// <param name="expenseId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ExpenseView),200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpGet("department/{departmnetId}/{expenseId}", Name = "GetExpenseInDeparment")]
        public IActionResult Get(int companyId, int departmnetId, int expenseId)
        {
            Expense? expense = expenses.ByCompany(companyId).ByDepartment(departmnetId).GetObj(expenseId);
            if (expense == null) return BadRequest("not exist expense");

            return Ok(Expense.ToView(expense));
        }
    }
}
