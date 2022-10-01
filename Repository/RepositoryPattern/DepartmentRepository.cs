using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryPattern
{
    public class DepartmentRepository : IRepository<Department>
    {
        readonly ApplicationDbContext _dbContext;
        readonly DbSet<Department> departments;

        public DepartmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            departments = _dbContext.Set<Department>();
        }

        public void Delete(int id)
        {
            Department? bugetPlan = departments.SingleOrDefault(o => o.Id == id);

            if (bugetPlan == null) return;

            departments.Remove(bugetPlan);
        }

        public Department? Get(int id)
        {
            return (from d in departments
                    join e in _dbContext.employees on d.Id equals e.DepartmentId
                    where d.Id == id
                    select d).FirstOrDefault();
        }

        public IQueryable<Department> GetAll()
        {
            return from d in departments
                   join e in _dbContext.employees on d.Id equals e.DepartmentId
                   select d;
        }

        public void Insert(Department entity)
        {
            departments.Add(entity);
        }

        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Department entity)
        {
            departments.Update(entity);
        }
    }
}
