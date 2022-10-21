using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class ExpenseType : BaseDbEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Limit { get; set; }
        [JsonIgnore]
        public virtual List<Expense> Expenses { get; set; } = new List<Expense>();

        [JsonIgnore]
        public int CompanyId { get; set; }
        [JsonIgnore]
        [Required]
        public virtual Company Company { get; set; } = null!;
    }
}
