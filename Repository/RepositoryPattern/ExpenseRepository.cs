using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryPattern
{
    public class ExpenseRepository : IRepository<Expense>
    {
        readonly ApplicationDbContext _dbContext;
        readonly DbSet<Expense> expenses;

        public ExpenseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            expenses = _dbContext.Set<Expense>();
        }

        public void Delete(int id)
        {
            Expense? bugetPlan = expenses.SingleOrDefault(o => o.Id == id);

            if (bugetPlan == null) return;

            expenses.Remove(bugetPlan);
        }

        public Expense? Get(int id)
        {
            return (from ex in expenses
                    join exType in _dbContext.expenseTypes on ex.ExpenseTypeId equals exType.Id
                    join d in _dbContext.departments on ex.DepartmentId equals d.Id
                    join e in _dbContext.employees on ex.EmploeeId equals e.Id
                    where ex.Id == id
                    select ex).FirstOrDefault();
        }

        public IQueryable<Expense> GetAll()
        {
            return from ex in expenses
                   join exType in _dbContext.expenseTypes on ex.ExpenseTypeId equals exType.Id
                   join d in _dbContext.departments on ex.DepartmentId equals d.Id
                   join e in _dbContext.employees on ex.EmploeeId equals e.Id
                   select ex;
        }

        public void Insert(Expense entity)
        {
            expenses.Add(entity);
        }

        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Expense entity)
        {
            expenses.Update(entity);
        }
    }
}
