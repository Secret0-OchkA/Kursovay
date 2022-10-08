using Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace DockerTestBD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        readonly IService<Expense> service;
        public ExpenseController(IService<Expense> service)
        {
            this.service = service;
        }




        public void Confirm() => throw new NotImplementedException();
        public void Validate() => throw new NotImplementedException();
        public void ChangeAmmount() => throw new NotImplementedException();
        public void SetExpenseType() => throw new NotImplementedException();
    }
}
