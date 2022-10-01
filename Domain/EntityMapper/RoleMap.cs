using Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityMapper
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder) 
        {
            Role ownerCompanyRole = new Role {Id = 1,  Name = "owner"};
            Role accountantRole = new Role {Id = 2, Name ="accountant" };
            Role userRole = new Role { Id = 3, Name = "user"};

            builder.HasData(userRole,ownerCompanyRole,accountantRole);
        }
    }
}
