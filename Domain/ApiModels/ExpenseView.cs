using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.ApiModel
{
    public class ExpenseView : BaseViewEntity
    {
        public bool Confirm { get; set; } = false;
        public bool Valid { get; set; } = false;

        public DateTime date { get; set; }
        public decimal amount { get; set; }

        public int expenseTypeId = 0;
    }
}
