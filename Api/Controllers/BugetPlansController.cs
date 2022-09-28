using Kursovay.DataBase;
using Kursovay.Tables;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DockerTestBD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugetPlansController : ControllerBase
    {
        readonly ApiContext db;
        readonly ILogger<BugetPlansController> logger;

        public BugetPlansController(ApiContext db, ILogger<BugetPlansController> logger)
        {
            this.db = db;
            this.logger = logger;
        }

        // GET: api/<BugetPlanController>
        [HttpGet]
        public IEnumerable<BugetPlan> Get()
        {
            logger.LogInformation($"GET: {Request.Path}");
            return from bp in db.bugetPlans select bp;
        }

        // GET api/<BugetPlanController>/5
        [HttpGet("{id}")]
        public BugetPlan Get(int id)
        {
            logger.LogInformation($"GET: {Request.Path}");
            BugetPlan? result = db.bugetPlans.SingleOrDefault(bp => bp.Id == id);

            if (result == null) return new BugetPlan();

            return result;
        }

        // POST api/<BugetPlanController>
        [HttpPost]
        public void Post([FromBody] BugetPlan value)
        {
            logger.LogInformation($"POST: {Request.Path}");
            
            db.bugetPlans.Add(value);
            db.SaveChanges();
        }

        // PUT api/<BugetPlanController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BugetPlan value)
        {
            logger.LogInformation($"PUT: {Request.Path}");

            BugetPlan? result = db.bugetPlans.SingleOrDefault(bp => bp.Id == id);
            if (result != null)
            {
                result.Department = value.Department;
                result.January = value.January;
                result.February = value.February;
                result.March = value.March;
                result.April = value.April;
                result.May = value.May;
                result.June = value.June;
                result.July = value.July;
                result.August = value.August;
                result.September = value.September;
                result.October = value.October;
                result.November = value.November;
                result.December = value.December;

                db.SaveChanges();
            }
        }

        // DELETE api/<BugetPlanController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logger.LogInformation($"DELET: {Request.Path}");

            BugetPlan value = new BugetPlan() { Id = id };
            db.bugetPlans.Attach(value);
            db.bugetPlans.Remove(value);
            db.SaveChanges();
        }
    }
}
