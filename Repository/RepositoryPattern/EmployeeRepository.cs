using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryPattern
{
    public class EmployeeRepository : IRepository<Employee>
    {
        readonly ApplicationDbContext _dbContext;
        readonly DbSet<Employee> employees;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            employees = _dbContext.Set<Employee>();
        }

        public void Delete(int id)
        {
            Employee? bugetPlan = employees.SingleOrDefault(o => o.Id == id);

            if (bugetPlan == null) return;

            employees.Remove(bugetPlan);
        }

        public Employee? Get(int id)
        {
            return (from e in employees
                    join d in _dbContext.departments on e.DepartmentId equals d.Id
                    where e.Id == id
                    select e).FirstOrDefault();
        }

        public IQueryable<Employee> GetAll()
        {
            return from e in employees
                   join d in _dbContext.departments on e.DepartmentId equals d.Id
                   select e;
        }

        public void Insert(Employee entity)
        {
            employees.Add(entity);
        }

        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Employee entity)
        {
            employees.Update(entity);
        }
    }
}
