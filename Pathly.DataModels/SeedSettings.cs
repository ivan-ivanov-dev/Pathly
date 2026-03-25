using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathly.DataModels
{
    public class SeedSettings
    {
        public string AdminPassword { get; set; } = null!;
        public string TestUserPassword { get; set; } = null!;
    }
}
