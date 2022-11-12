using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class ExpenseType : BaseDbEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Limit { get; set; }
        public virtual List<Expense> Expenses { get; set; } = new List<Expense>();

        public int CompanyId { get; set; }
        [Required]
        public virtual Company Company { get; set; } = null!;
    }
}
