using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DockerTestBD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public void GetEmployee() => throw new NotImplementedException();

        public void ChangeName() => throw new NotImplementedException();

        public void GetExpenses() => throw new NotImplementedException();
        public void CreateExpense() => throw new NotImplementedException();
        public void DeleteExpense() => throw new NotImplementedException();
    }
}
