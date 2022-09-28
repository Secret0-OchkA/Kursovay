namespace Kursovay.Tables
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<Employee> employees { get; set; } = new List<Employee>();

        public decimal budget { get; set; }
    }
}
