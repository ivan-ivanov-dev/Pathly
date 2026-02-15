using Pathly.DataModels;
using Pathly.GCommon;
using System.ComponentModel.DataAnnotations;

namespace Pathly.ViewModels.Dashboard
{
    public class TaskSummaryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = ErrorMessages.TitleIsRequired)]
        public string Title { get; set; } = null!;
        public DateTime? DueDate { get; set; }
        public TaskPriority Priority { get; set; }
        public bool IsCompleted { get; set; }
    }
}
