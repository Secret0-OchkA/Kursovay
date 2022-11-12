using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.ApiModel
{
    public class EmployeeView : BaseViewEntity
    {
        public string Name { get; set; } = "";
    }
}
