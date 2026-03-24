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
    public class ActionItemConfiguration : IEntityTypeConfiguration<ActionItem>
    {
        string userId = SeedConstants.DemoUserId;
        public void Configure(EntityTypeBuilder<ActionItem> builder)
        {
            builder.HasData(
            // Actions for Roadmap 1
            new ActionItem { Id = 1, RoadmapId = 1, Title = "Master EF Core", Resources = "MS Docs, Pluralsight", IsCompleted = true, UserId = userId },
            new ActionItem { Id = 2, RoadmapId = 1, Title = "Learn Microservices", Resources = "Docker, RabbitMQ basics", IsCompleted = false, UserId = userId },
            new ActionItem { Id = 3, RoadmapId = 1, Title = "System Design Design Patterns", Resources = "GoF Book", IsCompleted = false, UserId = userId },

            // Actions for Roadmap 2
            new ActionItem { Id = 4, RoadmapId = 2, Title = "Implement AutoMapper", Resources = "AutoMapper Guide", IsCompleted = true, UserId = userId },
            new ActionItem { Id = 5, RoadmapId = 2, Title = "Setup Unit Tests", Resources = "xUnit, Moq", IsCompleted = false, UserId = userId },
            new ActionItem { Id = 6, RoadmapId = 2, Title = "Finalize UI", Resources = "Bootstrap, CSS", IsCompleted = false, UserId = userId },

            // Actions for Roadmap 3
            new ActionItem { Id = 7, RoadmapId = 3, Title = "Basic Syntax", IsCompleted = true, UserId = userId },
            new ActionItem { Id = 8, RoadmapId = 3, Title = "Loops and Arrays", IsCompleted = true, UserId = userId },
            new ActionItem { Id = 9, RoadmapId = 3, Title = "Classes and Objects", IsCompleted = true, UserId = userId }
        );
        }
    }
}
