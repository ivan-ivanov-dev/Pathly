
using Pathly.ViewModels.Goals;

namespace Pathly.Services.Contracts
{
    public interface IGoalService
    {
        Task<GoalDetailsViewModel?> GetDetailsAsync(int id, string userId);
        Task CreateAsync(GoalCreateViewModel model, string userId);
        Task UpdateAsync(int id, GoalEditViewModel model, string userId);
        Task<bool> DeleteAsync(int id, string userId);
        Task<GoalQueryModel> GetAllAsync(GoalQueryModel queryModel, string userId);

        Task ToggleGoalStatusAsync(int id, string userId);
    }
}
