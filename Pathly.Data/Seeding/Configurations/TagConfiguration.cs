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
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        string userId = UserConfiguration.TestUserId;
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasData(
                new Tag { Id = 1, Name = "Work", UserId = userId },
                new Tag { Id = 2, Name = "Personal", UserId = userId },
                new Tag { Id = 2, Name = "C#", UserId = userId },
                new Tag { Id = 2, Name = "Gym", UserId = userId },
                new Tag { Id = 2, Name = "Frontend", UserId = userId },
                new Tag { Id = 2, Name = "Testing", UserId = userId },
                new Tag { Id = 2, Name = "Learning", UserId = userId },
                new Tag { Id = 2, Name = "Soft Skill", UserId = userId },
                new Tag { Id = 2, Name = "School", UserId = userId },
                new Tag { Id = 3, Name = "Urgent", UserId = userId }
            );
        }
    }
}
