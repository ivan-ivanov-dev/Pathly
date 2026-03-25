using Microsoft.EntityFrameworkCore.Diagnostics;
using Pathly.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathly.Services.Contracts
{
    public interface IAdminService
    {
        Task<IEnumerable<UserListViewModel>> GetAllUsersAsync();
        Task<bool> DeleteUserAsync(string userId);

    }
}
