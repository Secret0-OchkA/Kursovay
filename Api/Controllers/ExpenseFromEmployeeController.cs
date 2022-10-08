using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DockerTestBD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseFromEmployeeController : ControllerBase
    {
        public void Get(int employeeId) => throw new NotImplementedException();
        public void Get(int employeeId, int expenseId) => throw new NotImplementedException();
    }
}
