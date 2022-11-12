using Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.ApiModel
{
    public class ExpenseTypeView : BaseViewEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Limit { get; set; }

        public ExpenseTypeView(ExpenseType expenseType) : base(expenseType)
        {
            this.Name = expenseType.Name;
            this.Description = expenseType.Description;
            this.Limit = expenseType.Limit;
        }
    }
}
