using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pathly.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixGoalRoadmapRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2504e0-4f89-11d3-9a0c-0305e82c3301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59410515-1d89-44a8-87ce-b8e89edf7130", "AQAAAAIAAYagAAAAEAoxW3EMto9W74DoYzxcUOwhnIMveA+g07tCD1LizE3mLIEfmLMkWZMxT0KoQdTscw==", "b2a9201f-73e8-45ee-8ef1-f7c901aeac00" });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 2,
                column: "TargetDate",
                value: new DateTime(2026, 4, 19, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6425));

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 3,
                column: "TargetDate",
                value: new DateTime(2025, 10, 19, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6465));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6763), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6767) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6771), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6772) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6774), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6775) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6777), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6778) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6780), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6781) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6783), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6784) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6786), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6787) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6789), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6789) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6791), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6792) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6795), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6796) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6797), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6798) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6799), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6800) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6802), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6803) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6804), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6805) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6807), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6807) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6809), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6810) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6811), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6812) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6814), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6815) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6817), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6818) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6819), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6820) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6822), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6822) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6824), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6825) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6826), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6827) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6828), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6829) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6831), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6832) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6833), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6834) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedOn", "DueDate" },
                values: new object[] { new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6835), new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6836) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2026, 3, 19, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6839));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2026, 3, 19, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6841));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2026, 3, 19, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6842));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedOn",
                value: new DateTime(2026, 3, 19, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6844));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedOn",
                value: new DateTime(2026, 3, 19, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6868));
        }
    }
}
