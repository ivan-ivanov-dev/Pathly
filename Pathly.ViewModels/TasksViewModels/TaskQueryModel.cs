using Pathly.DataModels;
using Pathly.GCommon;

namespace Pathly.ViewModels.TasksViewModels
{
    public class TaskQueryModel
    {
        public string? SearchByTitle { get; set; }
        public bool? IsCompleted { get; set; }
        public TaskPriority? Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? Ascending { get; set; }
        public List<int>? SelectedTagIds { get; set; } = new List<int>();

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }

}
