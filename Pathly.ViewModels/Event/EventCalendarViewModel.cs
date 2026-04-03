using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathly.ViewModels.Event
{
    public class EventCalendarViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Start { get; set; } = null!; // String format for JS
        public string End { get; set; } = null!; // String format for JS
        public bool AllDay { get; set; }
        public string Color { get; set; } = null!;
        public string? Description { get; set; }
    }
}
