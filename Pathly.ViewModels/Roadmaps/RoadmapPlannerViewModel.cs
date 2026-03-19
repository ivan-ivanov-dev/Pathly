using Pathly.DataModels;
using Pathly.ViewModels.TasksViewModels;

namespace Pathly.ViewModels.Roadmaps
{
    // This view model is used to display the roadmap planner page,
    // where users can see unlinked tasks and link them to actions.
    public class RoadmapPlannerViewModel
    {
        public int TargetActionId { get; set; }
        public int RoadmapId { get; set; } 
        public IEnumerable<TaskViewModel> UnlinkedTasks { get; set; }
    }
}
