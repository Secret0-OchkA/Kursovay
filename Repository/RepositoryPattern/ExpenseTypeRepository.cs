using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryPattern
{
    public class ExpenseTypeRepository : IRepository<ExpenseType>
    {
        readonly ApplicationDbContext _dbContext;
        readonly DbSet<ExpenseType> expenseTypes;

        public ExpenseTypeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            expenseTypes = _dbContext.Set<ExpenseType>();
        }

        public void Delete(int id)
        {
            ExpenseType? bugetPlan = expenseTypes.SingleOrDefault(o => o.Id == id);

            if (bugetPlan == null) return;

            expenseTypes.Remove(bugetPlan);
        }

        public ExpenseType? Get(int id)
        {
            return (from et in expenseTypes
                    where et.Id == id 
                    select et).FirstOrDefault();
        }

        public IQueryable<ExpenseType> GetAll()
        {
            return expenseTypes;
        }

        public void Insert(ExpenseType entity)
        {
            expenseTypes.Add(entity);
        }

        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }

        public void Update(ExpenseType entity)
        {
            expenseTypes.Update(entity);
        }
    }
}
