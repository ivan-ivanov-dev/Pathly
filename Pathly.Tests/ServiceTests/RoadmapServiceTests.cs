using AutoMapper;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Pathly.Data;
using Pathly.DataModels;
using Pathly.Services.Contracts;
using Pathly.Services.Implementation;
using Pathly.Services.Mappings;
using Pathly.ViewModels.Roadmaps;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
namespace Pathly.Tests;

public class RoadmapServiceTests
{
    private ApplicationDbContext _context;
    private IMapper _mapper;
    private IRoadmapService _roadmapService;
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

        _roadmapService = new RoadmapService(_context, _mapper);
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
    public async Task SaveRoadmapAsync_ShouldCreateNewRoadmap_WhenModelIsValid()
    {
        // Arrange
        var userId = "test-user-id";
        var model = new RoadmapCreateViewModel
        {

            NewGoalTitle = "Test Roadmap",
            NewGoalDescription = "Test Description",
            Actions = new List<ActionItemCreateViewModel>
            {
                new ActionItemCreateViewModel { Title = "Action 1", DueDate = DateTime.Now.AddDays(7) },
                new ActionItemCreateViewModel { Title = "Action 2", DueDate = DateTime.Now.AddDays(14) }
            }
        };

        // Act
        var roadmapId = await _roadmapService.SaveRoadmapAsync(model, userId);

        // Assert
        var roadmapInDb = await _context.Roadmaps
            .Include(r => r.Actions)
            .Include(r => r.Goal)
            .FirstOrDefaultAsync(r => r.Id == roadmapId);

        Assert.IsNotNull(roadmapInDb);
        Assert.AreEqual(model.NewGoalTitle, roadmapInDb.Goal.Title);
        Assert.AreEqual(2, roadmapInDb.Actions.Count);
    }

    [Test]
    public async Task SaveRoadmapAsync_ShouldUpdateRoadmap_WhenIsEditingIsTrue()
    {
        // Arrange
        var userId = "user1";
        var existingRoadmap = new Roadmap { Id = 1, UserId = userId, GoalId = 10 };
        var actionToUpdate = new ActionItem { Id = 100, Title = "Old Title", RoadmapId = 1, UserId = userId };
        var actionToDelete = new ActionItem { Id = 101, Title = "To Delete", RoadmapId = 1, UserId = userId };

        _context.Roadmaps.Add(existingRoadmap);
        _context.Actions.AddRange(actionToUpdate, actionToDelete);
        await _context.SaveChangesAsync();

        var model = new RoadmapCreateViewModel
        {
            IsEditing = true,
            RoadmapId = 1,
            Actions = new List<ActionItemCreateViewModel>
            {
                // Update Action
                new ActionItemCreateViewModel { Id = 100, Title = "New Title" },
                // Add a new one without Id
                new ActionItemCreateViewModel { Title = "Brand New Action" }
                // Action with Id 101 is missing here so it should gwt deleted
            }
        };

        // Act
        var resultId = await _roadmapService.SaveRoadmapAsync(model, userId);

        // Assert
        var updatedRoadmap = await _context.Roadmaps.Include(r => r.Actions).FirstAsync(r => r.Id == resultId);

        Assert.AreEqual(2, updatedRoadmap.Actions.Count);
        Assert.IsTrue(updatedRoadmap.Actions.Any(a => a.Title == "New Title" && a.Id == 100));
        Assert.IsTrue(updatedRoadmap.Actions.Any(a => a.Title == "Brand New Action"));
        Assert.IsFalse(_context.Actions.Any(a => a.Id == 101), "Action should have been deleted");
    }

    [Test]
    public async Task SaveRoadmapAsync_ShouldCreateNewGoalAndRoadmap_WhenNoGoalSelected()
    {
        // Arrange
        var userId = "user1";
        var model = new RoadmapCreateViewModel
        {
            IsEditing = false,
            NewGoalTitle = "New Goal",
            NewGoalDescription = "New Description",
            Actions = new List<ActionItemCreateViewModel>
            {
                new ActionItemCreateViewModel { Title = "Task 1" }
            }
        };

        // Act
        var resultId = await _roadmapService.SaveRoadmapAsync(model, userId);

        // Assert
        var roadmap = await _context.Roadmaps.Include(r => r.Goal).Include(r => r.Actions).FirstAsync(r => r.Id == resultId);

        Assert.AreEqual("New Goal", roadmap.Goal.Title);
        Assert.AreEqual(userId, roadmap.Goal.UserId);
        Assert.AreEqual(1, roadmap.Actions.Count);
    }
    [Test]
    public async Task SaveRoadmapAsync_ShouldUseExistingGoal_WhenSelectedGoalIdIsProvided()
    {
        //Arrange
        var userId = "user1";
        var existingGoal = new Goal
        {
            Id = 13,
            Title = "Existing",
            UserId = userId
        };
        _context.Add(existingGoal);
        await _context.SaveChangesAsync();

        var model = new RoadmapCreateViewModel
        {
            IsEditing = false,
            SelectedGoalId = existingGoal.Id,
            NewGoalTitle = "Updated Title",
            Actions = new List<ActionItemCreateViewModel>()
        };


        //Act
        var resultId = await _roadmapService.SaveRoadmapAsync(model, userId);

        //Assert
        var roadmap = await _context.Roadmaps.FirstAsync(r => r.Id == resultId);
        var updatedGoal = await _context.Goals.FirstAsync(r => r.Id == 13);

        Assert.AreEqual(13, roadmap.GoalId);
        Assert.AreEqual("Updated Title", updatedGoal.Title);
    }

    [Test]
    public void SaveRoadmapAsync_ShouldThrow_WhenEditingOtherUserRoadmap()
    {
        //Arrange

        _context.Roadmaps.Add(new Roadmap { Id = 99, UserId = "owner" });
        _context.SaveChanges();

        var model = new RoadmapCreateViewModel { IsEditing = true, RoadmapId = 99 };

        //Assert
        Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            await _roadmapService.SaveRoadmapAsync(model, "hacker-user"));

    }

    [Test]
    public async Task SaveRoadmapAsync_ShouldSkipEmptyActions()
    {
        // Arrange
        var userId = "user1";
        var model = new RoadmapCreateViewModel
        {
            NewGoalTitle = "Goal",
            Actions = new List<ActionItemCreateViewModel>
        {
            new ActionItemCreateViewModel { Title = "  " }, // Празно
            new ActionItemCreateViewModel { Title = null }, // Null
            new ActionItemCreateViewModel { Title = "Valid Action" }
        }
        };

        // Act
        var resultId = await _roadmapService.SaveRoadmapAsync(model, userId);

        // Assert
        var roadmap = await _context.Roadmaps.Include(r => r.Actions).FirstAsync(r => r.Id == resultId);
        Assert.AreEqual(1, roadmap.Actions.Count);
        Assert.AreEqual("Valid Action", roadmap.Actions.First().Title);
    }

    [Test]
    public async Task DeleteRoadmapAsync_ShouldReturnTrue_WhenDeletingRoadmapAndItsActionsIsDoneCorrectly()
    {
        //Arrange
        var userId = "user1";
        var modelForDeleting = new RoadmapCreateViewModel
        {
            RoadmapId = 1,
            NewGoalTitle = "Test Deleting",
            NewGoalDescription = "Test",
            Actions = new List<ActionItemCreateViewModel>
            {
                new ActionItemCreateViewModel { Title = "Action 1", DueDate = DateTime.Now.AddDays(7) },
                new ActionItemCreateViewModel { Title = "Action 2", DueDate = DateTime.Now.AddDays(14) }
            }
        };
        //Act
        var resultId = await _roadmapService.SaveRoadmapAsync(modelForDeleting, userId);
        var result = await _roadmapService.DeleteRoadmapAsync(resultId, userId);

        //Assert
        Assert.That(result, Is.True);
        Assert.AreEqual(null,await _context.Roadmaps.FirstOrDefaultAsync(r => r.Id == 1));
        Assert.IsFalse(_context.Actions.Any(a => a.Title == "Action 1"));
        Assert.IsFalse(_context.Actions.Any(a => a.Title == "Action 2"));

    }

    [Test]
    public void DeleteRoadmapAsync_ShouldThrow_WhenDeletingAnotherUserRoadmap()
    {
        //Arrange
        _context.Roadmaps.Add(new Roadmap { Id = 99, UserId = "owner" });
        _context.SaveChanges();

        var model = new RoadmapCreateViewModel { IsEditing = true, RoadmapId = 99 };

        //Assert
        Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            await _roadmapService.DeleteRoadmapAsync(99, "hacker-user"));
    }

    [Test]
    public async Task DeleteRoadmapAsync_ShouldReturnFalse_WhenRoadmapDoesNotExist()
    {
        //Arrange
        var userId = "user1";
        var modelForDeleting = new RoadmapCreateViewModel { RoadmapId = 1, NewGoalTitle = "Test" };
        
        //Act
        var resultId = await _roadmapService.SaveRoadmapAsync(modelForDeleting, userId);
        var result = await _roadmapService.DeleteRoadmapAsync(2, userId);

        //Assert
        Assert.IsFalse(result);
    }

    [Test]
    public async Task GetAllRoadmapsAsync_ShouldReturnCorrectListOfAllRoadmapsForTheUser()
    {
        //Arrange
        var userId = "user1";
        var model1 = new RoadmapCreateViewModel
        {
            RoadmapId = 1,
            NewGoalTitle = "Test1",
            NewGoalDescription = "Test1",
            Actions = new List<ActionItemCreateViewModel>
            {
                new ActionItemCreateViewModel { Title = "Action 1", DueDate = DateTime.Now.AddDays(7) },
                new ActionItemCreateViewModel { Title = "Action 2", DueDate = DateTime.Now.AddDays(14) }
            }
        };
        var model2 = new RoadmapCreateViewModel
        {
            RoadmapId = 2,
            NewGoalTitle = "Test2",
            NewGoalDescription = "Test2",
            Actions = new List<ActionItemCreateViewModel>
            {
                new ActionItemCreateViewModel { Title = "Action 3", DueDate = DateTime.Now.AddDays(7) },
                new ActionItemCreateViewModel { Title = "Action 4", DueDate = DateTime.Now.AddDays(14) }
            }
        };
        //Act
        var resultId1 = await _roadmapService.SaveRoadmapAsync(model1, userId);
        var resultId2 = await _roadmapService.SaveRoadmapAsync(model2, userId);
        var roadmaps = await _roadmapService.GetAllRoadmapsAsync(userId);

        //Assert
        Assert.IsNotNull(roadmaps);
        Assert.AreEqual(2, roadmaps.Count);
        Assert.AreEqual(2, _context.Roadmaps.Count());
    }

    [Test]
    public async Task GetAvailableGoalsAsync_ShouldReturnOnlyGoalsWithoutRoadmaps()
    {
        // Arrange
        var userId = "user1";

        var goalWithRoadmap = new Goal { Id = 1, Title = "With Roadmap", UserId = userId };
        var roadmap = new Roadmap { Id = 1, GoalId = 1, UserId = userId };

        var availableGoal = new Goal { Id = 2, Title = "Available", UserId = userId };

        var otherUserGoal = new Goal { Id = 3, Title = "Other User", UserId = "other" };

        _context.Goals.AddRange(goalWithRoadmap, availableGoal, otherUserGoal);
        _context.Roadmaps.Add(roadmap);
        await _context.SaveChangesAsync();

        // Act
        var result = await _roadmapService.GetAvailableGoalsAsync(userId);

        // Assert
        Assert.That(result.Count(), Is.EqualTo(1));
        Assert.That(result.First().Id, Is.EqualTo(2));
        Assert.That(result.First().Title, Is.EqualTo("Available"));
    }

    [Test]
    public async Task GetGoalByIdAsync_ShouldReturnGoal_WhenExistsAndIsOwnedByUser()
    {
        // Arrange
        var userId = "user1";
        var goal = new Goal { Id = 10, Title = "My Goal", UserId = userId };
        _context.Goals.Add(goal);
        await _context.SaveChangesAsync();

        // Act
        var result = await _roadmapService.GetGoalByIdAsync(10, userId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("My Goal", result.Title);
    }

    [Test]
    public void GetGoalByIdAsync_ShouldThrowUnauthorized_WhenGoalIsMissingOrNotOwned()
    {
        // Arrange
        _context.Goals.Add(new Goal { Id = 20, Title = "Someone Else's", UserId = "other-user" });
        _context.SaveChanges();

        // Act & Assert
        Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            await _roadmapService.GetGoalByIdAsync(20, "hacker-id"));
    }

    [Test]
    public async Task GetRoadmapDetailAsync_ShouldReturnMappedViewModel_WhenExists()
    {
        // Arrange
        var userId = "user1";
        var goal = new Goal { Id = 5, Title = "Goal Title", UserId = userId };
        var roadmap = new Roadmap { Id = 1, GoalId = 5, UserId = userId };
        _context.Goals.Add(goal);
        _context.Roadmaps.Add(roadmap);
        await _context.SaveChangesAsync();

        // Act
        var result = await _roadmapService.GetRoadmapDetailAsync(1, userId);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<RoadmapDetailsViewModel>(result);
        Assert.AreEqual("Goal Title", result.GoalTitle);//check if the mapping works
    }

    [Test]
    public void GetRoadmapDetailAsync_ShouldThrowUnauthorized_WhenRoadmapNotFound()
    {
        // Arrange
        // the database is empty or has data for other users

        // Act & Assert
        Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            await _roadmapService.GetRoadmapDetailAsync(999, "any-user"));
    }

    [Test]
    public async Task GetRoadmapForEditAsync_ShouldReturnMappedViewModel_WhenRoadmapExists()
    {
        // Arrange
        var userId = "user1";
        var goal = new Goal { Id = 1, Title = "Goal Title", UserId = userId };
        var roadmap = new Roadmap { Id = 1, GoalId = 1, UserId = userId };

        _context.Goals.Add(goal);
        _context.Roadmaps.Add(roadmap);
        await _context.SaveChangesAsync();

        // Act
        var result = await _roadmapService.GetRoadmapForEditAsync(1, userId);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<RoadmapCreateViewModel>(result);
        Assert.AreEqual(1, result.RoadmapId);
        Assert.IsFalse(result.IsEditing);
    }

    [Test]
    public async Task LinkTaskToActionAsync_ShouldReturnTrue_WhenTaskAndActionExistAndAreOwnedByUser()
    {
        // Arrange
        var userId = "user1";
        var task = new TaskItem { Id = 10, Title = "Task", UserId = userId, ActionId = null };
        var action = new ActionItem { Id = 100, Title = "Action", UserId = userId, RoadmapId = 1 };

        _context.Tasks.Add(task);
        _context.Actions.Add(action);
        await _context.SaveChangesAsync();

        // Act
        var result = await _roadmapService.LinkTaskToActionAsync(10, 100, userId);

        // Assert
        Assert.IsTrue(result);
        var updatedTask = await _context.Tasks.FindAsync(10);
        Assert.AreEqual(100, updatedTask.ActionId);
    }

    [Test]
    public async Task LinkTaskToActionAsync_ShouldReturnFalse_WhenActionOrTaskBelongsToOtherUser()
    {
        // Arrange
        var userId = "user1";
        var myTask = new TaskItem { Id = 1, Title = "My Task", UserId = userId };
        var otherAction = new ActionItem { Id = 2, Title = "Other Action", UserId = "hacker", RoadmapId = 5 };

        _context.Tasks.Add(myTask);
        _context.Actions.Add(otherAction);
        await _context.SaveChangesAsync();

        // Act
        var result = await _roadmapService.LinkTaskToActionAsync(1, 2, userId);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public async Task GetUnlinkedTasksAsync_ShouldReturnOnlyTasksWithoutActionId()
    {
        // Arrange
        var userId = "user1";
        
        var unlinkedTask = new TaskItem { Id = 1, Title = "Unlinked", UserId = userId, ActionId = null, CreatedOn = DateTime.Now };

        var linkedTask = new TaskItem { Id = 2, Title = "Linked", UserId = userId, ActionId = 10, CreatedOn = DateTime.Now.AddDays(-1) };

        var otherUserTask = new TaskItem { Id = 3, Title = "Other", UserId = "other", ActionId = null, CreatedOn = DateTime.Now };

        _context.Tasks.AddRange(unlinkedTask, linkedTask, otherUserTask);
        await _context.SaveChangesAsync();

        // Act
        var result = await _roadmapService.GetUnlinkedTasksAsync(userId);

        // Assert
        Assert.AreEqual(1, result.Count());
        Assert.AreEqual("Unlinked", result.First().Title);
    }

    [Test]
    public async Task UnlinkTaskFromActionAsync_ShouldReturnTrue_WhenTaskIsLinkedAndOwnedByUser()
    {
        // Arrange
        var userId = "user1";
        var task = new TaskItem { Id = 1, Title = "Linked Task", UserId = userId, ActionId = 10 };
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        // Act
        var result = await _roadmapService.UnlinkTaskFromActionAsync(1, userId);

        // Assert
        Assert.IsTrue(result);
        var updatedTask = await _context.Tasks.FindAsync(1);
        Assert.IsNull(updatedTask.ActionId);
    }

    [Test]
    public async Task UnlinkTaskFromActionAsync_ShouldReturnFalse_WhenTaskDoesNotExist()
    {
        // Act
        var result = await _roadmapService.UnlinkTaskFromActionAsync(999, "any-user");

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public async Task UnlinkTaskFromActionAsync_ShouldReturnFalse_WhenTaskBelongsToOtherUser()
    {
        // Arrange
        var ownerId = "owner";
        var otherId = "other-user";
        var task = new TaskItem { Id = 5, Title = "Owner's Task", UserId = ownerId, ActionId = 10 };
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        //Act+Assert
        Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            await _roadmapService.UnlinkTaskFromActionAsync(5, otherId));
    }

    [Test]
    public async Task ToggleTaskCompletionAsync_ShouldFlipStatus_WhenTaskExists()
    {
        // Arrange
        var userId = "user1";
        var task = new TaskItem { Id = 1, Title = "Task", UserId = userId, IsCompleted = false };
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        // Act 1: From false to true
        var result1 = await _roadmapService.ToggleTaskCompletionAsync(1, userId);
        // Act 2: From true to false
        var result2 = await _roadmapService.ToggleTaskCompletionAsync(1, userId);

        // Assert
        Assert.IsTrue(result1);
        Assert.IsFalse(result2);
    }

    [Test]
    public async Task ToggleTaskCompletionAsync_ShouldReturnNull_WhenTaskNotFound()
    {
        // Act
        var result = await _roadmapService.ToggleTaskCompletionAsync(999, "any-user");

        // Assert
        Assert.IsNull(result);
    }

    [Test]
    public void ToggleTaskCompletionAsync_ShouldThrowUnauthorized_WhenUserIsNotOwner()
    {
        // Arrange
        var ownerId = "owner";
        var hackerId = "hacker";
        var task = new TaskItem { Id = 10, Title = "Private Task", UserId = ownerId };
        _context.Tasks.Add(task);
        _context.SaveChanges();

        // Act & Assert
        Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            await _roadmapService.ToggleTaskCompletionAsync(10, hackerId));
    }
}
