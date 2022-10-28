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
    [Produces("application/json")]
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
        /// <returns></returns>
        [ProducesResponseType(typeof(List<Company>), 200)]
        [HttpGet(Name = "GetCompanyes")]
        public IActionResult Get()
            => Ok(companies.ToList());
        /// <summary>
        /// get company by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Company), 200)]
        [ProducesErrorResponseType(typeof(string))]
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
        /// <returns></returns>
        [ProducesResponseType(200)]
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
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesErrorResponseType(typeof(string))]
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
        /// <returns></returns>
        [ProducesResponseType(typeof(Company), 200)]
        [ProducesErrorResponseType(typeof(string))]
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
