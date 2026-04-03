using Pathly.ViewModels.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathly.Services.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<EventCalendarViewModel>> GetAllForCalendarAsync(string userId);
        Task<EventFormViewModel?> GetForEditAsync(int id, string userId);
        Task CreateAsync(EventFormViewModel model, string userId);
        Task UpdateAsync(EventFormViewModel model, string userId);
        Task DeleteAsync(int id, string userId);

        // UI Helper
        Task<EventFormViewModel> PrepareFormModelAsync(string userId);
    }
}
