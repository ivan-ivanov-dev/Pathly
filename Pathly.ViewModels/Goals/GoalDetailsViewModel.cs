using Pathly.GCommon;
using Pathly.ViewModels.Roadmaps;
using System.ComponentModel.DataAnnotations;

namespace Pathly.ViewModels.Goals
{
    public class GoalDetailsViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = ErrorMessages.TitleIsRequired)]
        [MaxLength(ValidationConstants.MaxGoalTitleLength, ErrorMessage = ErrorMessages.GoalTitleCannotExceed50Characters)]
        public string Title { get; set; } = null!;
        [StringLength(ValidationConstants.MaxGoalShortDescriptionLength, ErrorMessage = ErrorMessages.GoalShortDescriptionCannotExceed200Characters)]
        public string? ShortDescription { get; set; }
        public DateTime? TargetDate { get; set; }
        public bool IsActive { get; set; }
        public List<ActionsDisplayViewModel> Actions { get; set; } = new();

        public int? RoadmapId { get; set; }
    }
}
