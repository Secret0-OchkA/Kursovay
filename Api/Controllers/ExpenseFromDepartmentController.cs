using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DockerTestBD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseFromDepartmentController : ControllerBase
    {
        public void Get(int departmentId) => throw new NotImplementedException();
        public void Get(int departmentId, int expenseId) => throw new NotImplementedException();
    }
}
