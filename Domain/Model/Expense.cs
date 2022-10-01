using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class Expense : BaseDbEntity
    {
        public bool Confirm { get; set; } = false;
        public bool Valid { get; set; } = false;

        public int ExpenseTypeId { get; set; }
        public virtual ExpenseType expenseType { get; set; } = null!;

        public DateTime date { get; set; }
        public decimal amount { get; set; }

        [JsonIgnore]
        public int DepartmentId { get; set; }
        public virtual Department department { get; set; } = null!;

        [JsonIgnore]
        public int EmploeeId { get; set; }
        public virtual Employee employee { get; set; } = null!;
    }
}
