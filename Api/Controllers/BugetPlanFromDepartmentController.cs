using Context;
using Context.Queryable;
using Domain.ApiModel;
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
    [Produces("application/json")]
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
        /// <param name="companyId"></param>
        /// <param name="departmnetId"></param>
        /// <param name="bugetPlan"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpPost(Name = "CreateBugetPlan")]
        public IActionResult Create(int companyId,int departmnetId, BugetPlanView bugetPlan)
        {
            Department? department = dbContext.departments.ByCompany(companyId).GetObj(departmnetId);
            if (department == null) return BadRequest("not exist department");
            if (department.bugetPlan != null) return BadRequest("department have plan");

            BugetPlan newBugetPlan = new BugetPlan
            {
                DeparmentId = departmnetId,

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
        /// <param name="departmnetId"></param>
        /// <param name="bugetPlanId"></param>
        /// <returns>DeletBugetPlan</returns>
        [ProducesResponseType(200)]
        [ProducesErrorResponseType(typeof(string))]
        [HttpDelete("{bugetPlanId}", Name = "DeletBugetPlan")]
        public IActionResult Delete(int companyId, int departmnetId, int bugetPlanId)
        {
            BugetPlan? bp = bugetPlans.ByCompany(companyId).ByDepartment(departmnetId).GetObj(bugetPlanId);

            if (bp == null) return BadRequest("not exist buget plan");

            bugetPlans.Remove(bp);
            dbContext.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// get buget plan
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmnetId"></param>
        /// <param name="bugetPlanId"></param>
        /// <returns type="BugetPlanView"></returns>
        [ProducesResponseType(200, Type = typeof(BugetPlanView))]
        [ProducesErrorResponseType(typeof(string))]
        [HttpGet("{bugetPlanId}", Name = "GetBugetPlanById")]
        public IActionResult Get(int companyId, int departmnetId, int bugetPlanId)
        {
            BugetPlan? bp = bugetPlans
                .ByCompany(companyId)
                .ByDepartment(departmnetId)
                .GetObj(bugetPlanId);

            if (bp == null) return BadRequest("not exist buget plan");

            return Ok(BugetPlan.ToView(bp));
        }
        /// <summary>
        /// get buget plan by department
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmnetId"></param>
        /// <returns type="BugetPlanView"></returns>
        [ProducesResponseType(200, Type = typeof(BugetPlanView))]
        [ProducesErrorResponseType(typeof(string))]
        [HttpGet(Name = "GetBugetPlan")]
        public IActionResult Get(int companyId, int departmnetId)
        {
            BugetPlan? bp = bugetPlans
                .ByCompany(companyId)
                .ByDepartment(departmnetId)
                .SingleOrDefault();

            if (bp == null) return BadRequest("not exist buget plan");

            return Ok(BugetPlan.ToView(bp));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmnetId"></param>
        /// <param name="bugetPlanId"></param>
        /// <param name="month"></param>
        /// <param name="amount"></param>
        /// <returns>update bugetplan</returns>
        [ProducesResponseType(200, Type = typeof(BugetPlanView))]
        [ProducesErrorResponseType(typeof(string))]
        [HttpPut("{bugetPlanId}/SetMonthBuget", Name = "SetMonthBuget")]
        public IActionResult SetMonthBuget(int companyId, int departmnetId, int bugetPlanId, [FromQuery] Month month, [FromQuery] decimal amount)
        {
            BugetPlan? bp = bugetPlans
               .ByCompany(companyId)
               .ByDepartment(departmnetId)
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
            return Ok();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmnetId"></param>
        /// <param name="bugetPlanId"></param>
        /// <param name="value"></param>
        /// <returns>update bugetplan</returns>
        [ProducesResponseType(200, Type = typeof(BugetPlanView))]
        [ProducesErrorResponseType(typeof(string))]
        [HttpPut("{bugetPlanId}", Name = "UpdateBugetPlan")]
        public IActionResult UpdateBugetPlan(int companyId, int departmnetId, int bugetPlanId, [FromBody] BugetPlanView value)
        {
            BugetPlan? bp = bugetPlans
               .ByCompany(companyId)
               .ByDepartment(departmnetId)
               .GetObj(bugetPlanId);

            if (bp == null)
                return BadRequest("not exist buget plan");

            bp.January = value.January;
            bp.February = value.February ;
            bp.March = value.March;
            bp.April = value.April;
            bp.May = value.May;
            bp.June = value.June;
            bp.July = value.July;
            bp.August = value.August;
            bp.September = value.September;
            bp.October = value.October;
            bp.November = value.November;
            bp.December = value.December;

            bugetPlans.Update(bp);
            dbContext.SaveChanges();
            return Ok();
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
