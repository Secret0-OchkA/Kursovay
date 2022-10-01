using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class Employee : User
    {
        [JsonIgnore]
        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
    }
}
