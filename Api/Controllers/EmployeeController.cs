using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace DockerTestBD.Api.Controllers
{
    [Route(ApiRoute.baseRoute +
        ApiRoute.controller)]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IService<Employee> service;
        public EmployeeController(IService<Employee> service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Employee? employee = service.Get(id);
            if (employee == null) return BadRequest(new Employee());

            return Ok(employee);
        }
        [HttpGet]
        public IActionResult GetAll()
            => Ok(service.GetAll());
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            service.Create(employee);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Employee? employee = service.Get(id);
            if (employee == null) return BadRequest();

            return Ok();
        }
        //TODO: UpdateMethods
    }
}
