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
        public const string TestUserId = SeedConstants.testUserId;
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            var adminUser = new ApplicationUser
            {
                Id = TestUserId,
                UserName = "test@pathly.com",
                NormalizedUserName = "TEST@PATHLY.COM",
                Email = "test@pathly.com",
                NormalizedEmail = "TEST@PATHLY.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString() // Important for Identity
            };

            // Manually hash the password and set it to the PasswordHash property
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Test1234!");

            builder.HasData(adminUser);
        }
    }
}
