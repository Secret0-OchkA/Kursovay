using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace DockerTestBD.Api.Controllers
{
    [Route(ApiRoute.baseRoute +
        ApiRoute.Company +
        ApiRoute.FromCompany +
        ApiRoute.controller)]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        readonly IService<Department> departmentService;

        public DepartmentController(IService<Department> departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpPost]
        public IActionResult CreateDepartment(int companyId, Department department)
        {
            department.CompanyId = companyId;
            departmentService.Create(department);

            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteDepartment(int companyId, int departmentId)
        {
            Department? department = departmentService.GetAll()
               .Where(d => d.Id == departmentId && d.CompanyId == companyId)
               .SingleOrDefault();
            if (department == null) return BadRequest();

            return Ok();
        }

        [HttpGet]
        public IActionResult GetDepartment(int companyId)
            => Ok(departmentService.GetAll().Where(d => d.CompanyId == companyId));
        [HttpGet("{departmentId}")]
        public IActionResult GetDepartment(int companyId, int departmentId)
        {
            Department? department = departmentService.Get(departmentId);
            if (department == null || department.CompanyId != companyId) return BadRequest(new Department());

            return Ok(department);
        }
        [HttpPut("{departmentId}")]
        public IActionResult SetBuget(int departmentId, decimal buget)
        {
            Department? department = departmentService.Get(departmentId);
            if (department == null) return BadRequest(new Department());

            department.budget = buget;
            departmentService.Update(department);

            return Ok(department);
        }
    }
}
