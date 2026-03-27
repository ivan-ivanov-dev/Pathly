using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathly.Services.Contracts
{
    public interface ISettingsService
    {
        Task<bool> DeleteUserDataAsync(string userId);
    }
}
