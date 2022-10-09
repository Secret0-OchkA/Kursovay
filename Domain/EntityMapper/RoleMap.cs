using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityMapper
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            Role ownerCompanyRole = new Role { Id = 1, Name = "owner" };
            Role accountantRole = new Role { Id = 2, Name = "accountant" };
            Role userRole = new Role { Id = 3, Name = "user" };

            builder.HasData(userRole, ownerCompanyRole, accountantRole);
        }
    }
}
