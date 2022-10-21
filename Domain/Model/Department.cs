using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class Department : BaseDbEntity
    {
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public virtual List<Employee> employees { get; set; } = new List<Employee>();
        [JsonIgnore]
        public virtual List<Expense> Expenses { get; set; } = new List<Expense>();

        public decimal budget { get; set; }

        [JsonIgnore]
        public int BugetPlanId { get; set; }
        [JsonIgnore]
        public virtual BugetPlan bugetPlan { get; set; } = new BugetPlan();

        [JsonIgnore]
        public int CompanyId { get; set; }
        [JsonIgnore]
        [Required]
        public virtual Company Company { get; set; } = null!;
    }
}
