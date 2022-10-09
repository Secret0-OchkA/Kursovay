using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Service;

namespace DockerTestBD.Api.Controllers
{
    [Route(ApiRoute.baseRoute +
        ApiRoute.controller)]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        readonly IService<Company> companyService;

        public CompanyController(IService<Company> companyService)
        {
            this.companyService = companyService;
        }

        [HttpGet]
        public IActionResult GetCompany()
            => Ok(companyService.GetAll().ToList());
        [HttpGet("{id}")]
        public IActionResult GetCompany(int id)
        {
            Company? company = companyService.Get(id);

            if (company == null) return BadRequest(new Company());

            return Ok(company);
        }

        [HttpPost]
        public IActionResult CreateCompany([FromBody] Company company)
        {
            companyService.Create(company);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletCompnay(int id)
        {
            companyService.Delete(id);
            return Ok();
        }

        [HttpPut("{id}/{name}")]
        public IActionResult ChangeName(int id, string name)
        {
            Company? company = companyService.Get(id);

            if (company == null) return BadRequest(new Company());

            company.Name = name;
            companyService.Update(company);

            return Ok(company);
        }
    }
}
