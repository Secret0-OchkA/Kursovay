using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class Employee : BaseDbEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        [JsonIgnore]
        public int RoleId { get; set; }
        [Required]
        public virtual Role Role { get; set; } = new Role();

        [JsonIgnore]
        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

        public virtual List<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
