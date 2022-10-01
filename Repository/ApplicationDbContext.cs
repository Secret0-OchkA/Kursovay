using Domain.Model;
using Kursovay.Domain.EntityMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Department> departments { get; set; } = null!;
        public DbSet<Employee> employees { get; set; } = null!;
        public DbSet<Expense> expenses { get; set; } = null!;
        public DbSet<ExpenseType> expenseTypes { get; set; } = null!;
        public DbSet<BugetPlan> bugetPlans { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentMap());
            modelBuilder.ApplyConfiguration(new BugetPlanMap());
            modelBuilder.ApplyConfiguration(new EmployeeMap());
            modelBuilder.ApplyConfiguration(new ExpenseMap());
            modelBuilder.ApplyConfiguration(new ExpenseTypeMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
