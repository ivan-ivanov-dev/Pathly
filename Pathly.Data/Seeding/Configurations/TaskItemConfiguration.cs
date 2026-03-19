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
    public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        string userId = UserConfiguration.TestUserId;
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            var tasks = new List<TaskItem>();
            int taskId = 1;
            for (int actionId = 1; actionId <= 9; actionId++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    tasks.Add(new TaskItem
                    {
                        Id = taskId++,
                        Title = $"Task {j} for Action {actionId}",
                        Description = "Seed description",
                        Priority = (TaskPriority)(taskId % 4 + 1), // Different priority levels
                        IsCompleted = taskId % 2 == 0,
                        CreatedOn = DateTime.Now.AddDays(-10),
                        DueDate = DateTime.Now.AddDays(5),
                        ActionId = actionId,
                        UserId = userId
                    });
                }
            }
            for (int i = 1; i <= 5; i++)
            {
                tasks.Add(new TaskItem
                {
                    Id = taskId++,
                    Title = $"General Task {i}",
                    Description = "Unlinked task description",
                    Priority = TaskPriority.Medium,
                    IsCompleted = false,
                    CreatedOn = DateTime.Now,
                    UserId = userId
                });
            }

            builder.HasData(tasks);
        }
    }
}
