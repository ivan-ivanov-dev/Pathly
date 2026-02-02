using MicroTaskTracker.Models.DBModels;

namespace MicroTaskTracker.Models.ViewModels
{
    public class TaskQueryModel
    {
        public string? SearchByTitle { get; set; }
        public bool? IsCompleted { get; set; }
        public TaskPriority? Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? Ascending { get; set; }
    }
        
}
