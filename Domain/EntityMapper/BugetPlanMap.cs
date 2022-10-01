using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kursovay.Domain.EntityMapper
{
    public class BugetPlanMap : IEntityTypeConfiguration<BugetPlan>
    {
        public void Configure(EntityTypeBuilder<BugetPlan> builder)
        {
            builder.Property(bp => bp.January).HasColumnType("money");
            builder.Property(bp => bp.February).HasColumnType("money");
            builder.Property(bp => bp.March).HasColumnType("money");
            builder.Property(bp => bp.April).HasColumnType("money");
            builder.Property(bp => bp.May).HasColumnType("money");
            builder.Property(bp => bp.June).HasColumnType("money");
            builder.Property(bp => bp.July).HasColumnType("money");
            builder.Property(bp => bp.August).HasColumnType("money");
            builder.Property(bp => bp.September).HasColumnType("money");
            builder.Property(bp => bp.October).HasColumnType("money");
            builder.Property(bp => bp.November).HasColumnType("money");
            builder.Property(bp => bp.December).HasColumnType("money");
        }
    }
}
