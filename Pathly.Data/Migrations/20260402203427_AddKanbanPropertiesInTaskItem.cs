using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pathly.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddKanbanPropertiesInTaskItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9949), new DateTime(2026, 4, 7, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9952), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9956), new DateTime(2026, 4, 7, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9957), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9960), new DateTime(2026, 4, 7, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9961), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9963), new DateTime(2026, 4, 7, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9964), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(15), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(16), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(18), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(19), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(21), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(22), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(24), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(24), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(26), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(27), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(29), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(30), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(32), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(33), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(34), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(35), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(37), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(38), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(39), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(40), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(42), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(42), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(44), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(45), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(46), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(47), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(49), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(50), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(52), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(53), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(55), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(55), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(57), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(58), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(59), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(60), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(62), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(63), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(64), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(65), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(67), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(67), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(69), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(70), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedOn", "DueDate", "Position", "Status" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(71), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(72), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedOn", "Position", "Status" },
                values: new object[] { new DateTime(2026, 4, 2, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(75), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedOn", "Position", "Status" },
                values: new object[] { new DateTime(2026, 4, 2, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(77), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedOn", "Position", "Status" },
                values: new object[] { new DateTime(2026, 4, 2, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(79), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedOn", "Position", "Status" },
                values: new object[] { new DateTime(2026, 4, 2, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(80), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedOn", "Position", "Status" },
                values: new object[] { new DateTime(2026, 4, 2, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(82), 0, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tasks");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2504e0-4f89-11d3-9a0c-0305e82c3301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "355f51d3-eeba-4a4f-b302-350fb81d6374", "AQAAAAIAAYagAAAAEBHwCdL9emEQLRcNBOL/9G4GpC5sWBnHHX34LJq9KNLoiYYQ8ktnr3AmIptaMOuHwg==", "863c3645-d87a-489c-bb57-07211074b9dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db882b12-087f-46f1-a501-7d86ce512410", "AQAAAAIAAYagAAAAEOA8LXVnnzZbUQwXIgWUl7UuXXUO297bSRM7zLGPOa5YASj7A/ybItgMi7HmETI0sQ==", "055b2f0d-6d71-4315-bc73-f87d5476379b" });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 2,
                column: "TargetDate",
                value: new DateTime(2026, 4, 25, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2153));

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 3,
                column: "TargetDate",
                value: new DateTime(2025, 10, 25, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2193));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2487), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2491) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2496), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2497) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2499), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2500) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2502), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2503) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2504), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2505) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2508), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2509) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2510), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2511) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2513), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2514) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2516), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2516) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2519), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2519) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2521), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2522) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2523), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2524) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2526), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2526) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2528), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2529) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2530), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2531) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2532), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2533) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2535), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2535) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2538), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2539) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2540), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2541) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2542), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2543) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2545), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2546) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2547), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2548) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2549), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2550) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2552), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2553) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2554), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2555) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2556), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2557) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 15, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2559), new DateTime(2026, 3, 30, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2559) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2026, 3, 25, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2562));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2026, 3, 25, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2564));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2026, 3, 25, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2566));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedOn",
                value: new DateTime(2026, 3, 25, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2567));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedOn",
                value: new DateTime(2026, 3, 25, 9, 41, 15, 835, DateTimeKind.Local).AddTicks(2569));
        }
    }
}
