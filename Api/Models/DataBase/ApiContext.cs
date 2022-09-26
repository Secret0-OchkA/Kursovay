using Kursovay.Tables;
using Microsoft.EntityFrameworkCore;

namespace Kursovay.DataBase
{
    public class ApiContext : DbContext
    {
        public DbSet<Department> departments { get; set; } = null!;
        public DbSet<Employee> employees { get; set; } = null!;
        public DbSet<Expense> expenses { get; set; } = null!;
        public DbSet<ExpenseType> expenseTypes { get; set; } = null!;
        public DbSet<BugetPlan> bugetPlans { get; set; } = null!;

        /// <summary>
        /// Create instance
        /// </summary>
        /// <param name="options"></param>
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BugetPlan>().Property(bp => bp.January).HasColumnType("money");
            modelBuilder.Entity<BugetPlan>().Property(bp => bp.February).HasColumnType("money");
            modelBuilder.Entity<BugetPlan>().Property(bp => bp.March).HasColumnType("money");
            modelBuilder.Entity<BugetPlan>().Property(bp => bp.April).HasColumnType("money");
            modelBuilder.Entity<BugetPlan>().Property(bp => bp.May).HasColumnType("money");
            modelBuilder.Entity<BugetPlan>().Property(bp => bp.June).HasColumnType("money");
            modelBuilder.Entity<BugetPlan>().Property(bp => bp.July).HasColumnType("money");
            modelBuilder.Entity<BugetPlan>().Property(bp => bp.August).HasColumnType("money");
            modelBuilder.Entity<BugetPlan>().Property(bp => bp.September).HasColumnType("money");
            modelBuilder.Entity<BugetPlan>().Property(bp => bp.October).HasColumnType("money");
            modelBuilder.Entity<BugetPlan>().Property(bp => bp.November).HasColumnType("money");
            modelBuilder.Entity<BugetPlan>().Property(bp => bp.December).HasColumnType("money");

            modelBuilder.Entity<Department>().Property(d => d.budget).HasColumnType("money");

            modelBuilder.Entity<ExpenseType>().Property(et => et.Limit).HasColumnType("money");

            modelBuilder.Entity<Expense>().Property(e => e.amount).HasColumnType("money");

            base.OnModelCreating(modelBuilder);
        }
    }
}
