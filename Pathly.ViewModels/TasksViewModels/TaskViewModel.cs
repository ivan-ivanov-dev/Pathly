using Pathly.DataModels;
using Pathly.GCommon;
using System.ComponentModel.DataAnnotations;
using TaskStatus = Pathly.DataModels.TaskStatus;

namespace Pathly.ViewModels.TasksViewModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.TitleIsRequired)]
        [MaxLength(ValidationConstants.MaxTaskItemTitleLength, ErrorMessage = ErrorMessages.TaskItemTitleCannotExceed100Characters)]
        public string Title { get; set; } = null!;

        [MaxLength(ValidationConstants.MaxTaskItemDescriptionLength, ErrorMessage = ErrorMessages.TaskItemDescriptionCannotExceed500Characters)]
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public TaskPriority Priority { get; set; } = TaskPriority.Low;
        public TaskStatus Status { get; set; }
        public int Position { get; set; }
        public bool IsCompleted { get; set; }
        
        public List<string> Tags { get; set; } = new List<string>();
    }
}