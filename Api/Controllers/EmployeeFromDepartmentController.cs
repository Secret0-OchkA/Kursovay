using Context;
using Context.Queryable;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DockerTestBD.Api.Controllers
{
    [Route(ApiRoute.baseRoute +
        ApiRoute.Company + ApiRoute.FromCompany +
        ApiRoute.Deparment + ApiRoute.FromDepartment +
        ApiRoute.controller)]
    [ApiController()]
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

        [HttpGet]
        public IActionResult GetEmployee(int companyId, int departmentId)
            => Ok(employees.ByCompany(companyId).ByDepartment(departmentId).ToList());
        [HttpGet("{employeeId}")]
        public IActionResult GetEmployee(int companyId, int departmentId, int employeeId)
        {
            Employee? employee = employees.ByCompany(companyId).ByDepartment(departmentId).GetObj(employeeId);
            if (employee == null) return BadRequest(new Employee());

            return Ok(employee);
        }

        [HttpDelete("{employeeId}")]
        public IActionResult Remove(int companyId, int departmentId, int employeeId)
        {
            Employee? employee = employees
                .ByCompany(companyId)
                .ByDepartment(departmentId)
                .GetObj(employeeId);
            Department? department = departments.ByCompany(companyId).GetObj(departmentId);
            if (employee == null || department == null)
                return BadRequest(new Employee());

            if (!department.employees.Contains(employee))
                return BadRequest();

            department.employees.Remove(employee);

            departments.Update(department);
            dbContext.SaveChanges();

            return Ok(employee);
        }
        [HttpPost("{employeeId}")]
        public IActionResult Add(int companyId, int departmentId, int employeeId)
        {
            Employee? employee = employees.GetObj(employeeId);
            Department? department = departments.ByCompany(companyId).GetObj(departmentId);
            if (employee == null || department == null)
                return BadRequest(new Employee());

            if (department.employees.Contains(employee))
                return BadRequest();

            department.employees.Add(employee);

            departments.Update(department);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
