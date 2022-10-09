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
        /// method for connect
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string OK() => "OK";
    }
}
