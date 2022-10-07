using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DockerTestBD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        public void CreateCompany() => throw new NotImplementedException();
        public void GetCompany() => throw new NotImplementedException();
        public void DeletCompnay() => throw new NotImplementedException();

        public void ChangeName()=> throw new NotImplementedException();
        
        public void GetDepartments() => throw new NotImplementedException();
        public void AddDepartment() => throw new NotImplementedException();
        public void DeleteDepartment() => throw new NotImplementedException();
    }
}
