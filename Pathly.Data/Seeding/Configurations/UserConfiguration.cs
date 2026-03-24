using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pathly.DataModels;
using Pathly.GCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathly.Data.Seeding.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            // Demo User
            var normalUser = new ApplicationUser
            {
                Id = SeedConstants.testUserId,
                UserName = "test@pathly.com",
                NormalizedUserName = "TEST@PATHLY.COM",
                Email = "test@pathly.com",
                NormalizedEmail = "TEST@PATHLY.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            normalUser.PasswordHash = hasher.HashPassword(normalUser, "Test1234!");

            // Administrator
            var adminUser = new ApplicationUser
            {
                Id = SeedConstants.AdminUserId,
                UserName = "admin@pathly.com",
                NormalizedUserName = "ADMIN@PATHLY.COM",
                Email = "admin@pathly.com",
                NormalizedEmail = "ADMIN@PATHLY.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin123!");

            builder.HasData(normalUser, adminUser);
        }
    }
}
