using Kursovay.DataBase;
using Kursovay.Tables;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kursovay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        readonly ApiContext db;
        readonly ILogger<ExpensesController> logger;

        public ExpensesController(ApiContext db, ILogger<ExpensesController> logger)
        {
            this.db = db;
            this.logger = logger;
        }

        // GET: api/<ExpensesController>
        [HttpGet]
        public IEnumerable<Expense> Get()
        {
            logger.LogInformation($"GET: {Request.Path}");
            return from d in db.expenses select d;
        }

        // GET api/<ExpensesController>/5
        [HttpGet("{id}")]
        public Expense Get(int id)
        {
            logger.LogInformation($"GET: {Request.Path}");
            Expense? result = db.expenses.SingleOrDefault(d => d.Id == id);

            if (result == null) return new Expense();

            return result;
        }

        // POST api/<ExpensesController>
        [HttpPost]
        public void Post([FromBody] Expense value)
        {
            logger.LogInformation($"POST: {Request.Path}");

            db.expenses.Add(value);
            db.SaveChanges();
        }

        // PUT api/<ExpensesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Expense value)
        {
            logger.LogInformation($"PUT: {Request.Path}");

            Expense? result = db.expenses.SingleOrDefault(d => d.Id == id);
            if (result != null)
            {
                result.expenseType = value.expenseType;
                result.date = value.date;
                result.amount = value.amount;
                result.department = value.department;
                result.employee = value.employee;

                db.SaveChanges();
            }
        }

        // DELETE api/<ExpensesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logger.LogInformation($"DELET: {Request.Path}");

            Expense value = new Expense() { Id = id };
            db.expenses.Attach(value);
            db.expenses.Remove(value);
            db.SaveChanges();
        }
    }
}
