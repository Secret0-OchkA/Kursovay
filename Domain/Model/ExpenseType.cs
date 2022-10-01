namespace Domain.Model
{
    public class ExpenseType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public decimal Limit { get; set; }
    }
}
