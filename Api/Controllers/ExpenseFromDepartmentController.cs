using Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace DockerTestBD.Api.Controllers
{
    [Route(ApiRoute.baseRoute +
        ApiRoute.Company + ApiRoute.FromCompany +
        ApiRoute.Deparment + ApiRoute.FromDepartment +
        ApiRoute.controller)]
    [ApiController()]
    public class ExpenseFromDepartmentController : ControllerBase
    {
        readonly IService<Expense> service;
        public ExpenseFromDepartmentController(IService<Expense> service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get(int departmentId)
        {
            List<Expense> expenses = service.GetAll()
                .Where(ex => ex.DepartmentId == departmentId)
                .ToList();
            return Ok(expenses);
        }
        [HttpGet("{expenseId}")]
        public IActionResult Get(int departmentId, int expenseId)
        {
            Expense? expense = service.Get(expenseId);
            if (expense == null) return BadRequest(new Expense());
            if (expense.DepartmentId != departmentId) return BadRequest(new Expense());

            return Ok(expense);
        }
    }
}
