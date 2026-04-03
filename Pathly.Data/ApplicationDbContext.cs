using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pathly.Data.Seeding.Configurations;
using Pathly.DataModels;

namespace Pathly.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) 
            : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<TaskItem> Tasks => Set<TaskItem>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<TaskTag> TaskTags => Set<TaskTag>();
        public DbSet<Goal> Goals => Set<Goal>();
        public DbSet<ActionItem> Actions => Set<ActionItem>();
        public DbSet<Roadmap> Roadmaps => Set<Roadmap>();
        public DbSet<Event> Events => Set<Event>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //---------------------------//
            //DEFINE REALATIONSHIPS
            //---------------------------//

            //Task -> User
            builder.Entity<TaskItem>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // TaskTag
            builder.Entity<TaskTag>()
                .HasKey(tt => new { tt.TaskId, tt.TagId });

            // TaskTag -> Task
            builder.Entity<TaskTag>()
                .HasOne(tt => tt.Task)
                .WithMany(t => t.TaskTags)
                .HasForeignKey(tt => tt.TaskId);

            // TaskTag -> Tag
            builder.Entity<TaskTag>()
                .HasOne(tt => tt.Tag)
                .WithMany(t => t.TaskTags)
                .HasForeignKey(tt => tt.TagId);

            // Tag -> User
            builder.Entity<Tag>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Goal -> User
            builder.Entity<Goal>()
                .HasOne(g => g.User)
                .WithMany()
                .HasForeignKey(g => g.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Roadmap -> User
            builder.Entity<Roadmap>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Roadmap -> Goal
            builder.Entity<Roadmap>()
                .HasOne(r => r.Goal)
                .WithOne(g => g.Roadmap)
                .HasForeignKey<Roadmap>(r => r.GoalId)
                .OnDelete(DeleteBehavior.Restrict);

            // Roadmap -> Actions
            builder.Entity<Roadmap>()
                .HasMany(r => r.Actions)
                .WithOne(a => a.Roadmap)
                .HasForeignKey(a => a.RoadmapId)
                .OnDelete(DeleteBehavior.Restrict);

            // Action -> Tasks
            builder.Entity<ActionItem>()
                .HasMany(a => a.Tasks)
                .WithOne(t => t.Action)
                .HasForeignKey(t => t.ActionId)
                .OnDelete(DeleteBehavior.SetNull);

            //Action -> User
            builder.Entity<ActionItem>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Event -> User
            builder.Entity<Event>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Event -> Task
            builder.Entity<Event>()
                .HasOne(e => e.Task)
                .WithMany()
                .HasForeignKey(e => e.TaskId)
                .OnDelete(DeleteBehavior.SetNull);

            // Event -> Goal
            builder.Entity<Event>()
                .HasOne(e => e.Goal)
                .WithMany()
                .HasForeignKey(e => e.GoalId)
                .OnDelete(DeleteBehavior.SetNull);

            //---------------------------//
            //SEEDING CONFIGURATIONS
            //---------------------------//

            // use defaults for testing purposes
            var adminPass = _configuration["SeedSettings:AdminPassword"] ?? "Admin123!";
            var demoUserPassword = _configuration["SeedSettings:TestUserPassword"] ?? "Test1234!";


            builder.ApplyConfiguration(new RoleConfiguration());                           // 1.Role
            builder.ApplyConfiguration(new UserConfiguration(adminPass,demoUserPassword)); // 2. Users
            builder.ApplyConfiguration(new UserRoleConfiguration());                       // 3.UserRole
            builder.ApplyConfiguration(new TagConfiguration());                            // 4. Tags
            builder.ApplyConfiguration(new GoalConfiguration());                           // 5. Goals
            builder.ApplyConfiguration(new RoadmapConfiguration());                        // 6. Roadmaps
            builder.ApplyConfiguration(new ActionItemConfiguration());                     // 7. Actions
            builder.ApplyConfiguration(new TaskItemConfiguration());                       // 8. Tasks
            builder.ApplyConfiguration(new TaskTagConfiguration());                        // 9. Linking Tasks & Tags
        }
    }
}
