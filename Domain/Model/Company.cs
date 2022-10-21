using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class Company : BaseDbEntity
    {
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public virtual List<Department> departments { get; set; } = new List<Department>();
    }
}
