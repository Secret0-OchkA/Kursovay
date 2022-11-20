using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityMapper
{
    public class ExpenseMap : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasOne(ex => ex.department)
                .WithMany(d => d.Expenses)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ex => ex.employee)
                .WithMany(e => e.Expenses)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ex => ex.expenseType)
                .WithMany(ext => ext.Expenses)
                .HasForeignKey(ex => ex.ExpenseTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.amount).HasColumnType("money");
        }
    }
}
