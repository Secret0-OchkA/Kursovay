using Context;
using Context.Queryable;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DockerTestBD.Api.Controllers
{
    [Route(ApiRoute.baseRoute +
        ApiRoute.Company + ApiRoute.FromCompany +
        ApiRoute.Deparment + ApiRoute.FromDepartment +
        ApiRoute.controller)]
    [ApiController()]
    [Authorize(Roles = "owner")]
    public class EmployeeFromDepartmentController : ControllerBase
    {
        readonly ApplicationDbContext dbContext;
        readonly DbSet<Employee> employees;
        readonly DbSet<Department> departments;
        public EmployeeFromDepartmentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            employees = dbContext.employees;
            departments = dbContext.departments;
        }
        /// <summary>
        /// get employees in department in company
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmentId"></param>
        /// <response code="200"></response>
        /// <returns></returns>
        [HttpGet(Name = "GetEmployeesInDepartment")]
        public IActionResult Get(int companyId, int departmentId)
            => Ok(employees.ByCompany(companyId).ByDepartment(departmentId).ToList());
        /// <summary>
        /// get employee in department in company by id
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmentId"></param>
        /// <param name="employeeId"></param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <returns></returns>
        [HttpGet("{employeeId}",Name = "GetEmployeeInDepartment" )]
        public IActionResult Get(int companyId, int departmentId, int employeeId)
        {
            Employee? employee = employees.ByCompany(companyId).ByDepartment(departmentId).GetObj(employeeId);
            if (employee == null) return BadRequest("not exist employee");

            return Ok(employee);
        }

        /// <summary>
        /// remove employee from department in company
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmentId"></param>
        /// <param name="employeeId"></param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <returns></returns>
        [HttpDelete("{employeeId}",Name = "DismissEmployee")]
        public IActionResult Remove(int companyId, int departmentId, int employeeId)
        {
            Employee? employee = employees
                .ByCompany(companyId)
                .ByDepartment(departmentId)
                .GetObj(employeeId);
            Department? department = departments.ByCompany(companyId).GetObj(departmentId);
            if (employee == null ) return BadRequest("not exist employee");
            if (department == null) return BadRequest("the employee is not hired");

            if (!department.employees.Contains(employee)) return BadRequest("employee doesn't work in this department");

            department.employees.Remove(employee);

            departments.Update(department);
            dbContext.SaveChanges();

            return Ok(employee);
        }
        /// <summary>
        /// add epmployee to department
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmentId"></param>
        /// <param name="employeeId"></param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <returns></returns>
        [HttpPost("{employeeId}", Name ="HireEmployee")]
        public IActionResult Add(int companyId, int departmentId, int employeeId)
        {
            Employee? employee = employees.GetObj(employeeId);
            Department? department = departments.ByCompany(companyId).GetObj(departmentId);
            if (employee == null) return BadRequest("not exist employee");
            if (department == null) return BadRequest("not exist department");

            if (employee.Department != null) return BadRequest("employee works in another department");

            if (department.employees.Contains(employee)) return BadRequest("employee is already working in department");

            department.employees.Add(employee);

            departments.Update(department);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
