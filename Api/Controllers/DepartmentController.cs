using Context;
using Context.Queryable;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "owner")]
        public IActionResult CreateDepartment(int companyId, Department department)
        {
            Department newDepartment = new Department
            {
                CompanyId = companyId,
                Name = department.Name,
                budget = department.budget,
            };

            departments.Add(newDepartment);
            dbContext.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        [Authorize(Roles = "owner")]
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
        [Authorize(Roles = "owner,accountant")]
        public IActionResult GetDepartment(int companyId)
            => Ok(departments.ByCompany(companyId));

        [HttpGet("{departmentId}")]
        [Authorize(Roles = "owner,accountant")]
        public IActionResult GetDepartment(int companyId, int departmentId)
        {
            Department? department = departments
                .ByCompany(companyId)
                .GetObj(departmentId);
            if (department == null) return BadRequest(new Department());

            return Ok(department);
        }
        [HttpPut("{departmentId}")]
        [Authorize(Roles = "owner")]
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
