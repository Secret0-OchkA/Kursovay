namespace Domain.Model
{
    public class Department : BaseDbEntity
    {
        public string Name { get; set; } = string.Empty;

        public virtual List<Employee> employees { get; set; } = new List<Employee>();

        public decimal budget { get; set; }

        public int BugetPlanId { get; set; }
        public virtual BugetPlan bugetPlan { get; set; } = new BugetPlan();

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; } = null!;
    }
}
