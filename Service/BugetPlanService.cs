using Domain.Model;
using Microsoft.EntityFrameworkCore.Migrations;
using Repository.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BugetPlanService : BaseService<BugetPlan>
    {
        public BugetPlanService(IRepository<BugetPlan> repository) : base(repository) { }

        public void EditBugetPlan(int id, Month month, decimal amount)
        {
            BugetPlan entity = Get(id);

            switch (month)
            {
                case Month.January: entity.January = amount; break;
                case Month.February: entity.February = amount; break;
                case Month.March: entity.March = amount; break;
                case Month.April: entity.April = amount; break;
                case Month.May: entity.May = amount; break;
                case Month.June: entity.June = amount; break;
                case Month.July: entity.July = amount; break;
                case Month.August: entity.August = amount; break;
                case Month.September: entity.September = amount; break;
                case Month.October: entity.October = amount; break;
                case Month.November: entity.November = amount; break;
                case Month.December: entity.December = amount; break;
            }

            repository.Update(entity);
            repository.SaveChange();
            
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
