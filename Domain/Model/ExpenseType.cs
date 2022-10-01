namespace Domain.Model
{
    public class ExpenseType : BaseDbEntity
    {
        public string Description { get; set; } = string.Empty;

        public decimal Limit { get; set; }
    }
}
