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
using Pathly.Tests.Common;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
namespace Pathly.Tests;

[TestFixture]
public class RoadmapServiceTests: ServiceTestsBase
{
    private IRoadmapService _roadmapService;
    [SetUp]
    public void SetupRoadmapService()
    {
        BaseSetup();
        _roadmapService = new RoadmapService(_context, _mapper);
    }

    [TearDown]
    public void TearDown() => BaseTearDown();

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
        var goal = new Goal { Title = "Goal", UserId = userId };
        _context.Goals.Add(goal);
        await _context.SaveChangesAsync();

        var existingRoadmap = new Roadmap { UserId = userId, GoalId = goal.Id };
        _context.Roadmaps.Add(existingRoadmap);
        await _context.SaveChangesAsync();

        var actionToUpdate = new ActionItem { Title = "Old Title", RoadmapId = existingRoadmap.Id, UserId = userId };
        var actionToDelete = new ActionItem { Title = "To Delete", RoadmapId = existingRoadmap.Id, UserId = userId };
        _context.Actions.AddRange(actionToUpdate, actionToDelete);
        await _context.SaveChangesAsync();

        var model = new RoadmapCreateViewModel
        {
            
            IsEditing = true,
            RoadmapId = existingRoadmap.Id,
            Actions = new List<ActionItemCreateViewModel>
            {
                // Update Action
                new ActionItemCreateViewModel { Id = actionToUpdate.Id,Title = "New Title" },
                // Add a new one without Id
                new ActionItemCreateViewModel { Title = "Brand New Action" }
                // actionToDelete is missing here so it should get deleted
            }
        };

        // Act
        var resultId = await _roadmapService.SaveRoadmapAsync(model, userId);

        // Assert
        var updatedRoadmap = await _context.Roadmaps.Include(r => r.Actions).FirstAsync(r => r.Id == resultId);

        Assert.AreEqual(2, updatedRoadmap.Actions.Count);
        Assert.IsTrue(updatedRoadmap.Actions.Any(a => a.Title == "New Title" && a.Id == actionToUpdate.Id));
        Assert.IsTrue(updatedRoadmap.Actions.Any(a => a.Title == "Brand New Action"));
        Assert.IsFalse(_context.Actions.Any(a => a.Id == actionToDelete.Id));
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
        var updatedGoal = await _context.Goals.FirstAsync(r => r.Id == existingGoal.Id);

        Assert.AreEqual(existingGoal.Id, roadmap.GoalId);
        Assert.AreEqual("Updated Title", updatedGoal.Title);
    }

    [Test]
    public void SaveRoadmapAsync_ShouldThrow_WhenEditingOtherUserRoadmap()
    {
        //Arrange
        var roadmap = new Roadmap { Id = 99, UserId = "owner" };
        _context.Roadmaps.Add(roadmap);
        _context.SaveChanges();

        var model = new RoadmapCreateViewModel { IsEditing = true, RoadmapId = roadmap.Id };

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
            new ActionItemCreateViewModel { Title = "  " }, // Empty
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
        Assert.AreEqual(null,await _context.Roadmaps.FirstOrDefaultAsync(r => r.Id == modelForDeleting.RoadmapId));
        Assert.IsFalse(_context.Actions.Any(a => a.Title == "Action 1"));
        Assert.IsFalse(_context.Actions.Any(a => a.Title == "Action 2"));

    }

    [Test]
    public void DeleteRoadmapAsync_ShouldThrow_WhenDeletingAnotherUserRoadmap()
    {
        //Arrange
        var roadmap = new Roadmap { UserId = "owner" };
        _context.Roadmaps.Add(roadmap);
        _context.SaveChanges();

        var model = new RoadmapCreateViewModel { IsEditing = true, RoadmapId = roadmap.Id };

        //Assert
        Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            await _roadmapService.DeleteRoadmapAsync(roadmap.Id, "hacker-user"));
    }

    [Test]
    public async Task DeleteRoadmapAsync_ShouldReturnFalse_WhenRoadmapDoesNotExist()
    {
        //Arrange
        var userId = "user1";
        var modelForDeleting = new RoadmapCreateViewModel {NewGoalTitle = "Test" };
        
        //Act
        var resultId = await _roadmapService.SaveRoadmapAsync(modelForDeleting, userId);
        var result = await _roadmapService.DeleteRoadmapAsync(999, userId);

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
    }

    [Test]
    public async Task GetAvailableGoalsAsync_ShouldReturnOnlyGoalsWithoutRoadmaps()
    {
        // Arrange
        var userId = "user1";

        var goalWithRoadmap = new Goal {Title = "With Roadmap", UserId = userId };
        var availableGoal = new Goal { Title = "Available", UserId = userId };
        var otherUserGoal = new Goal { Title = "Other User", UserId = "other" };
        _context.Goals.AddRange(goalWithRoadmap, availableGoal, otherUserGoal);
        await _context.SaveChangesAsync();

        var roadmap = new Roadmap { GoalId = goalWithRoadmap.Id, UserId = userId };
        _context.Roadmaps.Add(roadmap);
        await _context.SaveChangesAsync();

        // Act
        var result = await _roadmapService.GetAvailableGoalsAsync(userId);

        // Assert
        Assert.That(result.Count(), Is.EqualTo(1));
        Assert.That(result.First().Id, Is.EqualTo(availableGoal.Id));
        Assert.That(result.First().Title, Is.EqualTo("Available"));
    }

    [Test]
    public async Task GetGoalByIdAsync_ShouldReturnGoal_WhenExistsAndIsOwnedByUser()
    {
        // Arrange
        var userId = "user1";
        var goal = new Goal { Title = "My Goal", UserId = userId };
        _context.Goals.Add(goal);
        await _context.SaveChangesAsync();

        // Act
        var result = await _roadmapService.GetGoalByIdAsync(goal.Id, userId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("My Goal", result.Title);
    }

    [Test]
    public void GetGoalByIdAsync_ShouldThrowUnauthorized_WhenGoalIsMissingOrNotOwned()
    {
        // Arrange
        var goal = new Goal { Title = "Someone Else's", UserId = "other-user" };
        _context.Goals.Add(goal);
        _context.SaveChanges();

        // Act & Assert
        Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            await _roadmapService.GetGoalByIdAsync(goal.Id, "hacker-id"));
    }

    [Test]
    public async Task GetRoadmapDetailAsync_ShouldReturnMappedViewModel_WhenExists()
    {
        // Arrange
        var userId = "user1";
        var goal = new Goal {Title = "Goal Title", UserId = userId };
        _context.Goals.Add(goal);
        await _context.SaveChangesAsync();

        var roadmap = new Roadmap {GoalId = goal.Id, UserId = userId };
        _context.Roadmaps.Add(roadmap);
        await _context.SaveChangesAsync();

        // Act
        var result = await _roadmapService.GetRoadmapDetailAsync(roadmap.Id, userId);

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
        var goal = new Goal { Title = "Goal Title", UserId = userId };
        _context.Goals.Add(goal);
        await _context.SaveChangesAsync();

        var roadmap = new Roadmap {GoalId = goal.Id, UserId = userId };
        _context.Roadmaps.Add(roadmap);
        await _context.SaveChangesAsync();

        // Act
        var result = await _roadmapService.GetRoadmapForEditAsync(roadmap.Id, userId);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<RoadmapCreateViewModel>(result);
        Assert.AreEqual(roadmap.Id, result.RoadmapId);
        Assert.IsFalse(result.IsEditing);
    }

    [Test]
    public async Task LinkTaskToActionAsync_ShouldReturnTrue_WhenTaskAndActionExistAndAreOwnedByUser()
    {
        // Arrange
        var userId = "user1";
        var task = new TaskItem { Title = "Task", UserId = userId, ActionId = null };
        var action = new ActionItem { Title = "Action", UserId = userId};

        _context.Tasks.Add(task);
        _context.Actions.Add(action);
        await _context.SaveChangesAsync();

        // Act
        var result = await _roadmapService.LinkTaskToActionAsync(task.Id, action.Id, userId);

        // Assert
        Assert.IsTrue(result);
        var updatedTask = await _context.Tasks.FindAsync(task.Id);
        Assert.AreEqual(action.Id, updatedTask.ActionId);
    }

    [Test]
    public async Task LinkTaskToActionAsync_ShouldReturnFalse_WhenActionOrTaskBelongsToOtherUser()
    {
        // Arrange
        var userId = "user1";
        var myTask = new TaskItem {Title = "My Task", UserId = userId };
        var otherAction = new ActionItem {Title = "Other Action", UserId = "hacker"};

        _context.Tasks.Add(myTask);
        _context.Actions.Add(otherAction);
        await _context.SaveChangesAsync();

        // Act
        var result = await _roadmapService.LinkTaskToActionAsync(myTask.Id, otherAction.Id, userId);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public async Task GetUnlinkedTasksAsync_ShouldReturnOnlyTasksWithoutActionId()
    {
        // Arrange
        var userId = "user1";
        var action = new ActionItem { UserId = userId };
        var unlinkedTask = new TaskItem {Title = "Unlinked", UserId = userId, CreatedOn = DateTime.Now };

        var linkedTask = new TaskItem {Title = "Linked", UserId = userId, ActionId = action.Id, CreatedOn = DateTime.Now.AddDays(-1) };

        var otherUserTask = new TaskItem {Title = "Other", UserId = "other", CreatedOn = DateTime.Now };

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
        var action = new ActionItem {Title = "Action", UserId = userId };
        _context.Actions.Add(action);
        await _context.SaveChangesAsync();

        var task = new TaskItem {Title = "Linked Task", UserId = userId, ActionId = action.Id};
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        // Act
        var result = await _roadmapService.UnlinkTaskFromActionAsync(task.Id, userId);

        // Assert
        Assert.IsTrue(result);
        var updatedTask = await _context.Tasks.FindAsync(task.Id);
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
        var action = new ActionItem { UserId = ownerId };
        var task = new TaskItem {Title = "Owner's Task", UserId = ownerId, ActionId = action.Id };
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        //Act+Assert
        Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            await _roadmapService.UnlinkTaskFromActionAsync(task.Id, otherId));
    }

    [Test]
    public async Task ToggleTaskCompletionAsync_ShouldFlipStatus_WhenTaskExists()
    {
        // Arrange
        var userId = "user1";
        var task = new TaskItem {Title = "Task", UserId = userId, IsCompleted = false };
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        // Act 1: From false to true
        var result1 = await _roadmapService.ToggleTaskCompletionAsync(task.Id, userId);
        // Act 2: From true to false
        var result2 = await _roadmapService.ToggleTaskCompletionAsync(task.Id, userId);

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
        var task = new TaskItem {Title = "Private Task", UserId = ownerId };
        _context.Tasks.Add(task);
        _context.SaveChanges();

        // Act & Assert
        Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            await _roadmapService.ToggleTaskCompletionAsync(task.Id, hackerId));
    }
}
