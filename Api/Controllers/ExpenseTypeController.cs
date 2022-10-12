using Context;
using Context.Queryable;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DockerTestBD.Api.Controllers
{
    [Route(ApiRoute.baseRoute +
        ApiRoute.Company + ApiRoute.FromCompany +
        ApiRoute.controller)]
    [ApiController]
    public class ExpenseTypeController : ControllerBase
    {
        readonly ApplicationDbContext dbContext;
        readonly DbSet<ExpenseType> expenseTypes;
        public ExpenseTypeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            expenseTypes = dbContext.expenseTypes;
        }

        [HttpPost]
        [Authorize(Roles = "owner")]
        public IActionResult Post(int companyId, ExpenseType expenseType)
        {
            ExpenseType newExpenseType = new ExpenseType
            {
                Name = expenseType.Name,
                Description = expenseType.Description,
                Limit = expenseType.Limit,
                CompanyId = companyId
            };
            expenseTypes.Add(newExpenseType);
            dbContext.SaveChanges();
            return Ok();
        }
        [HttpGet]
        [Authorize(Roles = "owner,accountant")]
        public IActionResult Get(int companyId)
            => Ok(expenseTypes.ByCompany(companyId).ToList());
        [HttpGet("{expenseTypeId}")]
        [Authorize(Roles = "owner,accountant")]
        public IActionResult Get(int companyId, int expenseTypeId)
        {
            ExpenseType? expenseType = expenseTypes.ByCompany(companyId).GetObj(expenseTypeId);
            if (expenseType == null)
                return BadRequest(new ExpenseType());
            return Ok(expenseType);
        }

        [HttpDelete("{expenseTypeId}")]
        [Authorize(Roles = "owner")]
        public IActionResult Delet(int companyId, int expenseTypeId)
        {
            ExpenseType? expenseType = expenseTypes.ByCompany(companyId).GetObj(expenseTypeId);

            if (expenseType == null)
                return BadRequest();

            expenseTypes.Remove(expenseType);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{expenseTypeId}")]
        [Authorize(Roles = "owner")]
        public IActionResult Update(int companyId, int expenseTypeId, ExpenseType entity)
        {
            ExpenseType? expenseType = expenseTypes.ByCompany(companyId).GetObj(expenseTypeId);

            if (entity.Limit <= 0 || expenseType == null) return BadRequest(new ExpenseType());

            expenseType.Name = entity.Name;
            expenseType.Description = entity.Description;
            expenseType.Limit = entity.Limit;

            expenseTypes.Update(expenseType);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
