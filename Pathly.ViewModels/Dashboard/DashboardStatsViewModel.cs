namespace Pathly.ViewModels.Dashboard
{
    public class DashboardStatsViewModel
    {
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int TotalTasksDueToday { get; set; }
        public int CompletedTasksDueToday { get; set; }

        public int TotalGoals { get; set; }
        public int CompletedGoals { get; set; }

    }
}
