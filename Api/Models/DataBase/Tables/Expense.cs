namespace Kursovay.Tables
{
    public class Expense
    {

        /* Необъединенное слияние из проекта "Tables"
        До:
                public int Id { get; set; }

                public int ExpenseTypeId { get; set; }
        После:
                public int Id { get; set; }

                public int ExpenseTypeId { get; set; }
        */
        public int Id { get; set; }

        public int ExpenseTypeId { get; set; }
        public ExpenseType expenseType { get; set; } = null!;

        public DateTime date { get; set; }
        public decimal amount { get; set; }

        public int DepartmentId { get; set; }
        public Department department { get; set; } = null!;

        public int EmploeeId { get; set; }
        public Employee employee { get; set; } = null!;
    }
}
