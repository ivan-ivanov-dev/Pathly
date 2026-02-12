namespace MicroTaskTracker.Models.ViewModels.Goals
{
    public class ActionItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Resources { get; set; }
        public DateTime? DueDate { get; set; }
    }
}