using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DockerTestBD.Api.Controllers
{
    /// <summary>
    /// Test connection
    /// </summary>
    [Route(ApiRoute.baseRoute + ApiRoute.controller)]
    [ApiController]
    public class OkController : ControllerBase
    {
        /// <summary>
        /// for check connect
        /// </summary>
        /// <returns>Ok</returns>
        [ProducesResponseType(200)]
        [HttpGet(Name = "CheckConnectToApi")]
        public IActionResult OK() => Ok();
        /// <summary>
        /// for check auth
        /// </summary>
        /// <returns>Ok</returns>
        [ProducesResponseType(200)]
        [Authorize]
        [HttpGet("OkAuth",Name = "CheckAuth")]
        public IActionResult OKAuth() => Ok("Ok Auth");
    }
}
