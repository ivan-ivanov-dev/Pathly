using Pathly.GCommon;
using System.ComponentModel.DataAnnotations;
namespace Pathly.DataModels
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxTaskItemTitleLength)]
        public string Title { get; set; } = null!;

        [MaxLength(ValidationConstants.MaxTaskItemDescriptionLength)]
        public string? Description { get; set; }

        public TaskPriority Priority { get; set; } = TaskPriority.Low;
        public TaskStatus Status { get; set; } = TaskStatus.Todo;
        public bool IsCompleted { get; set; }

        public int Position { get; set; }

        public DateTime CreatedOn{ get; set; }
        public DateTime? DueDate { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        public ApplicationUser? User { get; set; }
        public ICollection<TaskTag> TaskTags { get; set; } = new List<TaskTag>();

        public int? ActionId { get; set; }
        public ActionItem? Action { get; set; }
    }
    public enum TaskStatus
    {
        Todo = 0,
        InProgress = 1,
        Done = 2
    }
}
