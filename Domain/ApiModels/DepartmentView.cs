using Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.ApiModel
{
    public class DepartmentView : BaseViewEntity
    {
        public string Name { get; set; } = string.Empty;

        public decimal budget { get; set; }

        public DepartmentView(Department department) : base(department)
        {
            this.Name = department.Name;
            this.budget = department.budget;
        }
    }
}
