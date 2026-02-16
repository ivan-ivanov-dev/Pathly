using Pathly.DataModels;

namespace Pathly.ViewModels.TasksViewModels
{
    public class TaskListViewModel: TaskViewModel
    {
        public IEnumerable<TaskViewModel> Tasks { get; set; } = Enumerable.Empty<TaskViewModel>();
        public List<Tag> AvailableFilterTags { get; set; } = new();
    }
}
