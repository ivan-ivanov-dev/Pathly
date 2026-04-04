using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pathly.DataModels;
using Pathly.GCommon;
using System;
using System.Collections.Generic;

namespace Pathly.Data.Seeding.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            string userId = SeedConstants.DemoUserId;
            var events = new List<Event>();
            int idCounter = 1;

            // --- APRIL 2026 ---
            
            // 1. Kickoff meeting
            events.Add(CreateEvent(idCounter++, "Q2 Kickoff", "Planning for the new quarter", 
                new DateTime(2026, 4, 1, 9, 0, 0), 2, "#4e73df", userId, goalId: 1));

            // 2. Early morning deep work
            events.Add(CreateEvent(idCounter++, "Deep Work: Coding", "No interruptions allowed", 
                new DateTime(2026, 4, 3, 8, 0, 0), 4, "#1cc88a", userId));

            // 3. Weekend workshop (Multi-day)
            events.Add(new Event {
                Id = idCounter++, Title = "Productivity Seminar", Start = new DateTime(2026, 4, 11, 9, 0, 0),
                End = new DateTime(2026, 4, 12, 17, 0, 0), ColorHex = "#f6c23e", IsAllDay = false, UserId = userId
            });

            // 4. Mid-month review
            events.Add(CreateEvent(idCounter++, "Mid-April Check-in", "Sync with the roadmap", 
                new DateTime(2026, 4, 15, 14, 0, 0), 1, "#36b9cc", userId));

            // 5. Easter Holiday (All Day)
            events.Add(new Event {
                Id = idCounter++, Title = "Easter Sunday", Start = new DateTime(2026, 4, 19),
                End = new DateTime(2026, 4, 19), ColorHex = "#e74a3b", IsAllDay = true, UserId = userId
            });

            // 6-8. A busy Tuesday (Testing vertical stacking)
            events.Add(CreateEvent(idCounter++, "Morning Sync", "Team updates", new DateTime(2026, 4, 21, 9, 0, 0), 1, "#5a5c69", userId));
            events.Add(CreateEvent(idCounter++, "Lunch & Learn", "New tech stack", new DateTime(2026, 4, 21, 12, 0, 0), 1, "#6610f2", userId));
            events.Add(CreateEvent(idCounter++, "Client Call", "Project Alpha", new DateTime(2026, 4, 21, 15, 0, 0), 2, "#4e73df", userId));

            // 9. Late night maintenance
            events.Add(CreateEvent(idCounter++, "DB Migration", "Updating schema", new DateTime(2026, 4, 28, 23, 0, 0), 2, "#858796", userId));

            // 10. End of month cleanup
            events.Add(CreateEvent(idCounter++, "April Task Sweep", "Clearing the backlog", 
                new DateTime(2026, 4, 30, 10, 0, 0), 3, "#1cc88a", userId, taskId: 10));

            // --- MAY 2026 ---

            // 11. May Day (All Day)
            events.Add(new Event {
                Id = idCounter++, Title = "Labour Day Holiday", Start = new DateTime(2026, 5, 1),
                End = new DateTime(2026, 5, 1), ColorHex = "#e74a3b", IsAllDay = true, UserId = userId
            });

            // 12-14. "The Triple Threat" (Overlapping events to test UI collision)
            events.Add(CreateEvent(idCounter++, "Focus Block A", "Design work", new DateTime(2026, 5, 4, 10, 0, 0), 3, "#36b9cc", userId));
            events.Add(CreateEvent(idCounter++, "Emergency Meeting", "Bug fix", new DateTime(2026, 5, 4, 11, 0, 0), 1, "#e74a3b", userId));
            events.Add(CreateEvent(idCounter++, "Quick Sync", "Daily standup", new DateTime(2026, 5, 4, 10, 30, 0), 0.5, "#5a5c69", userId));

            // 15. Goal Milestone
            events.Add(CreateEvent(idCounter++, "Goal #2 Milestone", "Celebrating achievement", 
                new DateTime(2026, 5, 12, 16, 0, 0), 1, "#6610f2", userId, goalId: 2));

            // 16. Long-running Task
            events.Add(new Event {
                Id = idCounter++, Title = "Learning Week", Description = "Upskilling in .NET Testing",
                Start = new DateTime(2026, 5, 18, 9, 0, 0), End = new DateTime(2026, 5, 22, 17, 0, 0),
                ColorHex = "#1cc88a", IsAllDay = true, UserId = userId
            });

            // 17. Afternoon Workshop
            events.Add(CreateEvent(idCounter++, "UX Workshop", "Wireframing session", new DateTime(2026, 5, 25, 13, 0, 0), 4, "#f6c23e", userId));

            // 18. Recurring Task Simulation
            events.Add(CreateEvent(idCounter++, "Weekly Report", "Friday Wrap-up", new DateTime(2026, 5, 29, 15, 0, 0), 1, "#858796", userId, taskId: 5));

            // 19. Final Review
            events.Add(CreateEvent(idCounter++, "May Summary", "Reviewing May performance", new DateTime(2026, 5, 31, 11, 0, 0), 2, "#4e73df", userId));

            // 20. Night Owl Coding
            events.Add(CreateEvent(idCounter++, "Side Project Push", "Late night productivity", new DateTime(2026, 5, 31, 22, 0, 0), 3, "#36b9cc", userId));

            builder.HasData(events);
        }

        // Helper method to keep the code clean
        private Event CreateEvent(int id, string title, string desc, DateTime start, double hours, string color, string userId, int? taskId = null, int? goalId = null)
        {
            return new Event
            {
                Id = id,
                Title = title,
                Description = desc,
                Start = start,
                End = start.AddHours(hours),
                ColorHex = color,
                IsAllDay = false,
                UserId = userId,
                TaskId = taskId,
                GoalId = goalId
            };
        }
    }
}