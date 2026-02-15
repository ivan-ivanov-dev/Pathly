using Pathly.GCommon;
using System.ComponentModel.DataAnnotations;

namespace Pathly.ViewModels.Roadmaps
{
    public class RoadmapDeatailsViewModel
    {
        public int RoadmapId { get; set; }


        [Required(ErrorMessage = ErrorMessages.TitleIsRequired)]
        [MaxLength(ValidationConstants.MaxGoalTitleLength, ErrorMessage = ErrorMessages.GoalTitleCannotExceed50Characters)]
        public string GoalTitle { get; set; } = null!;


        [MaxLength(ValidationConstants.MaxGoalLongDescriptionLength, ErrorMessage = ErrorMessages.GoalLongDescriptionCannotExceed1500Characters)]
        public string? GoalDescription { get; set; }


        [MaxLength(ValidationConstants.MaxRoadmapWhyLength, ErrorMessage = ErrorMessages.RoadmapDescriptionCannotExceed2000Characters)]
        public string? Why { get; set; }


        [MaxLength(ValidationConstants.MaxRoadmapIdealOutcomeLength, ErrorMessage = ErrorMessages.RoadmapDescriptionCannotExceed2000Characters)]
        public string? IdealOutcome { get; set; }

        public List<ActionsDisplayViewModel> Actions { get; set; } = new();
    }
}
