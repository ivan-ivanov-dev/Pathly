using Pathly.GCommon;
using Pathly.ViewModels.TasksViewModels;
using System.ComponentModel.DataAnnotations;

namespace Pathly.ViewModels.Roadmaps
{
    public class ActionsDisplayViewModel
    {
        public int ActionId { get; set; }
        [Required(ErrorMessage = ErrorMessages.TitleIsRequired)]
        [MaxLength(ValidationConstants.MaxActionItemTitleLength, ErrorMessage = ErrorMessages.ActionTitleCannotExceed100Characters)]
        public string Title { get; set; } = null!;
        [MaxLength(ValidationConstants.MaxActionItemResourcesLength, ErrorMessage = ErrorMessages.ActionResourcesCannotExceed500Characters)]
        public string? Resources { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }

        public List<TaskViewModel> AssignedTasks { get; set; } = new();
    }
}
