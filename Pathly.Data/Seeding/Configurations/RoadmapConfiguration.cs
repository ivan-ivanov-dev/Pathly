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
    public class RoadmapConfiguration : IEntityTypeConfiguration<Roadmap>
    {
        string userId = UserConfiguration.TestUserId;
        public void Configure(EntityTypeBuilder<Roadmap> builder)
        {
            builder.HasData(
                new Roadmap { Id = 1, GoalId = 1, Why = "To achieve financial independence", IdealOutcome = "Senior Dev Role", UserId = userId },
                new Roadmap { Id = 2, GoalId = 2, Why = "To build professional habits", IdealOutcome = "Perfectly coded app", UserId = userId },
                new Roadmap { Id = 3, GoalId = 3, Why = "Foundation is key", IdealOutcome = "Solid programming basics", UserId = userId }
            );
        }
    }
}
    
