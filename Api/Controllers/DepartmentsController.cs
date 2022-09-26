using Kursovay.DataBase;
using Kursovay.Tables;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kursovay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        readonly ApiContext db;
        readonly ILogger logger;

        public DepartmentsController(ApiContext db, ILogger logger)
        {
            this.db = db;
            this.logger = logger;
        }

        // GET: api/<DepartmentController>
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public Department Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public void Post([FromBody] Department value)
        {
            throw new NotImplementedException();
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Department value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
