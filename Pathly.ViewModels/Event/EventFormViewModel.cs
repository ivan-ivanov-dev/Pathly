using Microsoft.AspNetCore.Mvc.Rendering;
using Pathly.GCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathly.ViewModels.Event
{
    public class EventFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.TitleIsRequired)]
        [MaxLength(100,ErrorMessage = ErrorMessages.MaxLength)]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        public DateTime Start { get; set; } = DateTime.Now;

        [Required]
        public DateTime End { get; set; } = DateTime.Now.AddHours(1);

        public bool IsAllDay { get; set; }

        public string? Location { get; set; } 

        public string ColorHex { get; set; } = "#0F4C5C";

        public int? TaskId { get; set; }
        public int? GoalId { get; set; }

        public IEnumerable<SelectListItem> AvailableTasks { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> AvailableGoals { get; set; } = new List<SelectListItem>();
    }
}
