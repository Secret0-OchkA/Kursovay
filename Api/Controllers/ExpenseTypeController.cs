using Context;
using Context.Queryable;
using Domain.Model;
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

        [HttpGet]
        public IActionResult Get(int companyId)
            => Ok(expenseTypes.ByCompany(companyId).ToList());
        [HttpGet("{expenseTypeId}")]
        public IActionResult Get(int companyId, int expenseTypeId)
        {
            ExpenseType? expenseType = expenseTypes.ByCompany(companyId).GetObj(expenseTypeId);
            if (expenseType == null)
                return BadRequest(new ExpenseType());
            return Ok(expenseType);
        }
        [HttpPost]
        public IActionResult Post(int companyId, ExpenseType expenseType)
        {
            expenseType.CompanyId = companyId;
            expenseTypes.Add(expenseType);
            dbContext.SaveChanges();
            return Ok();
        }
        [HttpDelete("{expenseTypeId}")]
        public IActionResult Delet(int companyId, int expenseTypeId)
        {
            ExpenseType? expenseType = expenseTypes.ByCompany(companyId).GetObj(expenseTypeId);

            if (expenseType == null)
                return BadRequest();

            expenseTypes.Remove(expenseType);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int companyId, ExpenseType entity)
        {
            if (entity.CompanyId != companyId)
                return BadRequest(new ExpenseType());

            if (entity.Limit <= 0) return BadRequest(new ExpenseType());

            expenseTypes.Update(entity);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
