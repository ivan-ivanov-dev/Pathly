using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Pathly.Data;
using Pathly.DataModels;
using Pathly.Services.Implementation;
using Pathly.Services.Mappings;
using Pathly.ViewModels.Goals;
using Pathly.ViewModels.Tags;
namespace Pathly.Tests;

[TestFixture]
public class GoalServiceTests
{
    private ApplicationDbContext _context;
    private IMapper _mapper;
    private GoalService _goalService;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

        _context = new ApplicationDbContext(options);
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        _mapper = config.CreateMapper();

        _goalService = new GoalService(_context, _mapper);
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
    public async Task CreateAsync_ShouldAddGoalToDatabase()
    {
        // Arrange
        var model = new GoalCreateViewModel
        {
            Title = "Test Goal",
            ShortDescription = "This is a test goal."
        };
        var userId = "test-user-id";

        // Act
        await _goalService.CreateAsync(model, userId);
        var goalInDb = await _context.Goals.FirstOrDefaultAsync(g => g.Title == model.Title);

        // Assert
        Assert.IsNotNull(goalInDb);
        Assert.AreEqual(model.ShortDescription, goalInDb.ShortDescription);
        Assert.AreEqual(userId, goalInDb.UserId);
    }

    [Test]
    public async Task DeleteAsync_ShouldReturnTrue_WhenSuccessfull()
    {
        // Arrange
        var goal = new Goal
        {
            Title = "Goal to Delete",
            ShortDescription = "This goal will be deleted.",
            UserId = "test-user-id"
        };
        _context.Goals.Add(goal);
        await _context.SaveChangesAsync();

        // Act
        var result = await _goalService.DeleteAsync(goal.Id, goal.UserId);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public async Task DeleteAsync_ShouldReturnFalse_WhenGoalDoesNotExist()
    {
        // Arrange
        var nonExistentGoalId = 999;
        // Act
        var result = await _goalService.DeleteAsync(nonExistentGoalId, "test-user-id");
        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public async Task DeleteAsync_ShouldThrow_WhenUserUnauthorized()
    {
        // Arrange
        var goal = new Goal
        {
            Title = "Goal to Delete",
            ShortDescription = "This goal will be deleted.",
            UserId = "owner-user-id"
        };

        _context.Goals.Add(goal);
        await _context.SaveChangesAsync();

        // Act & Assert
        var ex = Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            await _goalService.DeleteAsync(goal.Id, "unauthorized-user-id"));
        Assert.That(ex.Message, Is.EqualTo("You do not have permission to delete this goal."));
    }

    [Test]
    public async Task DeleteAsync_ShouldRemoveAssociatedRoadmapAndActions()
    {
        // Arrange
        var goal = new Goal
        {
            Title = "Goal with Roadmap",
            ShortDescription = "This goal has a roadmap.",
            UserId = "test-user-id"
        };

        _context.Goals.Add(goal);
        await _context.SaveChangesAsync();

        var roadmap = new Roadmap
        {
            Id = 1,
            GoalId = goal.Id,
            UserId = goal.UserId
        };

        _context.Roadmaps.Add(roadmap);
        await _context.SaveChangesAsync();

        var actionItem = new ActionItem
        {
            Title = "Associated Action",
            RoadmapId = roadmap.Id,
            UserId = roadmap.UserId
        };

        _context.Actions.Add(actionItem);
        await _context.SaveChangesAsync();

        // Act
        var result = await _goalService.DeleteAsync(goal.Id, goal.UserId);
        var goalInDb = await _context.Goals.FindAsync(goal.Id);
        var roadmapInDb = await _context.Roadmaps.FindAsync(roadmap.Id);
        var actionInDb = await _context.Actions.FindAsync(actionItem.Id);

        // Assert
        Assert.IsTrue(result);
        Assert.IsNull(goalInDb);
        Assert.IsNull(roadmapInDb);
        Assert.IsNull(actionInDb);
    }

    [Test]
    public async Task GetAllAsync_ShouldFilterGoalsCorrectly_WhenGivenASearchTerm()
    {
        // Arrange
        var userId = "test-user-id";
        var goal1 = new Goal { Title = "First Goal", ShortDescription = "First", UserId = userId };
        var goal2 = new Goal { Title = "Second Goal", ShortDescription = "Second", UserId = userId };
        var goal3 = new Goal { Title = "Another Goal", ShortDescription = "Another", UserId = userId };
        _context.Goals.AddRange(goal1, goal2, goal3);
        await _context.SaveChangesAsync();
        var queryModel = new GoalQueryModel { SearchTerm = "First" };
        // Act
        var result = await _goalService.GetAllAsync(queryModel, userId);
        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Goals.Goals.Count);
        Assert.AreEqual("First Goal", result.Goals.Goals.First().Title);
    }

    [Test]
    public async Task GetAllAsync_ShouldReturnEmptyList_WhenNoGoalsMatchSearchTerm()
    {
        // Arrange
        var userId = "test-user-id";
        var goal1 = new Goal { Title = "First Goal", ShortDescription = "First", UserId = userId };
        var goal2 = new Goal { Title = "Second Goal", ShortDescription = "Second", UserId = userId };
        _context.Goals.AddRange(goal1, goal2);
        await _context.SaveChangesAsync();
        var queryModel = new GoalQueryModel { SearchTerm = "NonExistent" };
        // Act
        var result = await _goalService.GetAllAsync(queryModel, userId);
        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(0, result.Goals.Goals.Count);
    }

    [Test]
    public async Task GetAllAsync_ShouldReturnAllGoals_WhenSearchTermIsEmpty()
    {
        // Arrange
        var userId = "test-user-id";
        var goal1 = new Goal { Title = "First Goal", ShortDescription = "First", UserId = userId };
        var goal2 = new Goal { Title = "Second Goal", ShortDescription = "Second", UserId = userId };
        _context.Goals.AddRange(goal1, goal2);
        await _context.SaveChangesAsync();
        var queryModel = new GoalQueryModel { SearchTerm = "" };
        // Act
        var result = await _goalService.GetAllAsync(queryModel, userId);
        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Goals.Goals.Count);
    }

    [Test]
    public async Task GetAllAsync_ShouldOrderCorrectly_WhenInAscendingOrder()
    {
        // Arrange
        var userId = "test-user-id";
        var goal1 = new Goal { Title = "B Goal", ShortDescription = "Second", UserId = userId };
        var goal2 = new Goal { Title = "A Goal", ShortDescription = "First", UserId = userId };
        _context.Goals.AddRange(goal1, goal2);
        await _context.SaveChangesAsync();
        var queryModel = new GoalQueryModel { SearchTerm = "Goal", SortOrder = 0 };
        // Act
        var result = await _goalService.GetAllAsync(queryModel, userId);
        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Goals.Goals.Count);
        Assert.AreEqual("A Goal", result.Goals.Goals.First().Title);
    }
    [Test]
    public async Task GetAllAsync_ShouldOrderCorrectly_WhenInDescendingOrder()
    {
        // Arrange
        var userId = "test-user-id";
        var goal1 = new Goal { Title = "A Goal", ShortDescription = "First", UserId = userId };
        var goal2 = new Goal { Title = "B Goal", ShortDescription = "Second", UserId = userId };
        _context.Goals.AddRange(goal1, goal2);
        await _context.SaveChangesAsync();
        var queryModel = new GoalQueryModel { SearchTerm = "Goal", SortOrder = (GoalSortOrder)1 };
        // Act
        var result = await _goalService.GetAllAsync(queryModel, userId);
        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Goals.Goals.Count);
        Assert.AreEqual("B Goal", result.Goals.Goals.First().Title);
    }
    [Test]
    public async Task GetDetailsAsync_ShouldThrow_WhenUserUnauthorized()
    {
        // Arrange
        var ownerUserId = "owner-user-id";
        var unauthorizedUserId = "unauthorized-user-id";
        var goal = new Goal { Id = 1, Title = "Test Goal", ShortDescription = "Test", UserId = ownerUserId };
        _context.Goals.Add(goal);
        await _context.SaveChangesAsync();

        // Act & Assert
        var ex = Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            await _goalService.GetDetailsAsync(goal.Id, unauthorizedUserId));
        Assert.That(ex.Message, Is.EqualTo("You do not have permission to view this goal."));
    }

    [Test]
    public async Task ToggleGoalStatusAsync_ShouldToggleStatusCorrectly()
    {
        // Arrange
        var userId = "test-user-id";
        var goal = new Goal { Id = 1, Title = "Test Goal", ShortDescription = "Test", UserId = userId, IsActive = false };
        _context.Goals.Add(goal);
        await _context.SaveChangesAsync();
        // Act
        await _goalService.ToggleGoalStatusAsync(goal.Id, userId);
        var updatedGoal = await _context.Goals.FindAsync(goal.Id);
        // Assert
        Assert.That(updatedGoal.IsActive, Is.True);
    }

    [Test]
    public async Task ToggleGoalStatusAsync_ShouldThrow_WhenUserUnauthorized()
    {
        // Arrange
        var ownerUserId = "owner-user-id";
        var unauthorizedUserId = "unauthorized-user-id";
        var goal = new Goal { Id = 1, Title = "Test Goal", ShortDescription = "Test", UserId = ownerUserId, IsActive = false };
        _context.Goals.Add(goal);
        await _context.SaveChangesAsync();
        // Act & Assert
        var ex = Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            await _goalService.ToggleGoalStatusAsync(goal.Id, unauthorizedUserId));
        Assert.That(ex.Message, Is.EqualTo("You do not have permission to edit this goal."));
    }

    [Test]
    public async Task ToggleGoalStatusAsync_ShouldThrow_WhenGoalDoesNotExist()
    {
        // Arrange
        var userId = "test-user-id";
        var nonExistentGoalId = 999;
        // Act & Assert
        var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await _goalService.ToggleGoalStatusAsync(nonExistentGoalId, userId));
        Assert.That(ex.Message, Is.EqualTo("Goal not found."));
    }

    [Test]
    public async Task UpdateAsync_ShouldUpdateGoalCorrectly()
    {
        // Arrange
        var userId = "test-user-id";
        var goal = new Goal { Id = 1, Title = "Old Title", ShortDescription = "Old Description", UserId = userId };
        _context.Goals.Add(goal);
        await _context.SaveChangesAsync();
        var updateModel = new GoalEditViewModel { Id = goal.Id, Title = "New Title", ShortDescription = "New Description" };
        // Act
        await _goalService.UpdateAsync(goal.Id,updateModel, userId);
        var updatedGoal = await _context.Goals.FindAsync(goal.Id);
        // Assert
        Assert.That(updatedGoal.Title, Is.EqualTo("New Title"));
        Assert.That(updatedGoal.ShortDescription, Is.EqualTo("New Description"));
    }
    [Test]
    public async Task UpdateAsync_ShouldThrow_WhenUserUnauthorized()
    {
        // Arrange
        var ownerUserId = "owner-user-id";
        var unauthorizedUserId = "unauthorized-user-id";
        var goal = new Goal { Id = 1, Title = "Old Title", ShortDescription = "Old Description", UserId = ownerUserId };
        _context.Goals.Add(goal);
        await _context.SaveChangesAsync();
        var updateModel = new GoalEditViewModel { Id = goal.Id, Title = "New Title", ShortDescription = "New Description" };
        // Act & Assert
        var ex = Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            await _goalService.UpdateAsync(goal.Id, updateModel, unauthorizedUserId));
        Assert.That(ex.Message, Is.EqualTo("You do not have permission to edit this goal."));
    }

    [Test]
    public async Task UpdateAsync_ShouldThrow_WhenGoalDoesNotExist()
    {
        // Arrange
        var userId = "test-user-id";
        var nonExistentGoalId = 999;
        var updateModel = new GoalEditViewModel { Id = nonExistentGoalId, Title = "New Title", ShortDescription = "New Description" };
        // Act & Assert
        var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await _goalService.UpdateAsync(nonExistentGoalId, updateModel, userId));
        Assert.That(ex.Message, Is.EqualTo("Goal not found."));
    }
}
