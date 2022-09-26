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
        readonly ILogger logger;

        public ExpensesController(ApiContext db, ILogger logger)
        {
            this.db = db;
            this.logger = logger;
        }

        // GET: api/<ExpenseController>
        [HttpGet]
        public IEnumerable<Expense> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/<ExpenseController>/5
        [HttpGet("{id}")]
        public Expense Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/<ExpenseController>
        [HttpPost]
        public void Post([FromBody] Expense value)
        {
            throw new NotImplementedException();
        }

        // PUT api/<ExpenseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Expense value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<ExpenseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
