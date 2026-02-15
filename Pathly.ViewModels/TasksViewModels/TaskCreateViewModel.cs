using Microsoft.AspNetCore.Mvc.Rendering;
using Pathly.DataModels;
using Pathly.GCommon;
using System.ComponentModel.DataAnnotations;

namespace Pathly.ViewModels.TasksViewModels
{
    public class TaskCreateViewModel
    {
        [Required(ErrorMessage = ErrorMessages.TitleIsRequired)]
        [MaxLength(ValidationConstants.MaxTaskItemTitleLength, ErrorMessage = ErrorMessages.TaskItemTitleCannotExceed100Characters)]
        public string Title { get; set; } = null!;

        [MaxLength(ValidationConstants.MaxTaskItemDescriptionLength, ErrorMessage = ErrorMessages.TaskItemDescriptionCannotExceed500Characters)]
        public string? Description { get; set; }

        public DateTime? DueDate { get; set; }
        public TaskPriority Priority { get; set; }
        public List<int> SelectedTagIds { get; set; } = new List<int>();

        public int? ActionId { get; set; }
        public ActionItem? Action { get; set; }
        public IEnumerable<SelectListItem> AvailableTags { get; set; } = new List<SelectListItem>();
    }
}
