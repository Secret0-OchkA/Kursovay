using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryPattern
{
    public class BugetPlanRepository : IRepository<BugetPlan>
    {
        readonly ApplicationDbContext _dbContext;
        readonly DbSet<BugetPlan> bugetPlans;

        public BugetPlanRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            bugetPlans = _dbContext.Set<BugetPlan>();
        }

        public void Delete(int id)
        {
            BugetPlan? bugetPlan = bugetPlans.SingleOrDefault(o => o.Id == id);

            if (bugetPlan == null) return;

            bugetPlans.Remove(bugetPlan);
        }

        public BugetPlan? Get(int id)
        {
            return (from bp in bugetPlans
                    join d in _dbContext.departments on bp.DeparmentId equals d.Id
                    where bp.Id == id
                    select bp).FirstOrDefault();
        }

        public IQueryable<BugetPlan> GetAll()
        {
            return from bp in bugetPlans
                   join d in _dbContext.departments on bp.DeparmentId equals d.Id
                   select bp;
        }

        public void Insert(BugetPlan entity)
        {
            bugetPlans.Add(entity);
        }

        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }

        public void Update(BugetPlan entity)
        {
            bugetPlans.Update(entity);
        }
    }
}
