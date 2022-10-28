using Context;
using Context.Queryable;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DockerTestBD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class RoleController : ControllerBase
    {
        readonly ApplicationDbContext dbContext;
        readonly DbSet<Role> roles;
        public RoleController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            roles = dbContext.roles;
        }

        [ProducesResponseType(typeof(List<Role>),200)]
        [HttpGet]
        public IActionResult Get()
            => Ok(roles.ToList());
        [ProducesResponseType(typeof(Role),200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpGet("{roleId}")]
        public IActionResult Get(int roleId)
        {
            Role? role = roles.GetObj(roleId);
            if (role == null) return BadRequest("not exist role");
            return Ok(role);
        }
    }
}
