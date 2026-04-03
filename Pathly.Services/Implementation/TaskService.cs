using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Pathly.Data;
using Pathly.DataModels;
using Pathly.GCommon;
using Pathly.Services.Contracts;
using Pathly.ViewModels.Tags;
using Pathly.ViewModels.TasksViewModels;

namespace Pathly.Services.Implementation
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public TaskService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task CreateAsync(TaskCreateViewModel model, string userId)
        {

            var task = _mapper.Map<TaskItem>(model);
            task.UserId = userId;
            task.CreatedOn = DateTime.UtcNow;
            task.IsCompleted = false;
            task.Priority = TaskPriority.Low;

            if (model.SelectedTagIds != null && model.SelectedTagIds.Any())
            {
                task.TaskTags = model.SelectedTagIds.Select(tagId => new TaskTag
                {

                    TagId = tagId

                }).ToList();
            }
            
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id, string userId)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return false;
            }

            if(task.UserId != userId)
            {
                throw new UnauthorizedAccessException();
            }
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TaskListViewModel> GetAllTasksAsync(TaskQueryModel queryModel, string userId)
        {
            var tasksQuery = _context.Tasks
                .Include(t => t.TaskTags)
                    .ThenInclude(tt => tt.Tag)
                .Where(u => u.UserId == userId)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.SearchByTitle))
            {
                tasksQuery = tasksQuery.Where(t => t.Title.ToLower().Contains(queryModel.SearchByTitle.ToLower()));
            }

            if (queryModel.IsCompleted.HasValue)
            {
                tasksQuery = tasksQuery.Where(t => t.IsCompleted == queryModel.IsCompleted.Value);
            }

            if (queryModel.Priority.HasValue)
            {
                tasksQuery = tasksQuery.Where(t => t.Priority == queryModel.Priority.Value);
            }

            if (queryModel.DueDate.HasValue)
            {
                tasksQuery = tasksQuery.Where(t => t.DueDate.HasValue && t.DueDate.Value.Date == queryModel.DueDate.Value.Date);
            }

            if (queryModel.SelectedTagIds != null && queryModel.SelectedTagIds.Any())
            {
                tasksQuery = tasksQuery.Where(t => t.TaskTags.Any(tt => queryModel.SelectedTagIds.Contains(tt.TagId)));
            }

            if (queryModel.Ascending.HasValue)
            {
                tasksQuery = queryModel.Ascending.Value
                    ? tasksQuery.OrderBy(t => t.Status).ThenBy(t => t.CreatedOn)
                    : tasksQuery.OrderBy(t => t.Status).ThenByDescending(t => t.CreatedOn);
            }
            else
            {
                tasksQuery = tasksQuery.OrderBy(t => t.Status).ThenBy(t => t.Position);
            }

            var pagedTasks = await PagedList<TaskViewModel>.ToPagedListAsync(
                tasksQuery.ProjectTo<TaskViewModel>(_mapper.ConfigurationProvider),
                queryModel.PageNumber,
                queryModel.PageSize);

            var userTags = await _context.Tags
                .Where(tag => tag.UserId == userId)
                .ProjectTo<TagViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var result = new TaskListViewModel
            {
                Tasks = pagedTasks,
                AvailableFilterTags = _mapper.Map<List<Tag>>(userTags)
            };

            return result;
        }

        public async Task<TaskDetailsViewModel?> GetDetailsAsync(int id, string userId)
        {
            var task = await _context.Tasks
                .Where(t => t.Id == id && t.UserId == userId)
                .ProjectTo<TaskDetailsViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (task == null)
            {
                throw new UnauthorizedAccessException();
            }

            return task;
        }

        public async Task<List<int>> GetTaskTagIdsAsync(int taskId, string userId)
        {
            var task = await _context.Tasks
                .FirstOrDefaultAsync(t => t.Id == taskId && t.UserId == userId);

            if (task == null)
            {
                throw new InvalidOperationException("Task not found");
            }

            return await _context.TaskTags
                .Where(tt => tt.TaskId == taskId)
                .Select(tt => tt.TagId)
                .ToListAsync();
        }

        public async Task MarkTaskStatusAsync(int id, string userId)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                throw new InvalidOperationException("Task not found");
            }
            if (task.UserId != userId)
            {
                throw new UnauthorizedAccessException();
            }

            task.IsCompleted = !task.IsCompleted;

            task.Status = task.IsCompleted
                ? DataModels.TaskStatus.Done
                : DataModels.TaskStatus.Todo;

            await _context.SaveChangesAsync();
            return task.IsCompleted;
        }

        public async Task UpdatePriorityAsync(int id, TaskPriority priority, string userId)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                throw new InvalidOperationException("Task not found");
            }
            if (task.UserId != userId)
            {
                throw new UnauthorizedAccessException();
            }

            task.Priority =priority;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskPositionAsync(int id, string userId, DataModels.TaskStatus newStatus, int newPosition)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
                if (task == null)
                {
                    throw new InvalidOperationException("Task not found");
                }

                var oldStatus = task.Status;
                var oldPosition = task.Position;

                if (oldStatus != newStatus)
                {
                    await _context.Tasks
                        .Where(t => t.UserId == userId && t.Status == oldStatus && t.Position > oldPosition)
                        .ExecuteUpdateAsync(s => s.SetProperty(t => t.Position, t => t.Position - 1));

                    await _context.Tasks
                        .Where(t => t.UserId == userId && t.Status == newStatus && t.Position >= newPosition)
                        .ExecuteUpdateAsync(s => s.SetProperty(t => t.Position, t => t.Position + 1));
                }
                else if (oldPosition != newPosition)
                {
                    if (newPosition < oldPosition)
                    {
                        await _context.Tasks
                            .Where(t => t.UserId == userId && t.Status == oldStatus && t.Position >= newPosition && t.Position < oldPosition)
                            .ExecuteUpdateAsync(s => s.SetProperty(t => t.Position, t => t.Position + 1));
                    }
                    else
                    {
                        await _context.Tasks
                            .Where(t => t.UserId == userId && t.Status == oldStatus && t.Position > oldPosition && t.Position <= newPosition)
                            .ExecuteUpdateAsync(s => s.SetProperty(t => t.Position, t => t.Position - 1));
                    }
                }

                task.Status = newStatus;
                task.Position = newPosition;
                task.IsCompleted = (newStatus == DataModels.TaskStatus.Done);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }

        }

        public async Task UpdateWithTagsAsync(int id, TaskEditViewModel model, string userId)
        {
            var task = await _context.Tasks
                .Include(t=>t.TaskTags)
                .FirstOrDefaultAsync(t=>t.Id == id );
            if(task == null)
            {
                throw new InvalidOperationException("Task not found");
            }

            if(task.UserId != userId)
            {
                throw new UnauthorizedAccessException();
            }

            _mapper.Map(model, task);
            _context.TaskTags.RemoveRange(task.TaskTags);

            task.TaskTags = model.SelectedTagIds.Select(tagId => new TaskTag
            {
                TaskId = task.Id,
                TagId = tagId
            }).ToList();

            await _context.SaveChangesAsync();
        } 
    }
}
