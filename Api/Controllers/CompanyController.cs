using Context;
using Context.Queryable;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DockerTestBD.Api.Controllers
{
    [Route(ApiRoute.baseRoute +
        ApiRoute.controller)]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        readonly ApplicationDbContext dbContext;
        readonly DbSet<Company> companies;

        public CompanyController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            companies = dbContext.companies;
        }

        [HttpGet]
        public IActionResult GetCompany()
            => Ok(companies.ToList());
        [HttpGet("{id}")]
        public IActionResult GetCompany(int id)
        {
            Company? company = companies.GetObj(id);

            if (company == null) return BadRequest(new Company());

            return Ok(company);
        }

        [HttpPost]
        public IActionResult CreateCompany([FromBody] Company company)
        {
            companies.Add(company);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletCompnay(int id)
        {
            Company? company = companies.GetObj(id);
            if (company == null) return BadRequest();

            companies.Remove(company);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}/{name}")]
        public IActionResult ChangeName(int id, string name)
        {
            Company? company = companies.GetObj(id);

            if (company == null) return BadRequest(new Company());

            company.Name = name;
            companies.Update(company);
            dbContext.SaveChanges();
            return Ok(company);
        }
    }
}
