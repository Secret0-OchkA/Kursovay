using Domain.Model;
using Repository.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public abstract class BaseService<Entity>
        where Entity : BaseDbEntity
    {
        protected readonly IRepository<Entity> repository;
        public BaseService(IRepository<Entity> repository)
        {
            this.repository = repository;
        }
         
        public virtual void Create(Entity entity)
        {
            repository.Insert(entity);
            repository.SaveChange();
        }

        public virtual void Delete(int id)
        {
            repository.Delete(id);
            repository.SaveChange();
        }

        public virtual Entity Get(int id)
        { 
            Entity? entity = repository.Get(id);
            if (entity == null) throw new NullReferenceException();

            return entity;
        }
    }
}
