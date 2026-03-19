using Pathly.GCommon;
using System.ComponentModel.DataAnnotations;

namespace Pathly.DataModels
{
    public class Roadmap
    {
        public int Id { get; set; }

        public int GoalId { get; set; }
        public virtual Goal Goal { get; set; }

        [MaxLength(ValidationConstants.MaxRoadmapWhyLength)]
        public string? Why { get; set; }

        [MaxLength(ValidationConstants.MaxRoadmapIdealOutcomeLength)]
        public string? IdealOutcome { get; set; }

        [Required]
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        public virtual ICollection<ActionItem> Actions { get; set; } = new List<ActionItem>();
    }
}
