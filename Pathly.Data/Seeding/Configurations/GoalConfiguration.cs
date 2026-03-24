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
    public class GoalConfiguration : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            string userId = SeedConstants.DemoUserId;
            builder.HasData(new Goal[]
            {
                      
                // Goal1
                new Goal
                {
                    Id = 1,
                    Title = "Become a Senior .NET Developer",
                    ShortDescription = "Mastering advanced architecture and cloud services in the .NET ecosystem.",
                    TargetDate = DateTime.Parse("2026-12-31"),
                    IsActive = true,
                    UserId = userId 
                },

                // Goal2
                new Goal
                {
                    Id = 2,
                    Title = "Master Pathly Architecture",
                    ShortDescription = "Complete the implementation of AutoMapper and Seeding in the current project.",
                    TargetDate = DateTime.Now.AddMonths(1),
                    IsActive = true,
                    UserId = userId
                },

                // Goal3
                new Goal
                {
                    Id = 3,
                    Title = "SoftUni Fundamentals Module",
                    ShortDescription = "Successfully finished the basics of C# programming.",
                    TargetDate = DateTime.Now.AddMonths(-5),
                    IsActive = false,
                    UserId = userId
                }
            });
        }
    }
}
