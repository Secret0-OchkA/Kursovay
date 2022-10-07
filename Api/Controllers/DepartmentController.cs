using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace DockerTestBD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public void GetDepartment() => throw new NotImplementedException();

        public void SetBuget() => throw new NotImplementedException();

        public void GetBugetPlan() => throw new NotImplementedException();
        public void CreateBugetPlan() => throw new NotImplementedException();
        public void DeleteBugetPlan() => throw new NotImplementedException();

        public void GetEmployees() => throw new NotImplementedException();
        public void AddEmployee()=> throw new NotImplementedException();
        public void RemoveEmployee() => throw new NotImplementedException();

        public void GetExpenses() => throw new NotImplementedException();
    }
}
