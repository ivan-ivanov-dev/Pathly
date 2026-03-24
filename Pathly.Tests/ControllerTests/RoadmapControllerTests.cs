using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Pathly.DataModels;
using Pathly.Services.Contracts;
using Pathly.Tests.Common;
using Pathly.ViewModels.Goals;
using Pathly.ViewModels.Roadmaps;
using Pathly.Web.Controllers;

namespace Pathly.Tests;

[TestFixture]
public class RoadmapControllerTests: ControllerTestsBase
{
    private Mock<IRoadmapService> _mockRoadmapService;
    private Mock<IMapper> _mockMapper;
    private RoadmapController _controller;

    [SetUp]
    public void Setup()
    {
        _mockRoadmapService = new Mock<IRoadmapService>();
        _mockMapper = new Mock<IMapper>();

        _controller = new RoadmapController(_mockRoadmapService.Object, _mockUserManager.Object, _mockMapper.Object);

        SetupUser(_controller);
        
    }

    [TearDown]
    public void TearDown()
    {
        if (_controller != null)
        {
            _controller.Dispose();
        }
    }

    [Test]
    public async Task Selection_ShouldReturnViewWithAvailableGoals()
    {
        // Arrange
        int goalId = 1;
        var goals = new List<Goal> { new Goal { Id = goalId, Title = "Goal 1", UserId = _userId } };

        _mockRoadmapService
            .Setup(s => s.GetAvailableGoalsAsync(_userId))
            .ReturnsAsync(goals);

        // Act
        var result = await _controller.Selection();

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = (ViewResult)result;

        Assert.That(viewResult.Model, Is.EqualTo(goals));
    }

    [Test]
    public async Task Create_ShouldReturnViewWithEmptyModel_WhenNoGoalIdProvided()
    {
        // Act
        var result = await _controller.Create(null);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = (ViewResult)result;
        Assert.That(viewResult.ViewName, Is.EqualTo("RoadmapForm"));

        var model = (RoadmapCreateViewModel)viewResult.Model!;
        Assert.That(model.IsEditing, Is.False);
        Assert.That(model.Actions.Count, Is.EqualTo(3)); // The first 3 actions should be empty
    }

    [Test]
    public async Task Create_ShouldMapGoalData_WhenValidGoalIdProvided()
    {
        // Arrange
        int goalId = 1;
        var goal = new Goal { Id = goalId, Title = "Mapped Goal", UserId = _userId };

        _mockRoadmapService
            .Setup(s => s.GetGoalByIdAsync(goalId, _userId))
            .ReturnsAsync(goal);

        // Act
        var result = await _controller.Create(goalId);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = (ViewResult)result;
        var model = (RoadmapCreateViewModel)viewResult.Model!;

        Assert.That(model.SelectedGoalId, Is.EqualTo(goalId));

        _mockMapper.Verify(m => m.Map(goal, It.IsAny<RoadmapCreateViewModel>()), Times.Once);
    }

    [Test]
    public async Task Edit_ShouldReturnView_WhenRoadmapExists()
    {
        // Arrange
        int roadmapId = 1;
        var expectedModel = new RoadmapCreateViewModel { IsEditing = true };
        _mockRoadmapService.Setup(s => s.GetRoadmapForEditAsync(roadmapId, _userId)).ReturnsAsync(expectedModel);

        // Act
        var result = await _controller.Edit(roadmapId);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = (ViewResult)result;
        Assert.That(viewResult.ViewName, Is.EqualTo("RoadmapForm"));
        Assert.That(viewResult.Model, Is.EqualTo(expectedModel));
    }

    [Test]
    public async Task Edit_ShouldReturnNotFound_WhenRoadmapDoesNotExist()
    {
        // Arrange
        _mockRoadmapService.Setup(s => s.GetRoadmapForEditAsync(999, _userId)).ReturnsAsync((RoadmapCreateViewModel?)null);

        // Act
        var result = await _controller.Edit(999);

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result);
    }

    [Test]
    public async Task Save_ShouldRedirectToSelection_WhenModelIsValid()
    {
        // Arrange
        var model = new RoadmapCreateViewModel
        {
            SelectedGoalId = 1,
            Actions = new List<ActionItemCreateViewModel>
        {
            new ActionItemCreateViewModel { Title = "Milestone 1" }
        }
        };
        var goal = new Goal { Id = 1, UserId = _userId };

        _mockRoadmapService.Setup(s => s.GetGoalByIdAsync(1, _userId)).ReturnsAsync(goal);
        _mockRoadmapService.Setup(s => s.SaveRoadmapAsync(model, _userId)).ReturnsAsync(100);

        // Act
        var result = await _controller.Save(model);

        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var redirect = (RedirectToActionResult)result;
        Assert.That(redirect.ActionName, Is.EqualTo("Selection"));
    }

    [Test]
    public async Task Save_ShouldReturnView_WhenNoActionsHaveTitles()
    {
        // Arrange
        var model = new RoadmapCreateViewModel
        {
            NewGoalTitle = "New Goal",
            Actions = new List<ActionItemCreateViewModel>
        {
            new ActionItemCreateViewModel { Title = "" },
            new ActionItemCreateViewModel { Title = "   " }
        }
        };

        // Act
        var result = await _controller.Save(model);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = (ViewResult)result;
        Assert.That(viewResult.ViewName, Is.EqualTo("RoadmapForm"));
        Assert.IsFalse(_controller.ModelState.IsValid);

        var error = _controller.ModelState[""]?.Errors.First().ErrorMessage;
        Assert.That(error, Is.EqualTo("At least one Milestone title is required to build a path."));
    }

    [Test]
    public async Task Save_ShouldReturnView_WhenGoalDoesNotExist()
    {
        // Arrange
        var model = new RoadmapCreateViewModel { SelectedGoalId = 99 };
        _mockRoadmapService.Setup(s => s.GetGoalByIdAsync(99, _userId)).ReturnsAsync((Goal?)null);

        // Act
        var result = await _controller.Save(model);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        Assert.IsTrue(_controller.ModelState.Values.SelectMany(v => v.Errors)
            .Any(e => e.ErrorMessage == "The selected goal does not exist."));
    }

    [Test]
    public async Task Save_ShouldReturnView_WhenGoalBelongsToAnotherUser()
    {
        // Arrange
        var model = new RoadmapCreateViewModel { SelectedGoalId = 1 };
        var foreignGoal = new Goal { Id = 1, UserId = "different-user" };

        _mockRoadmapService.Setup(s => s.GetGoalByIdAsync(1, _userId)).ReturnsAsync(foreignGoal);

        // Act
        var result = await _controller.Save(model);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        Assert.IsTrue(_controller.ModelState.Values.SelectMany(v => v.Errors)
            .Any(e => e.ErrorMessage == "You do not have permission to use the selected goal."));
    }

    [Test]
    public async Task Save_ShouldReturnView_WhenNoGoalIsSelectedAndNoNewTitleProvided()
    {
        // Arrange
        var model = new RoadmapCreateViewModel
        {
            SelectedGoalId = null,
            NewGoalTitle = null,
            Actions = new List<ActionItemCreateViewModel> { new ActionItemCreateViewModel { Title = "Step" } }
        };

        // Act
        var result = await _controller.Save(model);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        Assert.IsTrue(_controller.ModelState.Values.SelectMany(v => v.Errors)
            .Any(e => e.ErrorMessage == "Please select an existing goal or enter a new goal title."));
    }

    [Test]
    public async Task Save_ShouldReturnView_WhenServiceThrowsException()
    {
        // Arrange
        var model = new RoadmapCreateViewModel
        {
            NewGoalTitle = "Test",
            Actions = new List<ActionItemCreateViewModel> { new ActionItemCreateViewModel { Title = "Step" } }
        };

        _mockRoadmapService.Setup(s => s.SaveRoadmapAsync(model, _userId))
            .ThrowsAsync(new Exception("Database error"));

        // Act
        var result = await _controller.Save(model);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        Assert.IsTrue(_controller.ModelState.Values.SelectMany(v => v.Errors)
            .Any(e => e.ErrorMessage == "An error occurred while saving the roadmap."));
    }

    [Test]
    public async Task Details_ShouldReturnView_WhenRoadmapExists()
    {
        // Arrange
        int roadmapId = 1;
        var expectedDetails = new RoadmapDetailsViewModel { RoadmapId = roadmapId, GoalTitle = "Test Goal" };

        _mockRoadmapService
            .Setup(s => s.GetRoadmapDetailAsync(roadmapId, _userId))
            .ReturnsAsync(expectedDetails);

        // Act
        var result = await _controller.Details(roadmapId);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = (ViewResult)result;
        Assert.That(viewResult.Model, Is.EqualTo(expectedDetails));
    }

    [Test]
    public async Task Details_ShouldReturnNotFound_WhenRoadmapDoesNotExist()
    {
        // Arrange
        _mockRoadmapService.Setup(s => s.GetRoadmapDetailAsync(It.IsAny<int>(), _userId))
            .ReturnsAsync((RoadmapDetailsViewModel?)null);

        // Act
        var result = await _controller.Details(99);

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result);
    }

    [Test]
    public async Task SaveAssignments_ShouldLinkMultipleTasksAndRedirect()
    {
        // Arrange
        int actionId = 10;
        int roadmapId = 5;
        string selectedTaskIds = "1,2,3"; // Simulate chosen Ids

        // Act
        var result = await _controller.SaveAssignments(actionId, roadmapId, selectedTaskIds);

        // Assert
        // Check Redirect
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var redirect = (RedirectToActionResult)result;
        Assert.That(redirect.ActionName, Is.EqualTo("Details"));
        Assert.That(redirect.RouteValues["id"], Is.EqualTo(roadmapId));

        // Verify that the service is called exactly one for each of the goals
        _mockRoadmapService.Verify(s => s.LinkTaskToActionAsync(It.IsAny<int>(), actionId, _userId), Times.Exactly(3));
        _mockRoadmapService.Verify(s => s.LinkTaskToActionAsync(1, actionId, _userId), Times.Once);
        _mockRoadmapService.Verify(s => s.LinkTaskToActionAsync(2, actionId, _userId), Times.Once);
        _mockRoadmapService.Verify(s => s.LinkTaskToActionAsync(3, actionId, _userId), Times.Once);
    }

    [Test]
    public async Task SaveAssignments_ShouldNotLinkAnything_WhenTaskIdsEmpty()
    {
        // Arrange
        int actionId = 10;
        int roadmapId = 5;

        // Act
        await _controller.SaveAssignments(actionId, roadmapId, "");

        // Assert
        _mockRoadmapService.Verify(s => s.LinkTaskToActionAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()), Times.Never);
    }

    [Test]
    public async Task Delete_ShouldRedirectToSelection_OnSuccess()
    {
        // Arrange
        int roadmapId = 1;
        _mockRoadmapService.Setup(s => s.DeleteRoadmapAsync(roadmapId, _userId))
            .ReturnsAsync(true);

        // Act
        var result = await _controller.Delete(roadmapId);

        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var redirect = (RedirectToActionResult)result;
        Assert.That(redirect.ActionName, Is.EqualTo(nameof(_controller.Selection)));
    }

    [Test]
    public async Task Delete_ShouldReturnBadRequest_OnFailure()
    {
        // Arrange
        _mockRoadmapService.Setup(s => s.DeleteRoadmapAsync(It.IsAny<int>(), _userId))
            .ReturnsAsync(false);

        // Act
        var result = await _controller.Delete(1);

        // Assert
        Assert.IsInstanceOf<BadRequestResult>(result);
    }

}
