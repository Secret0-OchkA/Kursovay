namespace Kursovay.Tables
{
    public class Department
    {
        public int Id { get; set; }

        /* Необъединенное слияние из проекта "Tables"
        До:
                public string Name { get; set; } = string.Empty;

                public List<Employee> employees { get; set; } = new List<Employee>();
        После:
                public string Name { get; set; } = string.Empty;

                public List<Employee> employees { get; set; } = new List<Employee>();
        */
        public string Name { get; set; } = string.Empty;

        public List<Employee> employees { get; set; } = new List<Employee>();

        public decimal budget { get; set; }
    }
}
