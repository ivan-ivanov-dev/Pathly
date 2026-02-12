using MicroTaskTracker.Models.ViewModels.Goals;

namespace MicroTaskTracker.Services.Interfaces
{
    public interface IGoalService
    {
        Task<List<GoalViewModel>> GetAllGoalsAsync(string userId);
        Task<GoalDetailsViewModel?> GetDetailsAsync(int id, string userId);
        Task CreateAsync(GoalCreateViewModel model, string userId);
        Task UpdateAsync(int id, GoalEditViewModel model, string userId);
        Task<bool> DeleteAsync(int id, string userId);
    }
}
