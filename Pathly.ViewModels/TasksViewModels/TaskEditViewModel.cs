using Microsoft.AspNetCore.Mvc.Rendering;
using Pathly.GCommon;
using System.ComponentModel.DataAnnotations;

namespace Pathly.ViewModels.TasksViewModels
{
    public class TaskEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.TitleIsRequired)]
        [MaxLength(ValidationConstants.MaxTaskItemTitleLength, ErrorMessage = ErrorMessages.TaskItemTitleCannotExceed100Characters)]
        public string Title { get; set; } = null!;

        [MaxLength(ValidationConstants.MaxTaskItemDescriptionLength, ErrorMessage = ErrorMessages.TaskItemDescriptionCannotExceed500Characters)]
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public List<int> SelectedTagIds { get; set; } = new List<int>();
        public IEnumerable<SelectListItem> AvailableTags { get; set; } = new List<SelectListItem>();
    }
}
