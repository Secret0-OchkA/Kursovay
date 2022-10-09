using Domain.Model;

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
