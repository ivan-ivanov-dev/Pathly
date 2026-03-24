using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Pathly.Data;
using Pathly.DataModels;
using Pathly.Services.Contracts;
using Pathly.ViewModels.Roadmaps;
using Pathly.ViewModels.TasksViewModels;

namespace Pathly.Services.Implementation
{
    public class RoadmapService : IRoadmapService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public RoadmapService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> SaveRoadmapAsync(RoadmapCreateViewModel model, string userId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                Roadmap roadmap;

                if (model.IsEditing && model.RoadmapId.HasValue)
                {
                    roadmap = await _context.Roadmaps
                        .Include(r => r.Actions)
                        .FirstOrDefaultAsync(r => r.Id == model.RoadmapId && r.UserId == userId);

                    if (roadmap == null) throw new UnauthorizedAccessException();

                    _mapper.Map(model, roadmap);

                    var incomingActionIds = model.Actions.Select(a => a.Id).Where(id => id.HasValue).ToList();
                    var actionsToRemove = roadmap.Actions.Where(a => !incomingActionIds.Contains(a.Id)).ToList();
                    _context.Actions.RemoveRange(actionsToRemove);

                    foreach (var actionVm in model.Actions.Where(a => !string.IsNullOrWhiteSpace(a.Title)))
                    {
                        if (actionVm.Id.HasValue && actionVm.Id > 0)
                        {
                            var existingAction = roadmap.Actions.FirstOrDefault(a => a.Id == actionVm.Id);
                            if (existingAction != null)
                            {
                                existingAction.Title = actionVm.Title;
                                existingAction.Resources = actionVm.Resources;
                                existingAction.DueDate = actionVm.DueDate;
                            }
                        }
                        else
                        {
                            var newAction = _mapper.Map<ActionItem>(actionVm);
                            newAction.RoadmapId = roadmap.Id;
                            newAction.UserId = userId;

                            _context.Actions.Add(newAction);
                        }
                    }
                }
                else
                {
                    int goalId;

                    if (model.SelectedGoalId.HasValue && model.SelectedGoalId.Value > 0)
                    {
                        goalId = model.SelectedGoalId.Value;
                        var existingGoal = await _context.Goals.FindAsync(goalId);
                        if (existingGoal != null && existingGoal.UserId == userId)
                        {
                            if (!string.IsNullOrWhiteSpace(model.NewGoalTitle))
                            {
                                existingGoal.Title = model.NewGoalTitle;

                            }

                            if (!string.IsNullOrWhiteSpace(model.NewGoalDescription))
                            {
                                existingGoal.ShortDescription = model.NewGoalDescription;

                            }
                        }
                    }
                    else
                    {
                        var newGoal = _mapper.Map<Goal>(model);
                        newGoal.UserId = userId;
                        newGoal.IsActive = true;

                        _context.Goals.Add(newGoal);
                        await _context.SaveChangesAsync();
                        goalId = newGoal.Id;
                    }

                    roadmap = _mapper.Map<Roadmap>(model);
                    roadmap.UserId = userId;
                    roadmap.GoalId = goalId;

                    _context.Roadmaps.Add(roadmap);
                    await _context.SaveChangesAsync();

                    foreach (var actionVm in model.Actions.Where(a => !string.IsNullOrWhiteSpace(a.Title)))
                    {
                        var newAction = _mapper.Map<ActionItem>(actionVm);
                        newAction.RoadmapId = roadmap.Id;
                        newAction.UserId = userId;

                        _context.Actions.Add(newAction);
                    }
                }
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return roadmap.Id;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }


        public async Task<bool> DeleteRoadmapAsync(int roadmapId, string userId)
        {
            var roadmap = await _context.Roadmaps
                    .Include(r => r.Actions)
                    .FirstOrDefaultAsync(r => r.Id == roadmapId);
            if (roadmap == null)
            {
                return false;
            }

            if(roadmap.UserId != userId)
            {
                throw new UnauthorizedAccessException();
            }
            // Remove related actions first to avoid FK constraints
            _context.Actions.RemoveRange(roadmap.Actions);
            _context .Roadmaps.Remove(roadmap);

            return await _context.SaveChangesAsync() > 0;
        }

        public Task<List<Roadmap>> GetAllRoadmapsAsync(string userId)
        {
            var roadmaps = _context.Roadmaps
                .Where(r => r.UserId == userId)
                .Include(r => r.Goal)
                .OrderByDescending(r => r.Id)
                .ToListAsync();

            return roadmaps;
        }

        public async Task<IEnumerable<Goal>> GetAvailableGoalsAsync(string userId)
        {
            return await _context.Goals
                .Where(g => g.UserId == userId && !_context.Roadmaps.Any(r => r.GoalId == g.Id))
                .OrderByDescending(g => g.Id)
                .ToListAsync();
        }

        public async Task<Goal?> GetGoalByIdAsync(int goalId, string userId)
        {
            var goal =  await _context.Goals.FirstOrDefaultAsync(g => g.Id == goalId && g.UserId == userId);
            if(goal == null)
            {
                throw new UnauthorizedAccessException();
            }
            return goal;
        }

        public async Task<RoadmapDetailsViewModel?> GetRoadmapDetailAsync(int roadmapId, string userId)
        {
            var roadmap =  await _context.Roadmaps
            .Where(r => r.Id == roadmapId && r.UserId == userId)
            .ProjectTo<RoadmapDetailsViewModel>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

            if (roadmap == null)
            {
                throw new UnauthorizedAccessException();
            }

            return roadmap;
        }

        public async Task<RoadmapCreateViewModel?> GetRoadmapForEditAsync(int roadmapId, string userId)
        {
            return await _context.Roadmaps
            .Where(r => r.Id == roadmapId && r.UserId == userId)
            .ProjectTo<RoadmapCreateViewModel>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
        }

        public async Task<bool> LinkTaskToActionAsync(int taskId, int actionId, string userId)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == taskId && t.UserId == userId);
            var actionExists = await _context.Actions.AnyAsync(a => a.Id == actionId && a.UserId == userId);

            if (task == null || !actionExists)
            {
                return false;
            }

            task.ActionId = actionId;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<TaskItem>> GetUnlinkedTasksAsync(string userId)
        {
            return await _context.Tasks
                .Where(t => t.UserId == userId && t.ActionId == null)
                .OrderByDescending(t => t.CreatedOn)
                .ToListAsync();
        }

        public async Task<bool> UnlinkTaskFromActionAsync(int taskId, string userId)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);

            if (task == null)
            {
                return false;
            }

            if(task.UserId != userId)
            {
                throw new UnauthorizedAccessException();
            }

            task.ActionId = null;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool?> ToggleTaskCompletionAsync(int taskId, string userId)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);
            if (task == null)
            {
                return null;
            }
            if (task.UserId != userId)
            {
                throw new UnauthorizedAccessException();
            }

            task.IsCompleted = !task.IsCompleted;
            await _context.SaveChangesAsync();

            return task.IsCompleted;
        }
    }
}
