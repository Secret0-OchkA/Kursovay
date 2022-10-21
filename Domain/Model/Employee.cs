using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class Employee : BaseDbEntity
    {
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User user { get; set; } = null!;

        [JsonIgnore]
        public int? DepartmentId { get; set; }
        [JsonIgnore]
        public virtual Department? Department { get; set; }
        [JsonIgnore]
        public virtual List<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
