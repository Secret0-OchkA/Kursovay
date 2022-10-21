using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class Role : BaseDbEntity
    {
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public virtual List<User> users { get; set; } = new List<User>();
    }
}
