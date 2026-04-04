using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pathly.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2504e0-4f89-11d3-9a0c-0305e82c3301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2eb3044-b407-4fe7-a4da-8892d64419b8", "AQAAAAIAAYagAAAAELRWjfLI2gE/0g6NsVobuFNlWqdqvrlUqLkJHbWzoxUu0wGn4u7Vr9PVuIwgpRfvhQ==", "b89737f1-5589-432c-aeec-9c05c4d83016" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9267e94-405e-4781-a3da-e4f1a4116b20", "AQAAAAIAAYagAAAAEINJJfWu7MuHRXuAus7Sh9z2xHIYQT+U7Srhj3kGGzdEP8CyO91AhrVwLPAutJKqSQ==", "b95646c0-2b7c-4f92-9ae3-687779b383f0" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "ColorHex", "CreatedOn", "Description", "End", "GoalId", "IsAllDay", "Location", "Start", "TaskId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "#4e73df", new DateTime(2026, 4, 4, 0, 18, 59, 867, DateTimeKind.Utc).AddTicks(1939), "Planning for the new quarter", new DateTime(2026, 4, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, false, null, new DateTime(2026, 4, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "Q2 Kickoff", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 2, "#1cc88a", new DateTime(2026, 4, 4, 0, 18, 59, 867, DateTimeKind.Utc).AddTicks(1946), "No interruptions allowed", new DateTime(2026, 4, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(2026, 4, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), null, "Deep Work: Coding", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 3, "#f6c23e", new DateTime(2026, 4, 4, 0, 18, 59, 867, DateTimeKind.Utc).AddTicks(1948), null, new DateTime(2026, 4, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(2026, 4, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "Productivity Seminar", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 4, "#36b9cc", new DateTime(2026, 4, 4, 0, 18, 59, 867, DateTimeKind.Utc).AddTicks(1951), "Sync with the roadmap", new DateTime(2026, 4, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(2026, 4, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), null, "Mid-April Check-in", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 5, "#e74a3b", new DateTime(2026, 4, 4, 0, 18, 59, 867, DateTimeKind.Utc).AddTicks(1952), null, new DateTime(2026, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, null, new DateTime(2026, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Easter Sunday", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 6, "#5a5c69", new DateTime(2026, 4, 4, 0, 18, 59, 867, DateTimeKind.Utc).AddTicks(1959), "Team updates", new DateTime(2026, 4, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(2026, 4, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "Morning Sync", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 7, "#6610f2", new DateTime(2026, 4, 4, 0, 18, 59, 867, DateTimeKind.Utc).AddTicks(1960), "New tech stack", new DateTime(2026, 4, 21, 13, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(2026, 4, 21, 12, 0, 0, 0, DateTimeKind.Unspecified), null, "Lunch & Learn", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 8, "#4e73df", new DateTime(2026, 4, 4, 0, 18, 59, 867, DateTimeKind.Utc).AddTicks(1962), "Project Alpha", new DateTime(2026, 4, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(2026, 4, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), null, "Client Call", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 9, "#858796", new DateTime(2026, 4, 4, 0, 18, 59, 867, DateTimeKind.Utc).AddTicks(1963), "Updating schema", new DateTime(2026, 4, 29, 1, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(2026, 4, 28, 23, 0, 0, 0, DateTimeKind.Unspecified), null, "DB Migration", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 10, "#1cc88a", new DateTime(2026, 4, 4, 0, 18, 59, 867, DateTimeKind.Utc).AddTicks(1966), "Clearing the backlog", new DateTime(2026, 4, 30, 13, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(2026, 4, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), 10, "April Task Sweep", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 11, "#e74a3b", new DateTime(2026, 4, 4, 0, 18, 59, 867, DateTimeKind.Utc).AddTicks(1967), null, new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, null, new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Labour Day Holiday", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 12, "#36b9cc", new DateTime(2026, 4, 4, 0, 18, 59, 867, DateTimeKind.Utc).AddTicks(1969), "Design work", new DateTime(2026, 5, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(2026, 5, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Focus Block A", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 13, "#e74a3b", new DateTime(2026, 4, 4, 0, 18, 59, 867, DateTimeKind.Utc).AddTicks(1970), "Bug fix", new DateTime(2026, 5, 4, 12, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(2026, 5, 4, 11, 0, 0, 0, DateTimeKind.Unspecified), null, "Emergency Meeting", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 14, "#5a5c69", new DateTime(2026, 4, 4, 0, 18, 59, 867, DateTimeKind.Utc).AddTicks(1971), "Daily standup", new DateTime(2026, 5, 4, 11, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(2026, 5, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), null, "Quick Sync", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 15, "#6610f2", new DateTime(2026, 4, 4, 0, 18, 59, 867, DateTimeKind.Utc).AddTicks(1973), "Celebrating achievement", new DateTime(2026, 5, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), 2, false, null, new DateTime(2026, 5, 12, 16, 0, 0, 0, DateTimeKind.Unspecified), null, "Goal #2 Milestone", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 16, "#1cc88a", new DateTime(2026, 4, 4, 0, 18, 59, 867, DateTimeKind.Utc).AddTicks(1974), "Upskilling in .NET Testing", new DateTime(2026, 5, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), null, true, null, new DateTime(2026, 5, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "Learning Week", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 17, "#f6c23e", new DateTime(2026, 4, 4, 0, 18, 59, 867, DateTimeKind.Utc).AddTicks(1976), "Wireframing session", new DateTime(2026, 5, 25, 17, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(2026, 5, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), null, "UX Workshop", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 18, "#858796", new DateTime(2026, 4, 4, 0, 18, 59, 867, DateTimeKind.Utc).AddTicks(1978), "Friday Wrap-up", new DateTime(2026, 5, 29, 16, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(2026, 5, 29, 15, 0, 0, 0, DateTimeKind.Unspecified), 5, "Weekly Report", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 19, "#4e73df", new DateTime(2026, 4, 4, 0, 18, 59, 867, DateTimeKind.Utc).AddTicks(1979), "Reviewing May performance", new DateTime(2026, 5, 31, 13, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(2026, 5, 31, 11, 0, 0, 0, DateTimeKind.Unspecified), null, "May Summary", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 20, "#36b9cc", new DateTime(2026, 4, 4, 0, 18, 59, 867, DateTimeKind.Utc).AddTicks(1980), "Late night productivity", new DateTime(2026, 6, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(2026, 5, 31, 22, 0, 0, 0, DateTimeKind.Unspecified), null, "Side Project Push", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" }
                });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 2,
                column: "TargetDate",
                value: new DateTime(2026, 5, 4, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(979));

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 3,
                column: "TargetDate",
                value: new DateTime(2025, 11, 4, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1040));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1389), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1394) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1402), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1406) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1415), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1416) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1418), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1420) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1424), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1428) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1432), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1433) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1435), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1456) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1458), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1460) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1462), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1463) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1470), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1471) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1474), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1475) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1477), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1478) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1480), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1481) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1483), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1487) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1531), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1533) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1538), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1539) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1541), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1542) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1545), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1546) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1552), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1553) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1555), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1556) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1558), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1560) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1595), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1597) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1601), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1603) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1606), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1608) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1611), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1612) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1615), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1617) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 25, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1621), new DateTime(2026, 4, 9, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1623) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2026, 4, 4, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1633));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2026, 4, 4, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1637));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2026, 4, 4, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1665));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedOn",
                value: new DateTime(2026, 4, 4, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1668));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedOn",
                value: new DateTime(2026, 4, 4, 3, 18, 59, 867, DateTimeKind.Local).AddTicks(1671));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2504e0-4f89-11d3-9a0c-0305e82c3301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3dec418d-71ef-4c96-83b1-68ca57854fff", "AQAAAAIAAYagAAAAEE8AGEUkx5HDmZiGh02I2ChJG/XYpybF1wMV/YK4q7KAROhbkFhqTYIW/5c7ksvohA==", "25082a99-f4f1-46be-ab4c-5b5c951b4411" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2cd0adda-73ea-4633-a12c-7082f762beef", "AQAAAAIAAYagAAAAENJ1qIGu0ZcUJUp6+/9T/Yy7PgxmMi+VlhD9Ey4ZW1SYpkd+acpm8FwsAUm6AitQwg==", "760f62f7-b1ce-4883-915b-75f56efce18f" });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 2,
                column: "TargetDate",
                value: new DateTime(2026, 5, 3, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8546));

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 3,
                column: "TargetDate",
                value: new DateTime(2025, 11, 3, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8592));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8862), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8866) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8871), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8872) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8874), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8875) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8877), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8878) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8880), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8881) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8884), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8885) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8934), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8935) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8937), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8938) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8940), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8941) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8944), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8945) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8947), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8948) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8950), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8950) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8953), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8953) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8955), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8956) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8958), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8959) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8960), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8961) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8963), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8964) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8966), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8967) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8969), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8970) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8971), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8972) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8974), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8975) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8976), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8977) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8979), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8980) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8982), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8982) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8984), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8985) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8987), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8987) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 24, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8989), new DateTime(2026, 4, 8, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8990) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2026, 4, 3, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8993));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2026, 4, 3, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8995));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2026, 4, 3, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedOn",
                value: new DateTime(2026, 4, 3, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(8998));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedOn",
                value: new DateTime(2026, 4, 3, 21, 55, 31, 450, DateTimeKind.Local).AddTicks(9000));
        }
    }
}
