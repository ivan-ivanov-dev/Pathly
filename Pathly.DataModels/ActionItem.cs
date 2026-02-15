using System.ComponentModel.DataAnnotations;
using Pathly.GCommon;

namespace Pathly.DataModels
{
    public class ActionItem
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxActionItemTitleLength)]
        public string Title { get; set; } = null!;

        [MaxLength(ValidationConstants.MaxActionItemResourcesLength)]
        public string? Resources { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; } = false;


        [Required]
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;


        [Required]
        public int RoadmapId { get; set; }
        public Roadmap Roadmap { get; set; } = null!;

        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
