using Context;
using Context.Queryable;
using Domain.ApiModel;
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
    [Produces("application/json")]
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
        /// <returns></returns>
        [ProducesResponseType(200)]
        [HttpPost(Name = "CreateDepartment")]
        public IActionResult Create(int companyId, DepartmentView department)
        {
            Department newDepartment = new Department
            {
                CompanyId = companyId,
                Name = department.Name,
                budget = department.budget,
            };

            departments.Add(newDepartment);
            try
            {
                dbContext.SaveChanges();
            }
            catch(DbUpdateException) { return BadRequest("department with this name is exist"); }

            return Ok();
        }
        /// <summary>
        /// Delete department in company
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmnetId"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpDelete(Name = "DeleteDepartment")]
        public IActionResult Delete(int companyId, int departmnetId)
        {
            Department? department = departments
                .ByCompany(companyId)
                .GetObj(departmnetId);
            if (department == null) return BadRequest("not exist department in company");

            departments.Remove(department);
            dbContext.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// get departments in company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<DepartmentView>),200)]
        [HttpGet(Name = "GetDepartments")]
        public IActionResult Get(int companyId)
            => Ok(departments.ByCompany(companyId).ToList().ConvertAll(new Converter<Department, DepartmentView>(Department.ToView)));
        /// <summary>
        /// get department by id in company
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmnetId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(DepartmentView),200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpGet("{departmnetId}", Name = "GetDepartment")]
        public IActionResult Get(int companyId, int departmnetId)
        {
            Department? department = departments
                .ByCompany(companyId)
                .GetObj(departmnetId);
            if (department == null) return BadRequest("not exist department in company");

            return Ok(Department.ToView(department));
        }
        /// <summary>
        /// set buget department by id in company
        /// </summary>
        /// <param name="departmnetId"></param>
        /// <param name="buget"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(DepartmentView),200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpPut("{departmnetId}", Name = "SetBugetDeparmtnet")]
        public IActionResult SetBuget(int departmnetId, decimal buget)
        {
            Department? department = departments.GetObj(departmnetId);
            if (department == null) return BadRequest("Not exist department in company");
            if (buget < 0) return BadRequest("incorect new buget");

            department.budget = buget;
            departments.Update(department);
            dbContext.SaveChanges();
            return Ok(Department.ToView(department));
        }
    }
}
