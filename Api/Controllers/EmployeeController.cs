using Context;
using Context.Queryable;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DockerTestBD.Api.Controllers
{
    [Route(ApiRoute.baseRoute +
        ApiRoute.controller)]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        readonly ApplicationDbContext dbContext;
        readonly DbSet<Employee> employees;
        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            employees = dbContext.employees;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Employee? employee = employees.GetObj(id);
            if (employee == null) return BadRequest(new Employee());

            return Ok(employee);
        }
        [HttpGet]
        public IActionResult GetAll()
            => Ok(employees.ToList());

        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    Employee? employee = employees.GetObj(id);
        //    if (employee == null) return BadRequest();

        //    return Ok();
        //}
        //TODO: UpdateMethods
    }
}
