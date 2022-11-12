using Domain.Model;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace Domain.ApiModel
{
    public class BaseViewEntity
    {
        public int Id { get; set; }

        public BaseViewEntity(BaseDbEntity dbEntity) => this.Id = dbEntity.Id;
    }
}
