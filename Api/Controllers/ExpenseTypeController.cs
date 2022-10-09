using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace DockerTestBD.Api.Controllers
{
    [Route(ApiRoute.baseRoute +
        ApiRoute.Company + ApiRoute.FromCompany +
        ApiRoute.controller)]
    [ApiController]
    public class ExpenseTypeController : ControllerBase
    {
        readonly IService<ExpenseType> service;
        public ExpenseTypeController(IService<ExpenseType> service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get(int companyId)
            => Ok(service.GetAll().Where(ext => ext.CompanyId == companyId));
        [HttpGet("{id}")]
        public IActionResult Get(int companyId, int id)
        {
            ExpenseType? expenseType = service.Get(id);
            if (expenseType == null || expenseType.CompanyId != companyId)
                return BadRequest(new ExpenseType());
            return Ok(expenseType);
        }
        [HttpPost]
        public IActionResult Post(int companyId, ExpenseType expenseType)
        {
            expenseType.CompanyId = companyId;
            service.Create(expenseType);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delet(int companyId, int id)
        {
            ExpenseType? expenseType = service.Get(id);

            if (expenseType == null || expenseType.CompanyId != companyId)
                return BadRequest();

            service.Delete(id);

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int companyId, int id, ExpenseType entity)
        {
            if (entity.CompanyId != companyId || entity.Id != id)
                return BadRequest(new ExpenseType());

            if (entity.Limit <= 0) return BadRequest(new ExpenseType());

            service.Update(entity);

            return Ok(service.Get(id));
        }
    }
}
