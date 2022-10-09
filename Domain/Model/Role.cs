namespace Domain.Model
{
    public class Role : BaseDbEntity
    {
        public string Name { get; set; } = string.Empty;

        public virtual List<Employee> users { get; set; } = new List<Employee>();
    }
}
