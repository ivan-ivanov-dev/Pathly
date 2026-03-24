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
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        string userId = SeedConstants.DemoUserId;
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasData(
                new Tag { Id = 1, Name = "Work", UserId = userId },
                new Tag { Id = 2, Name = "Personal", UserId = userId },
                new Tag { Id = 3, Name = "C#", UserId = userId },
                new Tag { Id = 4, Name = "Gym", UserId = userId },
                new Tag { Id = 5, Name = "Frontend", UserId = userId },
                new Tag { Id = 6, Name = "Testing", UserId = userId },
                new Tag { Id = 7, Name = "Learning", UserId = userId },
                new Tag { Id = 8, Name = "Soft Skill", UserId = userId },
                new Tag { Id = 9, Name = "School", UserId = userId },
                new Tag { Id = 10, Name = "Urgent", UserId = userId }
            );
        }
    }
}
