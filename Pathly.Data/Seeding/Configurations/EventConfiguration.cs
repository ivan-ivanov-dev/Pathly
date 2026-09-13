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
        private int _nextId = 1;

        public void Configure(EntityTypeBuilder<Event> builder)
        {
            var events = new List<Event>();

            // --- APRIL 2026 ---

            // 1. Kickoff meeting
            events.Add(CreateEvent("Q2 Kickoff", "Planning for the new quarter",
                new DateTime(2026, 4, 1, 9, 0, 0, DateTimeKind.Utc), 2, "#4e73df", goalId: 1));

            // 2. Early morning deep work
            events.Add(CreateEvent("Deep Work: Coding", "No interruptions allowed",
                new DateTime(2026, 4, 3, 8, 0, 0, DateTimeKind.Utc), 4, "#1cc88a"));

            // 3. Weekend workshop (Multi-day)
            events.Add(new Event {
                Id = _nextId++, Title = "Productivity Seminar", Start = new DateTime(2026, 4, 11, 9, 0, 0, DateTimeKind.Utc),
                End = new DateTime(2026, 4, 12, 17, 0, 0, DateTimeKind.Utc), ColorHex = "#f6c23e", IsAllDay = false, UserId = SeedConstants.DemoUserId
            });

            // 4. Mid-month review
            events.Add(CreateEvent("Mid-April Check-in", "Sync with the roadmap",
                new DateTime(2026, 4, 15, 14, 0, 0, DateTimeKind.Utc), 1, "#36b9cc"));

            // 5. Easter Holiday (All Day)
            events.Add(new Event {
                Id = _nextId++, Title = "Easter Sunday", Start = new DateTime(2026, 4, 19, 0, 0, 0, DateTimeKind.Utc),
                End = new DateTime(2026, 4, 19, 0, 0, 0, DateTimeKind.Utc), ColorHex = "#e74a3b", IsAllDay = true, UserId = SeedConstants.DemoUserId
            });

            // 6-8. A busy Tuesday (Testing vertical stacking)
            events.Add(CreateEvent("Morning Sync", "Team updates", new DateTime(2026, 4, 21, 9, 0, 0, DateTimeKind.Utc), 1, "#5a5c69"));
            events.Add(CreateEvent("Lunch & Learn", "New tech stack", new DateTime(2026, 4, 21, 12, 0, 0, DateTimeKind.Utc), 1, "#6610f2"));
            events.Add(CreateEvent("Client Call", "Project Alpha", new DateTime(2026, 4, 21, 15, 0, 0, DateTimeKind.Utc), 2, "#4e73df"));

            // 9. Late night maintenance
            events.Add(CreateEvent("DB Migration", "Updating schema", new DateTime(2026, 4, 28, 23, 0, 0, DateTimeKind.Utc), 2, "#858796"));

            // 10. End of month cleanup
            events.Add(CreateEvent("April Task Sweep", "Clearing the backlog",
                new DateTime(2026, 4, 30, 10, 0, 0, DateTimeKind.Utc), 3, "#1cc88a", taskId: 10));

            // --- MAY 2026 ---

            // 11. May Day (All Day)
            events.Add(new Event {
                Id = _nextId++, Title = "Labour Day Holiday", Start = new DateTime(2026, 5, 1, 0, 0, 0, DateTimeKind.Utc),
                End = new DateTime(2026, 5, 1, 0, 0, 0, DateTimeKind.Utc), ColorHex = "#e74a3b", IsAllDay = true, UserId = SeedConstants.DemoUserId
            });

            // 12-14. "The Triple Threat" (Overlapping events to test UI collision)
            events.Add(CreateEvent("Focus Block A", "Design work", new DateTime(2026, 5, 4, 10, 0, 0, DateTimeKind.Utc), 3, "#36b9cc"));
            events.Add(CreateEvent("Emergency Meeting", "Bug fix", new DateTime(2026, 5, 4, 11, 0, 0, DateTimeKind.Utc), 1, "#e74a3b"));
            events.Add(CreateEvent("Quick Sync", "Daily standup", new DateTime(2026, 5, 4, 10, 30, 0, DateTimeKind.Utc), 0.5, "#5a5c69"));

            // 15. Goal Milestone
            events.Add(CreateEvent("Goal #2 Milestone", "Celebrating achievement",
                new DateTime(2026, 5, 12, 16, 0, 0, DateTimeKind.Utc), 1, "#6610f2", goalId: 2));

            // 16. Long-running Task
            events.Add(new Event {
                Id = _nextId++, Title = "Learning Week", Description = "Upskilling in .NET Testing",
                Start = new DateTime(2026, 5, 18, 9, 0, 0, DateTimeKind.Utc), End = new DateTime(2026, 5, 22, 17, 0, 0, DateTimeKind.Utc),
                ColorHex = "#1cc88a", IsAllDay = true, UserId = SeedConstants.DemoUserId
            });

            // 17. Afternoon Workshop
            events.Add(CreateEvent("UX Workshop", "Wireframing session", new DateTime(2026, 5, 25, 13, 0, 0, DateTimeKind.Utc), 4, "#f6c23e"));

            // 18. Recurring Task Simulation
            events.Add(CreateEvent("Weekly Report", "Friday Wrap-up", new DateTime(2026, 5, 29, 15, 0, 0, DateTimeKind.Utc), 1, "#858796", taskId: 5));

            // 19. Final Review
            events.Add(CreateEvent("May Summary", "Reviewing May performance", new DateTime(2026, 5, 31, 11, 0, 0, DateTimeKind.Utc), 2, "#4e73df"));

            // 20. Night Owl Coding
            events.Add(CreateEvent("Side Project Push", "Late night productivity", new DateTime(2026, 5, 31, 22, 0, 0, DateTimeKind.Utc), 3, "#36b9cc"));

            builder.HasData(events);
        }

        // Helper method to keep the code clean
        private Event CreateEvent(string title, string desc, DateTime start, double hours, string color, int? taskId = null, int? goalId = null)
        {
            return new Event
            {
                Id = _nextId++,
                Title = title,
                Description = desc,
                Start = start,
                End = start.AddHours(hours),
                ColorHex = color,
                IsAllDay = false,
                UserId = SeedConstants.DemoUserId,
                TaskId = taskId,
                GoalId = goalId
            };
        }
    }
}
