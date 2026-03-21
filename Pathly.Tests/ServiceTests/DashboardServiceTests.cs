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
namespace Pathly.Tests;

[TestFixture]
public class DashboardServiceTests
{
    private ApplicationDbContext _context;
    private IMapper _mapper;
    private IDashboardService _dashboardService;
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

        _dashboardService = new DashboardService(_mapper,_context);
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
    public async Task GetDashboardFocusListsAsync_ShouldCategorizeTasksCorrectly()
    {
        // Arrange
        var userId = "user1";
        var today = DateTime.UtcNow.Date;

        var tasks = new List<TaskItem>
    {
        // 1. Due Today
        new TaskItem { Title = "Today 1", DueDate = today, UserId = userId },
        new TaskItem { Title = "Today 2", DueDate = today, UserId = userId },
        
        // 2. Overdue (Yesterday and not completed)
        new TaskItem { Title = "Overdue 1", DueDate = today.AddDays(-1), IsCompleted = false, UserId = userId },
        new TaskItem { Title = "Completed Old", DueDate = today.AddDays(-1), IsCompleted = true, UserId = userId },  //Should not be in the List
        
        // 3. Future High Priority
        new TaskItem { Title = "Future High", DueDate = today.AddDays(1), Priority = TaskPriority.High, UserId = userId },
        new TaskItem { Title = "Future Critical", DueDate = today.AddDays(2), Priority = TaskPriority.Critical, UserId = userId },
        new TaskItem { Title = "Future Low", DueDate = today.AddDays(1), Priority = TaskPriority.Low, UserId = userId } //Should not be in the List
    };

        _context.Tasks.AddRange(tasks);
        await _context.SaveChangesAsync();

        // Act
        var result = await _dashboardService.GetDashboardFocusListsAsync(userId);

        // Assert
        Assert.AreEqual(2, result.DueTodayTasks.Count());
        Assert.AreEqual(1, result.OverdueTasks.Count());
        Assert.AreEqual(2, result.FutureHighPriorityTasks.Count());

        Assert.IsTrue(result.DueTodayTasks.Any(t => t.Title == "Today 1"));
        Assert.IsTrue(result.OverdueTasks.Any(t => t.Title == "Overdue 1"));
        Assert.IsTrue(result.FutureHighPriorityTasks.Any(t => t.Title == "Future High"));
    }

    [Test]
    public async Task GetDashboardFocusListsAsync_ShouldApplyTakeLimit()
    {
        // Arrange
        var userId = "user1";
        var today = DateTime.UtcNow.Date;

        // Add 10 tasks for today
        for (int i = 0; i < 10; i++)
        {
            _context.Tasks.Add(new TaskItem { Title = $"Task {i}", DueDate = today, UserId = userId });
        }
        await _context.SaveChangesAsync();

        // Act
        var result = await _dashboardService.GetDashboardFocusListsAsync(userId);

        // Assert
        Assert.AreEqual(5, result.DueTodayTasks.Count());//Takes only 5
    }

    [Test]
    public async Task GetDashboardStatsAsync_ShouldCalculateCorrectStatistics()
    {
        // Arrange
        var userId = "user1";
        var today = DateTime.UtcNow.Date;

        //Tasks
        _context.Tasks.AddRange(
            new TaskItem { Title = "T1", IsCompleted = true, UserId = userId, DueDate = today },
            new TaskItem { Title = "T2", IsCompleted = false, UserId = userId, DueDate = today },
            new TaskItem { Title = "T3", IsCompleted = true, UserId = userId, DueDate = today.AddDays(-5) }
        );

        //Goals
        _context.Goals.AddRange(
            new Goal { Title = "G1", IsActive = false, UserId = userId },
            new Goal { Title = "G2", IsActive = true, UserId = userId },
            new Goal { Title = "G3", IsActive = true, UserId = "other-user" } // Should't get counted
        );

        await _context.SaveChangesAsync();

        // Act
        var result = await _dashboardService.GetDashboardStatsAsync(userId);

        // Assert

        // Tasks
        Assert.AreEqual(3, result.TotalTasks);
        Assert.AreEqual(2, result.CompletedTasks);
        Assert.AreEqual(2, result.TotalTasksDueToday);
        Assert.AreEqual(1, result.CompletedTasksDueToday);

        // Goals
        Assert.AreEqual(2, result.TotalGoals);
        Assert.AreEqual(1, result.CompletedGoals);
    }

    [Test]
    public async Task GetDashboardStatsAsync_ShouldReturnZeros_WhenUserHasNoData()
    {
        // Act
        var result = await _dashboardService.GetDashboardStatsAsync("new-user");

        // Assert
        Assert.AreEqual(0, result.TotalTasks);
        Assert.AreEqual(0, result.TotalGoals);
        Assert.AreEqual(0, result.CompletedTasksDueToday);
    }
}
