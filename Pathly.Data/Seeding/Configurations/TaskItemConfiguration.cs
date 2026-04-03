using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pathly.DataModels;
using Pathly.GCommon;

namespace Pathly.Data.Seeding.Configurations
{
    public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        string userId = SeedConstants.DemoUserId;

        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            var tasks = new List<TaskItem>();
            int taskId = 1;

            int todoPos = 0;
            int progressPos = 0;
            int donePos = 0;

            //Linked tasks logic
            for (int actionId = 1; actionId <= 9; actionId++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    var status = (DataModels.TaskStatus)((taskId % 3) + 1);

                    bool isDone = status == DataModels.TaskStatus.Done;

                    int position = status switch
                    {
                        DataModels.TaskStatus.Todo => todoPos++,
                        DataModels.TaskStatus.InProgress => progressPos++,
                        _ => donePos++
                    };

                    tasks.Add(new TaskItem
                    {
                        Id = taskId++,
                        Title = $"Task {j} for Action {actionId}",
                        Description = "Strategic seed description",
                        Priority = (TaskPriority)(taskId % 4 + 1),
                        Status = status,
                        IsCompleted = isDone,
                        Position = position,
                        CreatedOn = DateTime.UtcNow.AddDays(-10),
                        DueDate = DateTime.UtcNow.AddDays(5),
                        ActionId = actionId,
                        UserId = userId
                    });
                }
            }

            // General tasks logic
            for (int i = 1; i <= 5; i++)
            {
                tasks.Add(new TaskItem
                {
                    Id = taskId++,
                    Title = $"General Task {i}",
                    Description = "Unlinked high-level objective",
                    Priority = TaskPriority.Medium,
                    Status = DataModels.TaskStatus.Todo,
                    IsCompleted = false,
                    Position = todoPos++,
                    CreatedOn = DateTime.UtcNow,
                    UserId = userId
                });
            }

            builder.HasData(tasks);
        }
    }
}