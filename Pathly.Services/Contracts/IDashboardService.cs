using Pathly.Models.ViewModels.Dashboard;
using System.IO.Compression;

namespace Pathly.Services.Contracts
{
    public interface IDashboardService
    {
        Task<DashboardStatsViewModel> GetDashboardStatsAsync(string userId);
        Task<DashboardFocusListsViewModel> GetDashboardFocusListsAsync(string userId);
    }
}
