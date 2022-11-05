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
    [Produces("application/json")]
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
        /// <summary>
        /// create new expenseType in company
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="expenseType"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [HttpPost(Name = "CreateExpenseTypeInCompany")]
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
        /// <summary>
        /// get expense types in company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<ExpenseType>),200)]
        [HttpGet(Name = "GetEpxensTypesInCompany")]
        public IActionResult Get(int companyId)
            => Ok(expenseTypes.ByCompany(companyId).ToList());
        /// <summary>
        /// get expense type in company by id
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="expenseTypeId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ExpenseType),200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpGet("{expenseTypeId}",Name = "GetExpenseTypeInCompany")]
        public IActionResult Get(int companyId, int expenseTypeId)
        {
            ExpenseType? expenseType = expenseTypes.ByCompany(companyId).GetObj(expenseTypeId);
            if (expenseType == null) return BadRequest("not exist expenseType");
            return Ok(expenseType);
        }
        /// <summary>
        /// delete expense type in company
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="expenseTypeId"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpDelete("{expenseTypeId}",Name = "DeleteExpenseTypeInCompany")]
        public IActionResult Delet(int companyId, int expenseTypeId)
        {
            ExpenseType? expenseType = expenseTypes.ByCompany(companyId).GetObj(expenseTypeId);

            if (expenseType == null) return BadRequest("not exist expenseType");

            expenseTypes.Remove(expenseType);
            dbContext.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// can change name,limit, description
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="expenseTypeId"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpPut("{expenseTypeId}",Name = "UpdateExpenseType")]
        public IActionResult Update(int companyId, int expenseTypeId, ExpenseType entity)
        {
            ExpenseType? expenseType = expenseTypes.ByCompany(companyId).GetObj(expenseTypeId);

            if (entity.Limit <= 0) return BadRequest("limit <= 0");
            if (expenseType == null) return BadRequest("expenseType not exist");

            expenseType.Name = entity.Name;
            expenseType.Description = entity.Description;
            expenseType.Limit = entity.Limit;

            expenseTypes.Update(expenseType);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
