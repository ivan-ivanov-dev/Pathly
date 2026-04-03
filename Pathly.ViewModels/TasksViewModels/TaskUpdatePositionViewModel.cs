using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathly.ViewModels.TasksViewModels
{
    public class TaskUpdatePositionViewModel
    {
        public int Id { get; set; }
        public DataModels.TaskStatus NewStatus { get; set; }
        public int NewPosition { get; set; }
    }
}
