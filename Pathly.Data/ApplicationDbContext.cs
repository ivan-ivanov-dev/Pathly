using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pathly.DataModels;

namespace Pathly.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }
        public DbSet<TaskItem> Tasks => Set<TaskItem>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<TaskTag> TaskTags => Set<TaskTag>();
        public DbSet<Goal> Goals => Set<Goal>();
        public DbSet<ActionItem> Actions => Set<ActionItem>();
        public DbSet<Roadmap> Roadmaps => Set<Roadmap>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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
                .WithOne()
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
        }

    }
}
