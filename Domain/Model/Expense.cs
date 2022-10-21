using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class Expense : BaseDbEntity
    {
        public bool Confirm { get; set; } = false;
        public bool Valid { get; set; } = false;

        [JsonIgnore]
        public int ExpenseTypeId { get; set; }
        [JsonIgnore]
        [Required]
        public virtual ExpenseType expenseType { get; set; } = null!;

        public DateTime date { get; set; }
        public decimal amount { get; set; }

        [JsonIgnore]
        public int DepartmentId { get; set; }
        [JsonIgnore]
        [Required]
        public virtual Department department { get; set; } = null!;

        [JsonIgnore]
        public int EmploeeId { get; set; }
        [JsonIgnore]
        public virtual Employee? employee { get; set; }
    }
}
