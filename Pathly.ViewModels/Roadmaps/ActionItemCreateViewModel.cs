using Pathly.GCommon;
using Pathly.ViewModels.TasksViewModels;
using System.ComponentModel.DataAnnotations;

namespace Pathly.ViewModels.Roadmaps
{
    public class ActionItemCreateViewModel
    {
        public int? Id { get; set; }
        [MaxLength(ValidationConstants.MaxActionItemTitleLength, ErrorMessage = ErrorMessages.ActionTitleCannotExceed100Characters)]
        public string? Title { get; set; }

        public string? Resources { get; set; }

        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; } = false;

        public List<TaskViewModel> AssignedTasks { get; set; } = new();
    }
}
