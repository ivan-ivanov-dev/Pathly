using Pathly.GCommon;
using System.ComponentModel.DataAnnotations;

namespace Pathly.ViewModels.Roadmaps
{
    public class RoadmapCreateViewModel
    {
        public int? RoadmapId { get; set; }
        public int? SelectedGoalId { get; set; }

        [Required(ErrorMessage = ErrorMessages.GoalTitleIsRequired)]
        [MaxLength(ValidationConstants.MaxGoalTitleLength, ErrorMessage = ErrorMessages.GoalTitleCannotExceed50Characters)]
        public string? NewGoalTitle { get; set; }
        [MaxLength(ValidationConstants.MaxGoalLongDescriptionLength, ErrorMessage = ErrorMessages.GoalLongDescriptionCannotExceed1500Characters)]
        public string? NewGoalDescription { get; set; }
        public bool NewGoalIsActive { get; set; } = true;
        public DateTime? NewGoalTargetDate { get; set; }


        [MaxLength(ValidationConstants.MaxRoadmapWhyLength, ErrorMessage = ErrorMessages.RoadmapDescriptionCannotExceed2000Characters)]
        public string? Why { get; set; }

        [MaxLength(ValidationConstants.MaxRoadmapIdealOutcomeLength, ErrorMessage = ErrorMessages.RoadmapDescriptionCannotExceed2000Characters)]
        public string? IdealOutcome { get; set; }

        public bool IsEditing { get; set; } = false;
        public List<ActionItemCreateViewModel> Actions { get; set; } = new List<ActionItemCreateViewModel>();
    }
}
