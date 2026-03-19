using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Pathly.Data;
using Pathly.DataModels;
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

            if (queryModel.Ascending.HasValue && queryModel.Ascending.Value)
            {
                tasksQuery = tasksQuery.OrderBy(t => t.CreatedOn);
            }
            else
            {
                tasksQuery = tasksQuery.OrderByDescending(t => t.CreatedOn);
            }

            var tasks = await tasksQuery
                .ProjectTo<TaskViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var userTags = await _context.Tags
                .Where(tag => tag.UserId == userId)
                .ProjectTo<TagViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var result = new TaskListViewModel
            {
                Tasks = tasks,
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

            await _context.SaveChangesAsync();
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
