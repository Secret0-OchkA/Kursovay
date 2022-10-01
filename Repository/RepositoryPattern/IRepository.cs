using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryPattern
{
    public interface IRepository<T> where T : BaseDbEntity
    {
        IEnumerable<T> GetAll();

        T? Get(int id);
        IEnumerable<T> Get(Func<T, bool> predicate);

        void Update(T entity);
        void Delete(int id);
        void Insert(T entity);
        void SaveChange();
    }
}
