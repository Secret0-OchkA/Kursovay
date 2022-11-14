using Domain.ApiModel;
using Domain.ApiModels;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class Expense : BaseDbEntity
    {
        public bool Confirm { get; set; } = false;
        public bool Valid { get; set; } = false;

        public int ExpenseTypeId { get; set; }
        [Required]
        public virtual ExpenseType expenseType { get; set; } = null!;

        public DateTime date { get; set; }
        public decimal amount { get; set; }

        public int DepartmentId { get; set; }
        [Required]
        public virtual Department department { get; set; } = null!;

        public int EmploeeId { get; set; }
        public virtual Employee? employee { get; set; }

        public static ExpenseView ToView(Expense entity) => new ExpenseView(entity);
    }
}
