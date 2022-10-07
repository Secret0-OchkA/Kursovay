using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DockerTestBD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        public void GetExpenses() => throw new NotImplementedException();
        public void GetExpense() => throw new NotImplementedException();

        public void Confirm() => throw new NotImplementedException();
        public void Validate() => throw new NotImplementedException();
        public void ChangeAmmount() => throw new NotImplementedException();

        public void SetExpenseType() => throw new NotImplementedException();
    }
}
