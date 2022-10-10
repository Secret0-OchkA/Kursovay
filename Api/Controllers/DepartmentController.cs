using Context;
using Context.Queryable;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DockerTestBD.Api.Controllers
{
    [Route(ApiRoute.baseRoute +
        ApiRoute.Company +
        ApiRoute.FromCompany +
        ApiRoute.controller)]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        readonly ApplicationDbContext dbContext;
        readonly DbSet<Department> departments;

        public DepartmentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            departments = dbContext.departments;
        }

        [HttpPost]
        public IActionResult CreateDepartment(int companyId, Department department)
        {
            department.CompanyId = companyId;

            departments.Add(department);
            dbContext.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteDepartment(int companyId, int departmentId)
        {
            Department? department = departments
                .ByCompany(companyId)
                .GetObj(departmentId);
            if (department == null) return BadRequest();

            departments.Remove(department);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetDepartment(int companyId)
            => Ok(departments.ByCompany(companyId));

        [HttpGet("{departmentId}")]
        public IActionResult GetDepartment(int companyId, int departmentId)
        {
            Department? department = departments
                .ByCompany(companyId)
                .GetObj(departmentId);
            if (department == null) return BadRequest(new Department());

            return Ok(department);
        }
        [HttpPut("{departmentId}")]
        public IActionResult SetBuget(int departmentId, decimal buget)
        {
            Department? department = departments.GetObj(departmentId);
            if (department == null) return BadRequest(new Department());

            department.budget = buget;
            departments.Update(department);
            dbContext.SaveChanges();
            return Ok(department);
        }
    }
}
