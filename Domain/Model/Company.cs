using Domain.ApiModel;
using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class Company : BaseDbEntity
    {
        public string Name { get; set; } = string.Empty;
        public virtual List<Department> departments { get; set; } = new List<Department>();

        public static CompanyView ToView(Company entity) => new CompanyView(entity);
    }
}
