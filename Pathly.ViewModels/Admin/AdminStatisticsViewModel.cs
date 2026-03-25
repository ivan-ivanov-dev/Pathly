using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathly.ViewModels.Admin
{
    public class AdminStatisticsViewModel
    {
        public int TotalUsers { get; set; }
        public int TotalGoals { get; set; }
        public int CompletedTasks { get; set; }
        public int NewUsersLast24Hours { get; set; }
    }
}
