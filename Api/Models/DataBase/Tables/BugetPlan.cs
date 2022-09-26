namespace Kursovay.Tables
{
    public class BugetPlan
    {

        /* Необъединенное слияние из проекта "Tables"
        До:
                public int Id { get; set; }

                public int DeparmentId { get; set; }
        После:
                public int Id { get; set; }

                public int DeparmentId { get; set; }
        */
        public int Id { get; set; }

        public int DeparmentId { get; set; }
        public Department Department { get; set; } = null!;

        public decimal January { get; set; }
        public decimal February { get; set; }
        public decimal March { get; set; }
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal June { get; set; }
        public decimal July { get; set; }
        public decimal August { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal November { get; set; }
        public decimal December { get; set; }
    }
}
