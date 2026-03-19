using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pathly.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TargetDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goals_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roadmaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoalId = table.Column<int>(type: "int", nullable: false),
                    Why = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IdealOutcome = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roadmaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roadmaps_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roadmaps_Goals_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Resources = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoadmapId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actions_Roadmaps_RoadmapId",
                        column: x => x.RoadmapId,
                        principalTable: "Roadmaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskTags",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTags", x => new { x.TaskId, x.TagId });
                    table.ForeignKey(
                        name: "FK_TaskTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskTags_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3f2504e0-4f89-11d3-9a0c-0305e82c3301", 0, "59410515-1d89-44a8-87ce-b8e89edf7130", "test@pathly.com", true, false, null, "TEST@PATHLY.COM", "TEST@PATHLY.COM", "AQAAAAIAAYagAAAAEAoxW3EMto9W74DoYzxcUOwhnIMveA+g07tCD1LizE3mLIEfmLMkWZMxT0KoQdTscw==", null, false, "b2a9201f-73e8-45ee-8ef1-f7c901aeac00", false, "test@pathly.com" });

            migrationBuilder.InsertData(
                table: "Goals",
                columns: new[] { "Id", "IsActive", "ShortDescription", "TargetDate", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, true, "Mastering advanced architecture and cloud services in the .NET ecosystem.", new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Become a Senior .NET Developer", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 2, true, "Complete the implementation of AutoMapper and Seeding in the current project.", new DateTime(2026, 4, 19, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6425), "Master Pathly Architecture", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 3, false, "Successfully finished the basics of C# programming.", new DateTime(2025, 10, 19, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6465), "SoftUni Fundamentals Module", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Work", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 2, "Personal", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 3, "C#", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 4, "Gym", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 5, "Frontend", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 6, "Testing", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 7, "Learning", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 8, "Soft Skill", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 9, "School", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 10, "Urgent", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "ActionId", "CreatedOn", "Description", "DueDate", "IsCompleted", "Priority", "Title", "UserId" },
                values: new object[,]
                {
                    { 28, null, new DateTime(2026, 3, 19, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6839), "Unlinked task description", null, false, 2, "General Task 1", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 29, null, new DateTime(2026, 3, 19, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6841), "Unlinked task description", null, false, 2, "General Task 2", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 30, null, new DateTime(2026, 3, 19, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6842), "Unlinked task description", null, false, 2, "General Task 3", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 31, null, new DateTime(2026, 3, 19, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6844), "Unlinked task description", null, false, 2, "General Task 4", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 32, null, new DateTime(2026, 3, 19, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6868), "Unlinked task description", null, false, 2, "General Task 5", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" }
                });

            migrationBuilder.InsertData(
                table: "Roadmaps",
                columns: new[] { "Id", "GoalId", "IdealOutcome", "UserId", "Why" },
                values: new object[,]
                {
                    { 1, 1, "Senior Dev Role", "3f2504e0-4f89-11d3-9a0c-0305e82c3301", "To achieve financial independence" },
                    { 2, 2, "Perfectly coded app", "3f2504e0-4f89-11d3-9a0c-0305e82c3301", "To build professional habits" },
                    { 3, 3, "Solid programming basics", "3f2504e0-4f89-11d3-9a0c-0305e82c3301", "Foundation is key" }
                });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "Id", "DueDate", "IsCompleted", "Resources", "RoadmapId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, null, true, "MS Docs, Pluralsight", 1, "Master EF Core", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 2, null, false, "Docker, RabbitMQ basics", 1, "Learn Microservices", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 3, null, false, "GoF Book", 1, "System Design Design Patterns", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 4, null, true, "AutoMapper Guide", 2, "Implement AutoMapper", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 5, null, false, "xUnit, Moq", 2, "Setup Unit Tests", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 6, null, false, "Bootstrap, CSS", 2, "Finalize UI", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 7, null, true, null, 3, "Basic Syntax", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 8, null, true, null, 3, "Loops and Arrays", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 9, null, true, null, 3, "Classes and Objects", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "ActionId", "CreatedOn", "Description", "DueDate", "IsCompleted", "Priority", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6763), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6767), true, 3, "Task 1 for Action 1", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 2, 1, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6771), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6772), false, 4, "Task 2 for Action 1", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 3, 1, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6774), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6775), true, 1, "Task 3 for Action 1", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 4, 2, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6777), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6778), false, 2, "Task 1 for Action 2", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 5, 2, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6780), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6781), true, 3, "Task 2 for Action 2", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 6, 2, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6783), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6784), false, 4, "Task 3 for Action 2", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 7, 3, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6786), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6787), true, 1, "Task 1 for Action 3", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 8, 3, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6789), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6789), false, 2, "Task 2 for Action 3", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 9, 3, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6791), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6792), true, 3, "Task 3 for Action 3", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 10, 4, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6795), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6796), false, 4, "Task 1 for Action 4", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 11, 4, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6797), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6798), true, 1, "Task 2 for Action 4", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 12, 4, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6799), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6800), false, 2, "Task 3 for Action 4", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 13, 5, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6802), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6803), true, 3, "Task 1 for Action 5", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 14, 5, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6804), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6805), false, 4, "Task 2 for Action 5", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 15, 5, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6807), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6807), true, 1, "Task 3 for Action 5", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 16, 6, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6809), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6810), false, 2, "Task 1 for Action 6", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 17, 6, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6811), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6812), true, 3, "Task 2 for Action 6", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 18, 6, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6814), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6815), false, 4, "Task 3 for Action 6", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 19, 7, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6817), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6818), true, 1, "Task 1 for Action 7", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 20, 7, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6819), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6820), false, 2, "Task 2 for Action 7", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 21, 7, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6822), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6822), true, 3, "Task 3 for Action 7", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 22, 8, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6824), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6825), false, 4, "Task 1 for Action 8", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 23, 8, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6826), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6827), true, 1, "Task 2 for Action 8", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 24, 8, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6828), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6829), false, 2, "Task 3 for Action 8", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 25, 9, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6831), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6832), true, 3, "Task 1 for Action 9", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 26, 9, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6833), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6834), false, 4, "Task 2 for Action 9", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" },
                    { 27, 9, new DateTime(2026, 3, 9, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6835), "Seed description", new DateTime(2026, 3, 24, 17, 42, 21, 229, DateTimeKind.Local).AddTicks(6836), true, 1, "Task 3 for Action 9", "3f2504e0-4f89-11d3-9a0c-0305e82c3301" }
                });

            migrationBuilder.InsertData(
                table: "TaskTags",
                columns: new[] { "TagId", "TaskId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 10, 1 },
                    { 3, 2 },
                    { 7, 4 },
                    { 5, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actions_RoadmapId",
                table: "Actions",
                column: "RoadmapId");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_UserId",
                table: "Actions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_UserId",
                table: "Goals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roadmaps_GoalId",
                table: "Roadmaps",
                column: "GoalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roadmaps_UserId",
                table: "Roadmaps",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_UserId",
                table: "Tags",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ActionId",
                table: "Tasks",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTags_TagId",
                table: "TaskTags",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TaskTags");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Roadmaps");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
