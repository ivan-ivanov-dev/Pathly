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
    public class TaskTagConfiguration : IEntityTypeConfiguration<TaskTag>
    {         
        public void Configure(EntityTypeBuilder<TaskTag> builder)
        {
            builder.HasData(
            new TaskTag { TaskId = 1, TagId = 1 }, // Task 1 is Work
            new TaskTag { TaskId = 1, TagId = 10 }, // Task 1 is Urgent
            new TaskTag { TaskId = 2, TagId = 3 }, // Task 2 is C#
            new TaskTag { TaskId = 4, TagId = 7 }, // Task 4 is Learning
            new TaskTag { TaskId = 10, TagId = 5 } // Task 10 is Frontend
            );
        }
    }
}
