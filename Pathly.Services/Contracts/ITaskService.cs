using Pathly.DataModels;
using Pathly.ViewModels.TasksViewModels;
using TaskStatus = Pathly.DataModels.TaskStatus;

namespace Pathly.Services.Contracts
{
    public interface ITaskService
    {
        Task<TaskListViewModel> GetAllTasksAsync(TaskQueryModel queryModel, string userId);
        Task CreateAsync(TaskCreateViewModel model,string userId);
        Task<bool> DeleteAsync(int id, string userId);
        Task<TaskDetailsViewModel?> GetDetailsAsync(int id, string userId);
        Task MarkTaskStatusAsync(int id, string userId);
        Task UpdatePriorityAsync(int id, TaskPriority priority, string userId);
        Task<List<int>> GetTaskTagIdsAsync(int taskId, string userId);

        Task UpdateTaskPositionAsync(int id, string userId, TaskStatus newStatus, int newPosition);

        Task UpdateWithTagsAsync(int id, TaskEditViewModel model, string userId);
    }
}
