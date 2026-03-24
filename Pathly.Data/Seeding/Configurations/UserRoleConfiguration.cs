using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pathly.GCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathly.Data.Seeding.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(new IdentityUserRole<string>
            {
                UserId = SeedConstants.AdminUserId,
                RoleId = SeedConstants.AdminRoleId
            });

            builder.HasData(new IdentityUserRole<string>
            {
                UserId = SeedConstants.DemoUserId,
                RoleId = SeedConstants.DemoRoleId
            });

        }
    }
}
