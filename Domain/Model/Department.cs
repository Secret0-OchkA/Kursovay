using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class Department : BaseDbEntity
    {
        public string Name { get; set; } = string.Empty;

        public virtual List<Employee> employees { get; set; } = new List<Employee>();
        public virtual List<Expense> Expenses { get; set; } = new List<Expense>();

        public decimal budget { get; set; }

        [JsonIgnore]
        public int BugetPlanId { get; set; }
        public virtual BugetPlan bugetPlan { get; set; } = new BugetPlan();

        [JsonIgnore]
        public int CompanyId { get; set; }
        [Required]
        public virtual Company Company { get; set; } = null!;
    }
}
