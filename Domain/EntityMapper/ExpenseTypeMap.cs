using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Kursovay.Domain.EntityMapper
{
    public class ExpenseTypeMap : IEntityTypeConfiguration<ExpenseType>
    {
        public void Configure(EntityTypeBuilder<ExpenseType> builder)
        {
            builder.Property(et => et.Limit).HasColumnType("money");
        }
    }
}
