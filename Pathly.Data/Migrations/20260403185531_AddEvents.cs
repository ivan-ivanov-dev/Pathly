using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pathly.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAllDay = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ColorHex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: true),
                    GoalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Events_Goals_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Events_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Events_GoalId",
                table: "Events",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_TaskId",
                table: "Events",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                table: "Events",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

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
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9949), new DateTime(2026, 4, 7, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9952) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9956), new DateTime(2026, 4, 7, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9957) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9960), new DateTime(2026, 4, 7, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9961) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9963), new DateTime(2026, 4, 7, 23, 34, 26, 391, DateTimeKind.Local).AddTicks(9964) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(15), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(16) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(18), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(19) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(21), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(22) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(24), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(24) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(26), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(27) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(29), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(30) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(32), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(33) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(34), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(35) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(37), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(38) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(39), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(40) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(42), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(42) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(44), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(45) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(46), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(47) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(49), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(50) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(52), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(53) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(55), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(55) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(57), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(58) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(59), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(60) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(62), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(63) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(64), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(65) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(67), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(67) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(69), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(70) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 23, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(71), new DateTime(2026, 4, 7, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(72) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2026, 4, 2, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(75));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2026, 4, 2, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(77));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2026, 4, 2, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(79));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedOn",
                value: new DateTime(2026, 4, 2, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(80));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedOn",
                value: new DateTime(2026, 4, 2, 23, 34, 26, 392, DateTimeKind.Local).AddTicks(82));
        }
    }
}
