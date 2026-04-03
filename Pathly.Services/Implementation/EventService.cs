using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pathly.Data;
using Pathly.DataModels;
using Pathly.GCommon;
using Pathly.Services.Contracts;
using Pathly.ViewModels.Event;

namespace Pathly.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EventService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventCalendarViewModel>> GetAllForCalendarAsync(string userId)
        {
            var events = await _context.Events
                .Where(e => e.UserId == userId)
                .ToListAsync();

            if(events == null || !events.Any())
            {
                throw new InvalidOperationException(ErrorMessages.NoEventsFound);
            }

            return _mapper.Map<IEnumerable<EventCalendarViewModel>>(events);
        }

        public async Task<EventFormViewModel> PrepareFormModelAsync(string userId)
        {
            var model = new EventFormViewModel();

            // Only fetch Tasks that aren't finished to keep the list shorter
            model.AvailableTasks = await _context.Tasks
                .Where(t => t.UserId == userId && t.Status != DataModels.TaskStatus.Done)
                .Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Title
                })
                .ToListAsync();

            // Only fetch active Goals
            model.AvailableGoals = await _context.Goals
                .Where(g => g.UserId == userId)
                .Select(g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.Title
                })
                .ToListAsync();

            return model;
        }

        public async Task CreateAsync(EventFormViewModel model, string userId)
        {
            if (model.End <= model.Start)
            {
                throw new ArgumentException(ErrorMessages.EndDateMustBeAfterStartDate);
            }

            await ModelIsValid(model, userId);

            var newEvent = _mapper.Map<Event>(model);
            newEvent.UserId = userId;
            newEvent.CreatedOn = DateTime.UtcNow;

            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();
        }

        public async Task<EventFormViewModel?> GetForEditAsync(int id, string userId)
        {
            var @event = await _context.Events
                .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

            if (@event == null)
            {
                throw new UnauthorizedAccessException(ErrorMessages.EventNotFoundOrAccessDenied);
            }

            var model = _mapper.Map<EventFormViewModel>(@event);

            model.Id = @event.Id;

            var listData = await PrepareFormModelAsync(userId);
            model.AvailableTasks = listData.AvailableTasks;
            model.AvailableGoals = listData.AvailableGoals;

            return model;
        }

        public async Task UpdateAsync(EventFormViewModel model, string userId)
        {
            var existingEvent = await _context.Events
                .FirstOrDefaultAsync(e => e.Id == model.Id && e.UserId == userId);

            if (existingEvent == null)
            {
                throw new UnauthorizedAccessException(ErrorMessages.EventNotFoundOrAccessDenied);
            }

            await ModelIsValid(model, userId);

            _mapper.Map(model, existingEvent);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, string userId)
        {
            var @event = await _context.Events
                .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

            if (@event == null)
            {
                throw new UnauthorizedAccessException(ErrorMessages.EventNotFoundOrAccessDenied);
            }

            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
        }

        private async Task ModelIsValid(EventFormViewModel model, string userId)
        {

            if (model.End <= model.Start)
            {
                throw new ArgumentException(ErrorMessages.EndDateMustBeAfterStartDate);
            }

            if (model.Start < DateTime.UtcNow)
            {
                throw new ArgumentException(ErrorMessages.StartDateCannotBeInThePast);
            }

            if (model.TaskId.HasValue)
            {
                var taskExists = await _context.Tasks.AnyAsync(t => t.Id == model.TaskId && t.UserId == userId);
                if (!taskExists)
                {
                    throw new ArgumentException(ErrorMessages.SelectedTaskDoesNotExist);
                }
            }

            if (model.GoalId.HasValue)
            {
                var goalExists = await _context.Goals.AnyAsync(g => g.Id == model.GoalId && g.UserId == userId);
                if (!goalExists)
                {
                    throw new ArgumentException(ErrorMessages.SelectedGoalDoesNotExist);
                }
            }
        }

    }
    
}