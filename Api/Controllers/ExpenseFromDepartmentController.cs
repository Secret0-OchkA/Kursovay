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

        [HttpGet]
        public IActionResult Get(int companyId, int departmentId)
            => Ok(expenses.ByCompany(companyId).ByDepartment(departmentId).ToList());
        [HttpGet("{expenseId}")]
        public IActionResult Get(int companyId, int departmentId, int expenseId)
        {
            Expense? expense = expenses.ByCompany(companyId).ByDepartment(departmentId).GetObj(expenseId);
            if (expense == null) return BadRequest(new Expense());

            return Ok(expense);
        }
    }
}
