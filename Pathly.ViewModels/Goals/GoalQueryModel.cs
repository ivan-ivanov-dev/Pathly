namespace Pathly.ViewModels.Goals
{
    public class GoalQueryModel
    {
        public string? SearchTerm { get; set; }
        public GoalSortOrder SortOrder { get; set; } = GoalSortOrder.TitleAsc;
        public GoalListViewModel Goals { get; set; } = new GoalListViewModel();
        public bool? ShowCompleted { get; set; }
        public DateTime? TargetDate { get; set; }
    }

    public enum GoalSortOrder
    {
        TitleAsc = 0,
        TitleDesc = 1
    }

}
