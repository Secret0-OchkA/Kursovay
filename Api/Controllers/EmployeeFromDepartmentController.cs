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
        ApiRoute.Company + ApiRoute.FromCompany +
        ApiRoute.Deparment + ApiRoute.FromDepartment +
        ApiRoute.controller)]
    [ApiController()]
    [Produces("application/json")]
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
        /// <param name="departmnetId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<EmployeeView>),200)]
        [HttpGet(Name = "GetEmployeesInDepartment")]
        public IActionResult Get(int companyId, int departmnetId)
            => Ok(employees.ByCompany(companyId).ByDepartment(departmnetId).ToList());
        /// <summary>
        /// get employee in department in company by id
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmnetId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(EmployeeView),200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpGet("{employeeId}",Name = "GetEmployeeInDepartment" )]
        public IActionResult Get(int companyId, int departmnetId, int employeeId)
        {
            Employee? employee = employees.ByCompany(companyId).ByDepartment(departmnetId).GetObj(employeeId);
            if (employee == null) return BadRequest("not exist employee");

            return Ok(employee);
        }

        /// <summary>
        /// remove employee from department in company
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmnetId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(EmployeeView),200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpDelete("{employeeId}",Name = "DismissEmployee")]
        public IActionResult Remove(int companyId, int departmnetId, int employeeId)
        {
            Employee? employee = employees
                .ByCompany(companyId)
                .ByDepartment(departmnetId)
                .GetObj(employeeId);
            Department? department = departments.ByCompany(companyId).GetObj(departmnetId);
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
        /// <param name="departmnetId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpPost("{employeeId}", Name ="HireEmployee")]
        public IActionResult Add(int companyId, int departmnetId, int employeeId)
        {
            Employee? employee = employees.GetObj(employeeId);
            Department? department = departments.ByCompany(companyId).GetObj(departmnetId);
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
