using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.ApiModel
{
    public class ExpenseTypeView : BaseViewEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Limit { get; set; }
    }
}
