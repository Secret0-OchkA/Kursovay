using Kursovay.DataBase;
using Kursovay.Tables;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DockerTestBD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        readonly ApiContext db;
        readonly ILogger<EmployeesController> logger;

        public EmployeesController(ApiContext db, ILogger<EmployeesController> logger)
        {
            this.db = db;
            this.logger = logger;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            logger.LogInformation($"GET: {Request.Path}");
            return from d in db.employees select d;
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            logger.LogInformation($"GET: {Request.Path}");
            Employee? result = db.employees.SingleOrDefault(d => d.Id == id);

            if (result == null) return new Employee();

            return result;
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] Employee value)
        {
            logger.LogInformation($"POST: {Request.Path}");

            db.employees.Add(value);
            db.SaveChanges();
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee value)
        {
            logger.LogInformation($"PUT: {Request.Path}");

            Employee? result = db.employees.SingleOrDefault(d => d.Id == id);
            if (result != null)
            {
                result.Name = value.Name;
                result.Department = value.Department;

                db.SaveChanges();
            }
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logger.LogInformation($"DELET: {Request.Path}");

            Employee value = new Employee() { Id = id };
            db.employees.Attach(value);
            db.employees.Remove(value);
            db.SaveChanges();
        }
    }
}
