using System.Text.Json.Serialization;

namespace Domain.ApiModel
{
    public class CompanyView : BaseViewEntity
    {
        public string Name { get; set; } = string.Empty;
    }
}
