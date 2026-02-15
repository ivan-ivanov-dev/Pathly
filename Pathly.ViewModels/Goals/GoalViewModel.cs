using Pathly.GCommon;
using System.ComponentModel.DataAnnotations;

namespace Pathly.ViewModels.Goals
{
    public class GoalViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = ErrorMessages.TitleIsRequired)]
        [MaxLength(ValidationConstants.MaxGoalTitleLength, ErrorMessage = ErrorMessages.GoalTitleCannotExceed50Characters)]
        public string Title { get; set; } = null!;
        [StringLength(ValidationConstants.MaxGoalShortDescriptionLength, ErrorMessage = ErrorMessages.GoalShortDescriptionCannotExceed200Characters)]
        public string? ShortDescription { get; set; }
        public DateTime? TargetDate { get; set; }
        public bool IsActive { get; set; } = true;

        public bool HasRoadmap { get; set; }
        public int? RoadmapId { get; set; }

    }
}
