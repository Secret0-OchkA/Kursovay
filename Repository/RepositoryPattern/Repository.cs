using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryPattern
{
    public class Repository<T> : IRepository<T> where T : BaseDbEntity
    {
        readonly ApplicationDbContext _dbContext;
        readonly DbSet<T> set;

        public Repository(ApplicationDbContext dbContext)
        { 
            _dbContext = dbContext;
            set = dbContext.Set<T>();
        }

        public void Delete(int id)
        {
            T? entity = set.SingleOrDefault(o => o.Id == id);

            if (entity == null) return;

            set.Remove(entity);
        }

        public T? Get(int id)
        {
            return set.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> Get(Func<T,bool> predicate)
        {
            return set.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return set;
        }

        public void Insert(T entity)
        {
            set.Add(entity);
        }

        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            set.Update(entity);
        }
    }
}

