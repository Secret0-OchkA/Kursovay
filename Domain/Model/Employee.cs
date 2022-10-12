using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class Employee : BaseDbEntity
    {
        public int UserId { get; set; }
        public virtual User user { get; set; } = null!;

        [JsonIgnore]
        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

        public virtual List<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
