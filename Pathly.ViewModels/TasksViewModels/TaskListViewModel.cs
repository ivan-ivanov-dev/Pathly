using Pathly.DataModels;
using Pathly.GCommon;

namespace Pathly.ViewModels.TasksViewModels
{
    public class TaskListViewModel: TaskViewModel
    {
        public PagedList<TaskViewModel> Tasks { get; set; } = null!;

        public List<Tag> AvailableFilterTags { get; set; } = new();
    }
}
