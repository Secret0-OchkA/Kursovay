using Context;
using Context.Queryable;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace DockerTestBD.Api.Controllers
{
    [Route(ApiRoute.baseRoute +
        ApiRoute.Company +
        ApiRoute.FromCompany +
        ApiRoute.Deparment +
        ApiRoute.FromDepartment +
        ApiRoute.controller)]
    [ApiController]
    [Authorize(Roles = "owner,accountant")]
    public class BugetPlanController : ControllerBase
    {
        readonly ApplicationDbContext dbContext;
        readonly DbSet<BugetPlan> bugetPlans;
        public BugetPlanController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            bugetPlans = dbContext.bugetPlans;
        }

        /// <summary>
        /// можно создать только 1 на департамент
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="bugetPlan"></param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <returns></returns>
        [HttpPost(Name = "CreateBugetPlan")]
        public IActionResult Create(int companyId,int departmentId, BugetPlan bugetPlan)
        {
            Department? department = dbContext.departments.ByCompany(companyId).GetObj(departmentId);
            if (department == null) return BadRequest("not exist department");
            if (department.bugetPlan != null) return BadRequest("department have plan");

            BugetPlan newBugetPlan = new BugetPlan
            {
                DeparmentId = departmentId,

                January = bugetPlan.January,
                February = bugetPlan.February,
                March = bugetPlan.March,
                April = bugetPlan.April,          
                May = bugetPlan.May,
                June = bugetPlan.June,           
                July = bugetPlan.July,          
                August = bugetPlan.August,
                September = bugetPlan.September,
                October = bugetPlan.October,
                November = bugetPlan.November,
                December = bugetPlan.December 
                };
            bugetPlans.Add(newBugetPlan);
            dbContext.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// delet bugetplan
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmentId"></param>
        /// <param name="bugetPlanId"></param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <returns>DeletBugetPlan</returns>
        [HttpDelete("{bugetPlanId}", Name = "DeletBugetPlan")]
        public IActionResult Delete(int companyId, int departmentId, int bugetPlanId)
        {
            BugetPlan? bp = bugetPlans.ByCompany(companyId).ByDepartment(departmentId).GetObj(bugetPlanId);

            if (bp == null) return BadRequest("not exist buget plan");

            bugetPlans.Remove(bp);
            dbContext.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// get buget plan
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmentId"></param>
        /// <param name="bugetPlanId"></param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <returns>BugetPlan</returns>
        [HttpGet("{bugetPlanId}", Name = "GetBugetPlan")]
        public IActionResult Get(int companyId, int departmentId, int bugetPlanId)
        {
            BugetPlan? bp = bugetPlans
                .ByCompany(companyId)
                .ByDepartment(departmentId)
                .GetObj(bugetPlanId);

            if (bp == null) return BadRequest("not exist buget plan");

            return Ok(bp);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmentId"></param>
        /// <param name="bugetPlanId"></param>
        /// <param name="month"></param>
        /// <param name="amount"></param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <returns>update bugetplan</returns>
        [HttpPut("{bugetPlanId}", Name = "SetMonthBuget")]
        public IActionResult SetMonthBuget(int companyId, int departmentId, int bugetPlanId, [FromQuery] Month month, [FromQuery] decimal amount)
        {
            BugetPlan? bp = bugetPlans
               .ByCompany(companyId)
               .ByDepartment(departmentId)
               .GetObj(bugetPlanId);

            if (bp == null)
                return BadRequest("not exist buget plan");

            switch (month)
            {
                case Month.January: bp.January = amount; break;
                case Month.February: bp.February = amount; break;
                case Month.March: bp.March = amount; break;
                case Month.April: bp.April = amount; break;
                case Month.May: bp.May = amount; break;
                case Month.June: bp.June = amount; break;
                case Month.July: bp.July = amount; break;
                case Month.August: bp.August = amount; break;
                case Month.September: bp.September = amount; break;
                case Month.October: bp.October = amount; break;
                case Month.November: bp.November = amount; break;
                case Month.December: bp.December = amount; break;

                default: return BadRequest("incorect month");
            }

            bugetPlans.Update(bp);
            dbContext.SaveChanges();
            return Ok(bp);
        }
    }

    public enum Month
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
}
