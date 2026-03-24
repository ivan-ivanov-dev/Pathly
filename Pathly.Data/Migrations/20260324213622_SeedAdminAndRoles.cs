using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pathly.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", null, "Administrator", "ADMINISTRATOR" },
                    { "7f3c9b5e-6c12-4d8a-a6f2-3e9b1c4d8f71", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2504e0-4f89-11d3-9a0c-0305e82c3301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5735e1a2-8528-449a-8ae6-8782bd1f9987", "AQAAAAIAAYagAAAAEBlANXZLICmgvG9mZsITgqIImxcVT801JWC0+XZm+td42HbcRse3Bh6lfJ0SI+6sKA==", "ab66c78d-c37f-4481-bd44-639470522e37" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "c65e8a49-a251-463d-982f-4f5985e9300c", "admin@pathly.com", true, false, null, "ADMIN@PATHLY.COM", "ADMIN@PATHLY.COM", "AQAAAAIAAYagAAAAEBk00Y1qKSxjiPrHaUyiljinW9lJXJxYfcDS8VxFnP4o2CStqa9md46YcVsQMh31SA==", null, false, "b48fe7e1-52a4-4e2c-8f07-9660dc3754dc", false, "admin@pathly.com" });

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "7f3c9b5e-6c12-4d8a-a6f2-3e9b1c4d8f71", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7f3c9b5e-6c12-4d8a-a6f2-3e9b1c4d8f71", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f3c9b5e-6c12-4d8a-a6f2-3e9b1c4d8f71");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2504e0-4f89-11d3-9a0c-0305e82c3301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d6feb5e-4b0e-4257-8c3c-3b2a60642ea5", "AQAAAAIAAYagAAAAEK+1AN+2OYbWgwIX++Y6QbwiDo6L9a5IzNUAXd75xvbGB4FTLXH3QOTw3Dh3YpZwqw==", "00644c98-cce0-4d3b-ac0c-5cb3113a4f5a" });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 2,
                column: "TargetDate",
                value: new DateTime(2026, 4, 19, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(3921));

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 3,
                column: "TargetDate",
                value: new DateTime(2025, 10, 19, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(3964));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4313), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4317) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4322), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4323) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4325), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4326) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4328), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4329) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4331), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4332) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4335), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4336) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4338), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4339) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4341), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4341) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4343), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4344) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4347), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4347) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4349), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4350) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4352), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4352) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4354), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4355) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4357), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4358) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4360), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4360) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4362), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4363) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4365), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4366) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4368), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4369) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4371), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4372) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4374), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4375) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4376), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4377) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4379), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4380) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4381), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4382) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4384), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4385) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4387), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4387) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4389), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4390) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4415), new DateTime(2026, 3, 24, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4416) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2026, 3, 19, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4420));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2026, 3, 19, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4423));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2026, 3, 19, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4424));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedOn",
                value: new DateTime(2026, 3, 19, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4426));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedOn",
                value: new DateTime(2026, 3, 19, 22, 23, 58, 841, DateTimeKind.Local).AddTicks(4427));
        }
    }
}
