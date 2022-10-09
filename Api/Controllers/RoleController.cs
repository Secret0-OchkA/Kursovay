using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace DockerTestBD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        readonly IService<Role> service;
        public RoleController(IService<Role> service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
            => Ok(service.GetAll());
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Role? role = service.Get(id);
            if (role == null) return BadRequest(new Role());
            return Ok(role);
        }
    }
}
