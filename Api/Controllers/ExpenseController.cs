using Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace DockerTestBD.Api.Controllers
{
    [Route(ApiRoute.baseRoute +
        ApiRoute.controller)]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        readonly IService<Expense> service;
        public ExpenseController(IService<Expense> service)
        {
            this.service = service;
        }

        [HttpPut("{expenseId}/Confirm")]
        public IActionResult Confirm(int expenseId)
        {
            Expense? expense = service.Get(expenseId);
            if (expense == null || expense.Valid == false) return BadRequest(new Expense());

            expense.Confirm = true;
            service.Update(expense);
            return Ok(expense);
        }
        [HttpPut("{expenseId}/Validate")]
        public IActionResult Validate(int expenseId)
        {
            Expense? expense = service.Get(expenseId);
            if (expense == null) return BadRequest(new Exception());

            expense.Valid = true;
            service.Update(expense);
            return Ok(expense);
        }
        [HttpPut("{expenseId}/ChangeAmmount")]
        public IActionResult ChangeAmmount(int expenseId, decimal amount)
        {
            Expense? expense = service.Get(expenseId);
            if (expense == null || expense.Confirm == true) return BadRequest(new Exception());

            expense.Valid = false;
            expense.amount = amount;
            expense.date = DateTime.Now;

            service.Update(expense);
            return Ok(expense);
        }
        [HttpPut("{expenseId}/SetType")]
        public IActionResult SetExpenseType(int expenseId, int expenseTypeId)
        {
            Expense? expense = service.Get(expenseId);
            if (expense == null || expense.Confirm == true) return BadRequest(new Exception());

            expense.Valid = false;
            expense.ExpenseTypeId = expenseTypeId;
            expense.date = DateTime.Now;

            service.Update(expense);
            return Ok(expense);
        }
    }
}
