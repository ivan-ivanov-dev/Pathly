using Pathly.GCommon;

namespace Pathly.ViewModels.Goals
{
    public class GoalListViewModel
    {
        public PagedList<GoalViewModel> Goals { get; set; } = null!;
    }
}
