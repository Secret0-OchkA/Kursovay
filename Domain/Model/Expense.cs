using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class Expense
    {
        public int Id { get; set; }

        public int ExpenseTypeId { get; set; }
        public ExpenseType expenseType { get; set; } = null!;

        public DateTime date { get; set; }
        public decimal amount { get; set; }

        [JsonIgnore]
        public int DepartmentId { get; set; }
        public Department department { get; set; } = null!;

        [JsonIgnore]
        public int EmploeeId { get; set; }
        public Employee employee { get; set; } = null!;
    }
}
