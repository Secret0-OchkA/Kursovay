using Context;
using Domain.Model;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Policy;
using System.Xml.Linq;

namespace DockerTestBD.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthorizationController : ControllerBase
    {
        readonly ApplicationDbContext dbContext;
        readonly DbSet<User> users;
        public AuthorizationController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            users = dbContext.users;
        }

        /// <summary>
        /// Register new Account
        /// </summary>
        /// <param name="name"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="roleName"></param>
        [ProducesResponseType(200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpPost("Register")]
        public IActionResult Register(string name, string login, string password, string roleName)
        {
            Role? role = dbContext.roles.Where(r => r.Name == roleName).SingleOrDefault();
            if (role == null) return BadRequest("Not exist role");

            User newUser = new User
            {
                Name = name,
                Email = login,
                Password = password,
                role = role,
            };

            users.Add(newUser);
            dbContext.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// generation jwt token on 1 day
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>jwt token</returns>
        [ProducesResponseType(200, Type = typeof(string))]
        [HttpPost("Login")]
        public IActionResult Login(string email, string password)
        {
            User? loginUser = users
                .Where(u => u.Email == email && u.Password == password)
                .SingleOrDefault();
            if (loginUser == null)
                return Unauthorized("incorect email");

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginUser.Name),
                new Claim(ClaimTypes.Email, loginUser.Email),
                new Claim(ClaimTypes.Role, loginUser.role.Name)
            };

            JwtSecurityToken jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
        }
    }
}
