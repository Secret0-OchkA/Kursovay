using Domain.Model;
using Repository.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IService<Entity> where Entity : BaseDbEntity
    {
        void Create(Entity entity);
        void Delete(int id);
        void Update(Entity entity);

        Entity? Get(int id);
        IEnumerable<Entity> GetAll();
    }
}
