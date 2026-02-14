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

    }
}
