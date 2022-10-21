using Context;
using Context.Queryable;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DockerTestBD.Api.Controllers
{
    [Route(ApiRoute.baseRoute +
        ApiRoute.controller)]
    [ApiController]
    [Authorize(Roles = "owner")]
    public class CompanyController : ControllerBase
    {
        readonly ApplicationDbContext dbContext;
        readonly DbSet<Company> companies;

        public CompanyController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            companies = dbContext.companies;
        }
        /// <summary>
        /// get all company
        /// </summary>
        /// <response code="200"></response>
        /// <returns></returns>
        [HttpGet(Name = "GetCompanyes")]
        public IActionResult Get()
            => Ok(companies.ToList());
        /// <summary>
        /// get company by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetCompany")]
        public IActionResult Get(int id)
        {
            Company? company = companies.GetObj(id);

            if (company == null) return BadRequest("not exist company");

            return Ok(company);
        }
        /// <summary>
        /// create company from object
        /// </summary>
        /// <param name="company"></param>
        /// <response code="200"></response>
        /// <returns></returns>
        [HttpPost(Name = "CreateCompany")]
        public IActionResult Create([FromBody] Company company)
        {
            Company newCompany = new Company
            {
                Name = company.Name,
            };
            companies.Add(newCompany);
            dbContext.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Delete company by id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeletCompany")]
        public IActionResult Delete(int id)
        {
            Company? company = companies.GetObj(id);
            if (company == null) return BadRequest("Not exist company");

            companies.Remove(company);
            dbContext.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// change name company by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <response code="200"></response>
        /// <response code="400">Not exist company</response>
        /// <returns></returns>
        [HttpPut("{id}/{name}",Name = "ChangeName")]
        public IActionResult ChangeName(int id, string name)
        {
            Company? company = companies.GetObj(id);

            if (company == null) return BadRequest("Not exist company");

            company.Name = name;
            companies.Update(company);
            dbContext.SaveChanges();
            return Ok(company);
        }
    }
}
