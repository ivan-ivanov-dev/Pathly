using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pathly.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddKanbanPropertiesAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2504e0-4f89-11d3-9a0c-0305e82c3301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1682ac2f-a686-4dcd-948d-d296ce342ed8", "AQAAAAIAAYagAAAAELHYwsDcwchtaF0z25A1JqUQ5KlRPpd/WLdqpAJLl1ANtczYZGt3r91/+U+al+iukQ==", "d9ffe22b-77e9-4213-9e77-4bb7cf7b4330" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29d2cf13-b4cb-4319-92fa-10b5d3d09b9f", "AQAAAAIAAYagAAAAEElEhYsmIj/HdznG0J0jP7sI1Tw3M2SOKNbMszfszh0yUN1YxZaA+rJlSIOV0sFv7w==", "2910d4ec-a347-4f81-b1e5-fe292d2edf79" });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 2,
                column: "TargetDate",
                value: new DateTime(2026, 5, 3, 18, 52, 39, 829, DateTimeKind.Local).AddTicks(2911));

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 3,
                column: "TargetDate",
                value: new DateTime(2025, 11, 3, 18, 52, 39, 829, DateTimeKind.Local).AddTicks(2950));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3183), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3185), 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3242), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3243), 1, 3 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3245), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3245), false, 1 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3247), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3247), true, 2, 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3248), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3249), false, 3, 3 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3251), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3251), 1, 1 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3252), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3252), 4, 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3253), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3254), 5, 3 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3255), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3255), false, 2, 1 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3256), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3257), true, 6, 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3258), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3258), false, 7, 3 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3259), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3259), 3, 1 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3260), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3261), 8, 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3262), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3262), 9, 3 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3263), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3263), false, 4, 1 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3264), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3264), true, 10, 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3265), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3265), false, 11, 3 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3267), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3267), 5, 1 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3268), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3268), 12, 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3270), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3270), 13, 3 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3271), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3271), false, 6, 1 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3272), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3272), true, 14, 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3273), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3273), false, 15, 3 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3274), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3274), 7, 1 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3275), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3275), 16, 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3276), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3276), 17, 3 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3277), "Strategic seed description", new DateTime(2026, 4, 8, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3277), false, 8, 1 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedOn", "Description" },
                values: new object[] { new DateTime(2026, 4, 3, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3279), "Unlinked high-level objective" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedOn", "Description", "Position" },
                values: new object[] { new DateTime(2026, 4, 3, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3280), "Unlinked high-level objective", 1 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedOn", "Description", "Position" },
                values: new object[] { new DateTime(2026, 4, 3, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3281), "Unlinked high-level objective", 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedOn", "Description", "Position" },
                values: new object[] { new DateTime(2026, 4, 3, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3282), "Unlinked high-level objective", 3 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedOn", "Description", "Position" },
                values: new object[] { new DateTime(2026, 4, 3, 15, 52, 39, 829, DateTimeKind.Utc).AddTicks(3283), "Unlinked high-level objective", 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2504e0-4f89-11d3-9a0c-0305e82c3301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f608e76-c3dd-4afd-b413-d678ae5b33ca", "AQAAAAIAAYagAAAAEMvc0H+cPgM7mFR/ZeFsCV70+VJ+lKRUlAFvg5s+SUAXhl8MDA4fKx5+Sct/67l6vw==", "ae9dfc86-aa87-407f-bb81-56dc2753e553" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d3ec07d-793b-4db0-8dc1-1a979bc7d375", "AQAAAAIAAYagAAAAEM6sH809RXmOEkDfKNtQ7Doi/YHQmJi9YHB58V5dFqJ99DccwRny3z7R40oPTPJk8A==", "0159eab2-7f6c-47f2-8603-a376cfa408a8" });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 2,
                column: "TargetDate",
                value: new DateTime(2026, 5, 2, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9568));

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 3,
                column: "TargetDate",
                value: new DateTime(2025, 11, 2, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9606));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9949), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9952), 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9956), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9957), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9960), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9961), true, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9963), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9964), false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(15), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(16), true, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(18), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(19), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(21), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(22), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(24), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(24), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(26), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(27), true, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(29), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(30), false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(32), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(33), true, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(34), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(35), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(37), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(38), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(39), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(40), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(42), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(42), true, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(44), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(45), false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(46), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(47), true, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(49), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(50), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(52), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(53), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(55), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(55), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(57), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(58), true, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(59), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(60), false, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(62), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(63), true, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(64), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(65), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(67), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(67), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedOn", "Description", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(69), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(70), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedOn", "Description", "DueDate", "IsCompleted", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(71), "Seed description", new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(72), true, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedOn", "Description" },
                values: new object[] { new DateTime(2026, 4, 2, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(75), "Unlinked task description" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedOn", "Description", "Position" },
                values: new object[] { new DateTime(2026, 4, 2, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(77), "Unlinked task description", 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedOn", "Description", "Position" },
                values: new object[] { new DateTime(2026, 4, 2, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(79), "Unlinked task description", 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedOn", "Description", "Position" },
                values: new object[] { new DateTime(2026, 4, 2, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(80), "Unlinked task description", 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedOn", "Description", "Position" },
                values: new object[] { new DateTime(2026, 4, 2, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(82), "Unlinked task description", 0 });
        }
    }
}
