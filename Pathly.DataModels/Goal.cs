using System.ComponentModel.DataAnnotations;
using Pathly.GCommon;
namespace Pathly.DataModels
{
    public class Goal
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(ValidationConstants.MaxGoalTitleLength)]
        public string Title { get; set; } = null!;

        [MaxLength(ValidationConstants.MaxGoalShortDescriptionLength)]
        public string? ShortDescription { get; set; }
        public DateTime? TargetDate { get; set; }
        public bool IsActive { get; set; } = true;

        [Required]
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        // Marked 'virtual' so Entity Framework Core can create proxy types for lazy-loading this navigation property.
        public virtual Roadmap? Roadmap { get; set; }
        // This allows us to access the related Roadmap for a Goal without explicitly including it in our queries
        // when using AutoMapper,which can help optimize performance by only loading related data when it's actually needed.
    }
}
