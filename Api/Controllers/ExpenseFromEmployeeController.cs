using Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace DockerTestBD.Api.Controllers
{
    [Route(ApiRoute.baseRoute + 
        ApiRoute.Employee + ApiRoute.FromEmployee +
        ApiRoute.controller)]
    [ApiController]
    public class ExpenseFromEmployeeController : ControllerBase
    {
        readonly IService<Expense> service;
        public ExpenseFromEmployeeController(IService<Expense> service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get(int employeeId)
        {
            List<Expense> expenses = service.GetAll()
                .Where(ex => ex.EmploeeId == employeeId)
                .ToList();
            return Ok(expenses);
        }
        [HttpGet("{expenseId}")]
        public IActionResult Get(int employeeId, int expenseId)
        {
            Expense? expense = service.Get(employeeId);
            if (expense == null) return BadRequest(new Expense());
            if (expense.EmploeeId != employeeId) return BadRequest(new Expense());

            return Ok(expense);
        }
    }
}
