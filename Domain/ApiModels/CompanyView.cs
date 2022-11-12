
using Domain.Model;
using System.Text.Json.Serialization;

namespace Domain.ApiModel
{
    public class CompanyView : BaseViewEntity
    {
        public string Name { get; set; } = string.Empty;

        public CompanyView() { }
        public CompanyView(Company company) : base(company) => this.Name = company.Name;
    }
}
