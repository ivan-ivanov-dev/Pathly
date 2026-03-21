using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;
using NUnit.Framework;
using Pathly.Data;
using Pathly.DataModels;
using Pathly.Services.Contracts;
using Pathly.Services.Implementation;
using Pathly.Services.Mappings;
using Pathly.ViewModels.Goals;
using Pathly.ViewModels.Tags;
using Pathly.ViewModels.TasksViewModels;
namespace Pathly.Tests;

[TestFixture]
public class TaskServiceTests
{
    private ApplicationDbContext _context;
    private IMapper _mapper;
    private ITaskService _taskService;
    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)) // Ignore transaction warnings for in-memory database
        .Options;

        _context = new ApplicationDbContext(options);

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        _mapper = config.CreateMapper();

        _taskService = new TaskService(_context, _mapper);
    }

    [TearDown]
    public void TearDown()
    {
        if (_context != null)
        {
            _context.Dispose();
        }
    }

    [Test]
    public async Task GetAllTasksAsync_ShouldReturnOnlyUserTasks()
    {
        // Arrange
        var userId = "user1";
        _context.Tasks.Add(new TaskItem { Id = 1, Title = "User Task", UserId = userId, CreatedOn = DateTime.Now });
        _context.Tasks.Add(new TaskItem { Id = 2, Title = "Other Task", UserId = "other", CreatedOn = DateTime.Now });
        await _context.SaveChangesAsync();

        var query = new TaskQueryModel();

        // Act
        var result = await _taskService.GetAllTasksAsync(query, userId);

        // Assert
        Assert.AreEqual(1, result.Tasks.Count());
        Assert.AreEqual("User Task", result.Tasks.First().Title);
    }

    [Test]
    public async Task GetAllTasksAsync_ShouldApplyMultipleFiltersCorrectly()
    {
        // Arrange
        var userId = "user1";
        var tasks = new List<TaskItem>
    {
        new TaskItem { Title = "Buy Milk", Priority = TaskPriority.Low, IsCompleted = false, UserId = userId, CreatedOn = DateTime.Now },
        new TaskItem { Title = "Buy Bread", Priority = TaskPriority.Medium, IsCompleted = false, UserId = userId, CreatedOn = DateTime.Now },
        new TaskItem { Title = "Fix Car", Priority = TaskPriority.Low, IsCompleted = true, UserId = userId, CreatedOn = DateTime.Now }
    };
        _context.Tasks.AddRange(tasks);
        await _context.SaveChangesAsync();

        var query = new TaskQueryModel
        {
            SearchByTitle = "buy",
            Priority = TaskPriority.Low,
            IsCompleted = false
        };

        // Act
        var result = await _taskService.GetAllTasksAsync(query, userId);

        // Assert
        Assert.AreEqual(1, result.Tasks.Count());
        Assert.AreEqual("Buy Milk", result.Tasks.First().Title);
    }

    [Test]
    public async Task GetAllTasksAsync_ShouldFilterBySelectedTags()
    {
        // Arrange
        var userId = "user1";
        var tag = new Tag { Id = 10, Name = "Work", UserId = userId };
        var task1 = new TaskItem { Id = 100, Title = "Task With Tag", UserId = userId, CreatedOn = DateTime.Now };
        var task2 = new TaskItem { Id = 101, Title = "Task Without Tag", UserId = userId, CreatedOn = DateTime.Now };

        var taskTag = new TaskTag { TaskId = 100, TagId = 10 };

        _context.Tags.Add(tag);
        _context.Tasks.AddRange(task1, task2);
        _context.TaskTags.Add(taskTag);
        await _context.SaveChangesAsync();

        var query = new TaskQueryModel { SelectedTagIds = new List<int> { 10 } };

        // Act
        var result = await _taskService.GetAllTasksAsync(query, userId);

        // Assert
        Assert.AreEqual(1, result.Tasks.Count());
        Assert.AreEqual("Task With Tag", result.Tasks.First().Title);
    }

    [Test]
    public async Task GetAllTasksAsync_ShouldSortCorrectly()
    {
        // Arrange
        var userId = "user1";
        var oldTask = new TaskItem { Title = "Old", CreatedOn = DateTime.Now.AddDays(-5), UserId = userId };
        var newTask = new TaskItem { Title = "New", CreatedOn = DateTime.Now, UserId = userId };
        _context.Tasks.AddRange(oldTask, newTask);
        await _context.SaveChangesAsync();

        // Act 1: Descending (default)
        var resultDesc = await _taskService.GetAllTasksAsync(new TaskQueryModel { Ascending = false }, userId);
        // Act 2: Ascending
        var resultAsc = await _taskService.GetAllTasksAsync(new TaskQueryModel { Ascending = true }, userId);

        // Assert
        Assert.AreEqual("New", resultDesc.Tasks.First().Title);
        Assert.AreEqual("Old", resultAsc.Tasks.First().Title);
    }

    [Test]
    public async Task GetAllTasksAsync_ShouldReturnUsersAvailableTags()
    {
        // Arrange
        var userId = "user1";
        _context.Tags.Add(new Tag { Name = "Tag1", UserId = userId });
        _context.Tags.Add(new Tag { Name = "Tag2", UserId = userId });
        _context.Tags.Add(new Tag { Name = "Tag3", UserId = "other" });
        await _context.SaveChangesAsync();

        // Act
        var result = await _taskService.GetAllTasksAsync(new TaskQueryModel(), userId);

        // Assert
        Assert.AreEqual(2, result.AvailableFilterTags.Count);
        Assert.IsTrue(result.AvailableFilterTags.Any(t => t.Name == "Tag1"));
        Assert.IsFalse(result.AvailableFilterTags.Any(t => t.Name == "Tag3"));
    }

    [Test]
    public async Task CreateAsync_ShouldCreateTask_WhenModelIsValid()
    {
        // Arrange
        var userId = "user1";
        var model = new TaskCreateViewModel
        {
            Title = "New Task",
            Description = "Description",
            DueDate = DateTime.Now.AddDays(1)
        };

        // Act
        await _taskService.CreateAsync(model, userId);
        var taskInDb = await _context.Tasks.FirstOrDefaultAsync(t => t.Title == "New Task");

        // Assert
        Assert.IsNotNull(taskInDb);
        Assert.AreEqual(userId, taskInDb.UserId);
        //check default set logic
        Assert.AreEqual(TaskPriority.Low, taskInDb.Priority);
        Assert.IsFalse(taskInDb.IsCompleted);
    }

    [Test]
    public async Task CreateAsync_ShouldLinkTags_WhenSelectedTagIdsAreProvided()
    {
        // Arrange
        var userId = "user1";
        var tagIds = new List<int> { 10, 20 };
        var model = new TaskCreateViewModel
        {
            Title = "Task with Tags",
            SelectedTagIds = tagIds
        };

        // Act
        await _taskService.CreateAsync(model, userId);

        // Assert
        var taskInDb = await _context.Tasks
            .Include(t => t.TaskTags)
            .FirstOrDefaultAsync(t => t.Title == "Task with Tags");

        Assert.IsNotNull(taskInDb);
        Assert.AreEqual(2, taskInDb.TaskTags.Count);
        Assert.IsTrue(taskInDb.TaskTags.Any(tt => tt.TagId == 10));
        Assert.IsTrue(taskInDb.TaskTags.Any(tt => tt.TagId == 20));
    }

    [Test]
    public async Task DeleteAsync_ShouldReturnTrue_WhenTaskIsDeletedSuccessfully()
    {
        // Arrange
        var userId = "user1";
        var task = new TaskItem { Id = 1, Title = "Task To Delete", UserId = userId };
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        // Act
        var result = await _taskService.DeleteAsync(1, userId);
        var taskInDb = await _context.Tasks.FindAsync(1);

        // Assert
        Assert.IsTrue(result);
        Assert.IsNull(taskInDb);
    }

    [Test]
    public async Task DeleteAsync_ShouldReturnFalse_WhenTaskDoesNotExist()
    {
        // Act
        var result = await _taskService.DeleteAsync(999, "any-user");

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void DeleteAsync_ShouldThrowUnauthorized_WhenUserIsNotOwner()
    {
        // Arrange
        var ownerId = "owner";
        var hackerId = "hacker";
        var task = new TaskItem { Id = 5, Title = "Private Task", UserId = ownerId };
        _context.Tasks.Add(task);
        _context.SaveChanges();

        // Act & Assert
        Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            await _taskService.DeleteAsync(5, hackerId));
    }

    [Test]
    public async Task GetDetailsAsync_ShouldReturnATaskWithItsTags_WhenTheTaskExistsAndHasAOwner()
    {
        //Arrange
        var userId = "user1";
        var task = new TaskItem { Id = 1, Title = "Test Task", UserId = userId };
        var tag = new Tag { Id = 2, Name = "Test Tag", UserId = userId};
        var taskTag = new TaskTag { TagId = 2, TaskId = 1 }; 
        _context.Tasks.Add(task);
        _context.Tags.Add(tag); 
        _context.TaskTags.Add(taskTag);
        _context.SaveChanges();

        //Act
        var result = await _taskService.GetDetailsAsync(1,userId);
        var taskInDb = await _context.Tasks.FindAsync(1);

        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(1, taskInDb.TaskTags.Count);
        Assert.AreEqual("Test Task", taskInDb.Title);
    }

    [Test]
    public void GetDetailsAsync_ShouldThrowUnathorized_WhenUserIsNotTheOwner()
    {
        // Arrange
        var ownerId = "owner";
        var hackerId = "hacker";
        var task = new TaskItem { Id = 5, Title = "Private Task", UserId = ownerId };
        _context.Tasks.Add(task);
        _context.SaveChanges();

        // Act & Assert
        Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            await _taskService.GetDetailsAsync(5, hackerId));
    }

    [Test]
    public async Task GetTaskTagIdsAsync_ShouldReturnCorrectIds_WhenTaskExists()
    {
        // Arrange
        var userId = "user1";
        var task = new TaskItem { Id = 1, Title = "Task", UserId = userId };
        _context.Tasks.Add(task);
        _context.TaskTags.AddRange(
            new TaskTag { TaskId = 1, TagId = 10 },
            new TaskTag { TaskId = 1, TagId = 20 }
        );
        await _context.SaveChangesAsync();

        // Act
        var result = await _taskService.GetTaskTagIdsAsync(1, userId);

        // Assert
        Assert.AreEqual(2, result.Count);
        Assert.Contains(10, result);
        Assert.Contains(20, result);
    }

    [Test]
    public void GetTaskTagIdsAsync_ShouldThrowInvalidOperation_WhenTaskIsNotFound()
    {
        // Act & Assert
        var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await _taskService.GetTaskTagIdsAsync(999, "any-user"));

        Assert.AreEqual("Task not found", ex.Message);
    }

    [Test]
    public async Task MarkTaskStatusAsync_ShouldToggleStatusCorrectly()
    {
        // Arrange
        var userId = "user1";
        var task = new TaskItem { Id = 1, Title = "Task", UserId = userId, IsCompleted = false };
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        // Act + Assert 1: False -> True
        await _taskService.MarkTaskStatusAsync(1, userId);
        var taskAfterFirstToggle = await _context.Tasks.FindAsync(1);
        Assert.IsTrue(taskAfterFirstToggle.IsCompleted);

        // Act + Assert 2: True -> False
        await _taskService.MarkTaskStatusAsync(1, userId);
        var taskAfterSecondToggle = await _context.Tasks.FindAsync(1);
        Assert.IsFalse(taskAfterSecondToggle.IsCompleted);
    }

    [Test]
    public void MarkTaskStatusAsync_ShouldThrowInvalidOperation_WhenTaskDoesNotExist()
    {
        // Act & Assert
        var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await _taskService.MarkTaskStatusAsync(999, "any-user"));
        Assert.AreEqual(ex.Message, "Task not found");
    }

    [Test]
    public void MarkTaskStatusAsync_ShouldThrowUnauthorized_WhenUserIsNotOwner()
    {
        // Arrange
        var ownerId = "owner";
        var hackerId = "hacker";
        var task = new TaskItem { Id = 10, Title = "Private", UserId = ownerId };
        _context.Tasks.Add(task);
        _context.SaveChanges();

        // Act & Assert
        Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            await _taskService.MarkTaskStatusAsync(10, hackerId));
    }

    [Test]
    public async Task UpdatePriorityAsync_ShouldChangePriority_WhenTaskExistsAndIsOwned()
    {
        // Arrange
        var userId = "user1";
        var task = new TaskItem { Id = 1, Title = "Task", UserId = userId, Priority = TaskPriority.Low };
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        // Act
        await _taskService.UpdatePriorityAsync(1, TaskPriority.High, userId);

        // Assert
        var updatedTask = await _context.Tasks.FindAsync(1);
        Assert.AreEqual(TaskPriority.High, updatedTask.Priority);
    }

    [Test]
    public void UpdatePriorityAsync_ShouldThrowInvalidOperation_WhenTaskNotFound()
    {
        // Act & Assert
        var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await _taskService.UpdatePriorityAsync(999, TaskPriority.Medium, "any-user"));
        Assert.AreEqual(ex.Message, "Task not found");
    }

    [Test]
    public void UpdatePriorityAsync_ShouldThrowUnauthorized_WhenUserIsNotOwner()
    {
        // Arrange
        _context.Tasks.Add(new TaskItem { Id = 10, Title = "Other", UserId = "owner" });
        _context.SaveChanges();

        // Act & Assert
        Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            await _taskService.UpdatePriorityAsync(10, TaskPriority.High, "hacker"));
    }

    [Test]
    public async Task UpdateWithTagsAsync_ShouldUpdateTaskDetailsAndRefreshTags()
    {
        // Arrange
        var userId = "user1";
        var task = new TaskItem
        {
            Id = 1,
            Title = "Old Title",
            UserId = userId,
            TaskTags = new List<TaskTag> { new TaskTag { TagId = 10, TaskId = 1 } } // Old Tag
        };
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        var model = new TaskEditViewModel
        {
            Title = "Updated Title",
            Description = "New Description",
            SelectedTagIds = new List<int> { 20, 30 } //New Tags
        };

        // Act
        await _taskService.UpdateWithTagsAsync(1, model, userId);
        var updatedTask = await _context.Tasks.Include(t => t.TaskTags).FirstOrDefaultAsync(t => t.Id == 1);

        // Assert
        Assert.AreEqual("Updated Title", updatedTask.Title);
        Assert.AreEqual(2, updatedTask.TaskTags.Count);
        Assert.IsTrue(updatedTask.TaskTags.Any(tt => tt.TagId == 20));
        Assert.IsTrue(updatedTask.TaskTags.Any(tt => tt.TagId == 30));
        Assert.IsFalse(updatedTask.TaskTags.Any(tt => tt.TagId == 10), "Old tag should be removed.");
    }

    [Test]
    public void UpdateWithTagsAsync_ShouldThrowInvalidOperation_WhenTaskDoesNotExist()
    {
        // Act & Assert
        var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await _taskService.UpdateWithTagsAsync(999, new TaskEditViewModel(), "any-user"));
        Assert.AreEqual(ex.Message, "Task not found");
    }

    [Test]
    public void UpdateWithTagsAsync_ShouldThrowUnauthorized_WhenUserIsHacker()
    {
        // Arrange
        _context.Tasks.Add(new TaskItem { Id = 5, Title = "Private", UserId = "owner" });
        _context.SaveChanges();

        // Act & Assert
        Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            await _taskService.UpdateWithTagsAsync(5, new TaskEditViewModel(), "hacker"));
    }
}
