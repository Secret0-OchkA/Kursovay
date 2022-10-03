
using Domain.Model;

namespace Service
{
    public interface IServiceToEntity<Entity>
        where Entity : BaseDbEntity
    {
        Entity GetEntity();
    }
}
