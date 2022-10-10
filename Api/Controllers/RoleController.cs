using Context;
using Context.Queryable;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DockerTestBD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        readonly ApplicationDbContext dbContext;
        readonly DbSet<Role> roles;
        public RoleController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            roles = dbContext.roles;
        }

        [HttpGet]
        public IActionResult Get()
            => Ok(roles.ToList());
        [HttpGet("{roleId}")]
        public IActionResult Get(int roleId)
        {
            Role? role = roles.GetObj(roleId);
            if (role == null) return BadRequest(new Role());
            return Ok(role);
        }
    }
}
