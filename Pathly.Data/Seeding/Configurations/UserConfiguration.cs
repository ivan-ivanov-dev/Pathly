using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pathly.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathly.Data.Seeding.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        private const string TestUserId = "3f2504e0-4f89-11d3-9a0c-0305e82c3301";
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
                SecurityStamp = Guid.NewGuid().ToString() // Важно за Identity
            };

            // Хешираме паролата ръчно
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Test1234!");

            builder.HasData(adminUser);
        }
    }
}
