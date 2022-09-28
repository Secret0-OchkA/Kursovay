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
        readonly ILogger<DepartmentsController> logger;

        public DepartmentsController(ApiContext db, ILogger<DepartmentsController> logger)
        {
            this.db = db;
            this.logger = logger;
        }

        // GET: api/<DepartmentsController>
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            logger.LogInformation($"GET: {Request.Path}");
            return from d in db.departments select d;
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public Department Get(int id)
        {
            logger.LogInformation($"GET: {Request.Path}");
            Department? result = db.departments.SingleOrDefault(d => d.Id == id);

            if (result == null) return new Department();

            return result;
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public void Post([FromBody] Department value)
        {
            logger.LogInformation($"POST: {Request.Path}");

            db.departments.Add(value);
            db.SaveChanges();
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Department value)
        {
            logger.LogInformation($"PUT: {Request.Path}");

            Department? result = db.departments.SingleOrDefault(d => d.Id == id);
            if (result != null)
            {
                result.Name = value.Name;
                result.employees = value.employees;
                result.budget = value.budget;

                db.SaveChanges();
            }
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logger.LogInformation($"DELET: {Request.Path}");

            Department value = new Department() { Id = id };
            db.departments.Attach(value);
            db.departments.Remove(value);
            db.SaveChanges();
        }
    }
}
