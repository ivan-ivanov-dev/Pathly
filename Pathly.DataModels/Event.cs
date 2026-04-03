using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pathly.GCommon;

namespace Pathly.DataModels
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [StringLength(100, MinimumLength = 3, ErrorMessage = ErrorMessages.MaxLength)]
        public string Title { get; set; } = null!;

        [StringLength(500, ErrorMessage = ErrorMessages.MaxLength)]
        public string? Description { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public DateTime Start { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public DateTime End { get; set; }

        public bool IsAllDay { get; set; }

        [StringLength(150, ErrorMessage = ErrorMessages.MaxLength)]
        public string? Location { get; set; }

        [Required]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = ErrorMessages.InvalidColor)] // Simple regex for validating hex color codes
        public string ColorHex { get; set; } = "#0F4C5C";

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;


        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        public int? TaskId { get; set; }

        [ForeignKey(nameof(TaskId))]
        public TaskItem? Task { get; set; }

        public int? GoalId { get; set; }

        [ForeignKey(nameof(GoalId))]
        public Goal? Goal { get; set; }
    }
}