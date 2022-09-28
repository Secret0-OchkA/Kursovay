using System.Text.Json.Serialization;

namespace Kursovay.Tables
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
