using Domain.Model;
using Repository.RepositoryPattern;

namespace Service
{
    public class Service<Entity> : IService<Entity>
        where Entity : BaseDbEntity
    {
        readonly IRepository<Entity> repository;
        public Service(IRepository<Entity> repository)
        {
            this.repository = repository;
        }

        public void Create(Entity entity)
        {
            repository.Insert(entity);
            repository.SaveChange();
        }
        public void Delete(int id)
        {
            repository.Delete(id);
            repository.SaveChange();
        }
        public void Update(Entity entity)
        {
            repository.Update(entity);
            repository.SaveChange();
        }

        public Entity? Get(int id)
        {
            return repository.Get(id);
        }
        public IEnumerable<Entity> GetAll()
        {
            return repository.GetAll();
        }
    }
}
