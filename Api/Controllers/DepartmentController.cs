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
        /// <summary>
        /// create department in company
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="department"></param>
        /// <response code="200"></response>
        /// <returns></returns>
        [HttpPost(Name = "CreateDepartment")]
        [Authorize(Roles = "owner")]
        public IActionResult Create(int companyId, Department department)
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
        /// <summary>
        /// Delete department in company
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmentId"></param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <returns></returns>
        [HttpDelete(Name = "DeleteDepartment")]
        [Authorize(Roles = "owner")]
        public IActionResult Delete(int companyId, int departmentId)
        {
            Department? department = departments
                .ByCompany(companyId)
                .GetObj(departmentId);
            if (department == null) return BadRequest("not exist department in company");

            departments.Remove(department);
            dbContext.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// get departments in company
        /// </summary>
        /// <param name="companyId"></param>
        /// <response code="200"></response>
        /// <returns></returns>
        [HttpGet(Name = "GetDepartments")]
        [Authorize(Roles = "owner,accountant")]
        public IActionResult Get(int companyId)
            => Ok(departments.ByCompany(companyId));
        /// <summary>
        /// get department by id in company
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmentId"></param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <returns></returns>
        [HttpGet("{departmentId}", Name = "GetDepartment")]
        [Authorize(Roles = "owner,accountant")]
        public IActionResult Get(int companyId, int departmentId)
        {
            Department? department = departments
                .ByCompany(companyId)
                .GetObj(departmentId);
            if (department == null) return BadRequest("not exist department in company");

            return Ok(department);
        }
        /// <summary>
        /// set buget department by id in company
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="buget"></param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <returns></returns>
        [HttpPut("{departmentId}", Name = "SetBugetDeparmtnet")]
        [Authorize(Roles = "owner")]
        public IActionResult SetBuget(int departmentId, decimal buget)
        {
            Department? department = departments.GetObj(departmentId);
            if (department == null) return BadRequest("Not exist department in company");
            if (buget < 0) return BadRequest("incorect new buget");

            department.budget = buget;
            departments.Update(department);
            dbContext.SaveChanges();
            return Ok(department);
        }
    }
}
