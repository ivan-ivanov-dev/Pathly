using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pathly.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsersWithSecureConfigs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2504e0-4f89-11d3-9a0c-0305e82c3301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5735e1a2-8528-449a-8ae6-8782bd1f9987", "AQAAAAIAAYagAAAAEBlANXZLICmgvG9mZsITgqIImxcVT801JWC0+XZm+td42HbcRse3Bh6lfJ0SI+6sKA==", "ab66c78d-c37f-4481-bd44-639470522e37" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c65e8a49-a251-463d-982f-4f5985e9300c", "AQAAAAIAAYagAAAAEBk00Y1qKSxjiPrHaUyiljinW9lJXJxYfcDS8VxFnP4o2CStqa9md46YcVsQMh31SA==", "b48fe7e1-52a4-4e2c-8f07-9660dc3754dc" });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 2,
                column: "TargetDate",
                value: new DateTime(2026, 4, 24, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(6815));

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 3,
                column: "TargetDate",
                value: new DateTime(2025, 10, 24, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(6852));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7177), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7181) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7263), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7264) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7266), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7267) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7269), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7270) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7272), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7273) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7276), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7277) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7279), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7280) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7281), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7282) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7284), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7285) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7287), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7288) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7290), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7291) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7292), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7293) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7294), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7295) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7297), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7298) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7299), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7300) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7301), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7302) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7304), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7305) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7307), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7308) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7309), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7310) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7312), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7312) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7314), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7315) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7316), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7317) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7319), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7319) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7321), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7322) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7323), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7324) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7326), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7326) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 14, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7328), new DateTime(2026, 3, 29, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7329) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2026, 3, 24, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7331));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2026, 3, 24, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7333));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2026, 3, 24, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7335));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedOn",
                value: new DateTime(2026, 3, 24, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7336));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedOn",
                value: new DateTime(2026, 3, 24, 23, 36, 20, 841, DateTimeKind.Local).AddTicks(7338));
        }
    }
}
