using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DockerTestBD.Api.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class AuthorizationController : ControllerBase
    //{
    //    public void Register(string name, string login, string password)
    //    {
    //        var claims = new List<Claim> 
    //        { 
    //            new Claim(ClaimTypes.Name, name),
    //            new Claim(ClaimTypes.Email, login),
    //        };
    //        userma
    //        var jwt = new JwtSecurityToken(
    //                issuer: AuthOptions.ISSUER,
    //                audience: AuthOptions.AUDIENCE,
    //                claims: claims,
    //                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)), // время действия 2 минуты
    //                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

    //        return new JwtSecurityTokenHandler().WriteToken(jwt);
    //    }
    //}
}
