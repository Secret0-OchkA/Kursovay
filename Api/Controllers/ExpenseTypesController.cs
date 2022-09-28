using Kursovay.DataBase;
using Kursovay.Tables;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kursovay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseTypesController : ControllerBase
    {
        readonly ApiContext db;
        readonly ILogger<ExpenseTypesController> logger;

        public ExpenseTypesController(ApiContext db, ILogger<ExpenseTypesController> logger)
        {
            this.db = db;
            this.logger = logger;
        }

        // GET: api/<ExpenseTypeController>
        [HttpGet]
        public IEnumerable<ExpenseType> Get()
        {
            logger.LogInformation($"GET: {Request.Path}");
            return from bp in db.expenseTypes select bp;
        }

        // GET api/<ExpenseTypeController>/5
        [HttpGet("{id}")]
        public ExpenseType Get(int id)
        {
            logger.LogInformation($"GET: {Request.Path}");
            ExpenseType? result = db.expenseTypes.SingleOrDefault(bp => bp.Id == id);

            if (result == null) return new ExpenseType();

            return result;
        }

        // POST api/<ExpenseTypeController>
        [HttpPost]
        public void Post([FromBody] ExpenseType value)
        {
            logger.LogInformation($"POST: {Request.Path}");

            db.expenseTypes.Add(value);
            db.SaveChanges();
        }

        // PUT api/<ExpenseTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ExpenseType value)
        {
            logger.LogInformation($"PUT: {Request.Path}");

            ExpenseType? result = db.expenseTypes.SingleOrDefault(bp => bp.Id == id);
            if (result != null)
            {
                result.Name = value.Name;
                result.Description = value.Description;
                result.Limit = value.Limit;

                db.SaveChanges();
            }
        }

        // DELETE api/<ExpenseTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logger.LogInformation($"DELET: {Request.Path}");

            ExpenseType value = new ExpenseType() { Id = id };
            db.expenseTypes.Attach(value);
            db.expenseTypes.Remove(value);
            db.SaveChanges();
        }
    }
}
