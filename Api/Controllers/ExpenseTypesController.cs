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
        readonly ILogger logger;

        public ExpenseTypesController(ApiContext db, ILogger logger)
        {
            this.db = db;
            this.logger = logger;
        }

        // GET: api/<ExpenseTypeController>
        [HttpGet]
        public IEnumerable<ExpenseType> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/<ExpenseTypeController>/5
        [HttpGet("{id}")]
        public ExpenseType Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/<ExpenseTypeController>
        [HttpPost]
        public void Post([FromBody] ExpenseType value)
        {
            throw new NotImplementedException();
        }

        // PUT api/<ExpenseTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ExpenseType value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<ExpenseTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
