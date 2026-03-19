using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Pathly.Data;
using Pathly.DataModels;
using Pathly.Services.Contracts;
using Pathly.ViewModels.Dashboard;

namespace Pathly.Services.Implementation
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DashboardService(IMapper mapper,ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<DashboardFocusListsViewModel> GetDashboardFocusListsAsync(string userId)
        {
            var today = DateTime.UtcNow.Date;

            var userTasks = _context.Tasks.Where(t => t.UserId == userId);

            var dueTodayTasks = await userTasks
            .Where(t => t.DueDate.HasValue && t.DueDate.Value.Date == today)
            .OrderBy(t => t.DueDate)
            .Take(5)
            .ProjectTo<TaskSummaryViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync();

            var overdueTasks = await userTasks
            .Where(t => t.DueDate.HasValue && t.DueDate.Value.Date < today && !t.IsCompleted)
            .OrderBy(t => t.DueDate)
            .Take(5)
            .ProjectTo<TaskSummaryViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync();

            var futureHighPriorityTasks = await userTasks
            .Where(t => t.DueDate.HasValue && t.DueDate.Value.Date > today &&
                  (t.Priority == TaskPriority.High || t.Priority == TaskPriority.Critical))
            .OrderBy(t => t.DueDate)
            .Take(5)
            .ProjectTo<TaskSummaryViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync();

            return new DashboardFocusListsViewModel
            {
                DueTodayTasks = dueTodayTasks,
                OverdueTasks = overdueTasks,
                FutureHighPriorityTasks = futureHighPriorityTasks
            };
        }

        public async Task<DashboardStatsViewModel> GetDashboardStatsAsync(string userId)
        {
            var today = DateTime.UtcNow.Date;

            var userTasks = _context.Tasks.Where(t => t.UserId == userId);

            var totalTasks = await userTasks.CountAsync();
            var completedTasks = await userTasks.CountAsync(t => t.IsCompleted);

            var totalTasksToday = await userTasks.CountAsync(t => t.DueDate.HasValue && t.DueDate.Value == today);
            var completedTasksToday = await userTasks.CountAsync(t => t.IsCompleted && t.DueDate.HasValue && t.DueDate.Value == today);

            var TotalGoals = await _context.Goals.CountAsync(g => g.UserId == userId);
            var CompletedGoals = await _context.Goals.CountAsync(g => g.UserId == userId && !g.IsActive);

            return new DashboardStatsViewModel
            {
                TotalTasks = totalTasks,
                CompletedTasks = completedTasks,
                TotalTasksDueToday = totalTasksToday,
                CompletedTasksDueToday = completedTasksToday,
                TotalGoals = TotalGoals,
                CompletedGoals = CompletedGoals
            };
        }
    }
}
