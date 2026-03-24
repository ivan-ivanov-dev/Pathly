using Microsoft.AspNetCore.Mvc;
using Moq;
using Pathly.Services.Contracts;
using Pathly.ViewModels.Goals;
using Pathly.Web.Controllers;
using Pathly.Tests.Common;
using AutoMapper;
using Pathly.GCommon;

namespace Pathly.Tests;

[TestFixture]
public class GoalsControllerTests: ControllerTestsBase
{
    private Mock<IGoalService> _mockGoalService;
    private Mock<IMapper> _mockMapper;
    private GoalsController _controller;

    [SetUp]
    public void Setup()
    {
        _mockGoalService = new Mock<IGoalService>();
        _mockMapper = new Mock<IMapper>();

        _controller = new GoalsController(_mockGoalService.Object, _mockUserManager.Object, _mockMapper.Object);

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
    public async Task Index_ShouldReturnViewWithCorrectModel()
    {
        // Arrange
        var queryModel = new GoalQueryModel();

        var expectedResult = new GoalQueryModel
        {
            SearchTerm = "Test",
            Goals = new GoalListViewModel
            {
                Goals = new PagedList<GoalViewModel>(
                    new List<GoalViewModel> { new GoalViewModel { Title = "Test Goal" } },
                    1, // CurrentPage
                    1, // PageSize
                    1  // TotalCount
                )
            }
        };

        _mockGoalService
            .Setup(s => s.GetAllAsync(It.IsAny<GoalQueryModel>(), _userId))
            .ReturnsAsync(expectedResult);

        // Act
        var result = await _controller.Index(queryModel);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = (ViewResult)result;
        var model = (GoalQueryModel)viewResult.Model!;

        Assert.IsInstanceOf<GoalQueryModel>(viewResult.Model);
        Assert.That(model.Goals.Goals.Count(), Is.EqualTo(1));
        Assert.That(model.Goals.Goals.First().Title, Is.EqualTo("Test Goal"));

        _mockGoalService.Verify(s => s.GetAllAsync(queryModel, _userId), Times.Once);
    }

    [Test]
    public async Task Index_ShouldPassEmptyQueryModel_WhenNoneProvided()
    {
        // Arrange
        _mockGoalService
            .Setup(s => s.GetAllAsync(null!, _userId))
            .ReturnsAsync(new GoalQueryModel());

        // Act
        var result = await _controller.Index(null!);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        _mockGoalService.Verify(s => s.GetAllAsync(null!, _userId), Times.Once);
    }

    [Test]
    public void Create_Get_ShouldReturnViewWithModel()
    {
        // Act
        var result = _controller.Create();

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = (ViewResult)result;
        Assert.IsInstanceOf<GoalCreateViewModel>(viewResult.Model);
    }

    [Test]
    public async Task CreateAsync_Post_ShouldRedirectToIndex_WhenModelIsValid()
    {
        // Arrange
        var model = new GoalCreateViewModel
        {
            Title = "New Goal",
            TargetDate = DateTime.UtcNow.AddDays(1)
        };

        // Act
        var result = await _controller.CreateAsync(model);

        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var redirectResult = (RedirectToActionResult)result;
        Assert.That(redirectResult.ActionName, Is.EqualTo(nameof(_controller.Index)));

        _mockGoalService.Verify(s => s.CreateAsync(model, _userId), Times.Once);
    }

    [Test]
    public async Task CreateAsync_Post_ShouldReturnView_WhenTitleIsMissing()
    {
        // Arrange
        var model = new GoalCreateViewModel { Title = "" };

        // Act
        var result = await _controller.CreateAsync(model);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = (ViewResult)result;
        Assert.That(viewResult.Model, Is.EqualTo(model));

        Assert.IsFalse(_controller.ModelState.IsValid);
        Assert.IsTrue(_controller.ModelState.ContainsKey("Title"));

        // The service shouldn't get called
        _mockGoalService.Verify(s => s.CreateAsync(It.IsAny<GoalCreateViewModel>(), It.IsAny<string>()), Times.Never);
    }

    [Test]
    public async Task CreateAsync_Post_ShouldReturnView_WhenTargetDateIsInPast()
    {
        // Arrange
        var model = new GoalCreateViewModel
        {
            Title = "Valid Title",
            TargetDate = DateTime.UtcNow.AddDays(-5)
        };

        // Act
        var result = await _controller.CreateAsync(model);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        Assert.IsTrue(_controller.ModelState.ContainsKey("TargetDate"));
        _mockGoalService.Verify(s => s.CreateAsync(It.IsAny<GoalCreateViewModel>(), It.IsAny<string>()), Times.Never);
    }

    [Test]
    public async Task CreateAsync_Post_ShouldReturnView_WhenServiceThrowsException()
    {
        // Arrange
        var model = new GoalCreateViewModel { Title = "Valid Title" };
        _mockGoalService
            .Setup(s => s.CreateAsync(model, _userId))
            .ThrowsAsync(new Exception("Database error"));

        // Act
        var result = await _controller.CreateAsync(model);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = (ViewResult)result;

        Assert.IsFalse(_controller.ModelState.IsValid);
        var modelStateError = _controller.ModelState[""]!.Errors.First().ErrorMessage;
        Assert.That(modelStateError, Does.Contain("Database error"));
    }

    [Test]
    public async Task EditAsync_Get_ShouldReturnViewWithMappedModel_WhenGoalExists()
    {
        // Arrange
        int goalId = 1;
        var goalDetails = new GoalDetailsViewModel { Id = goalId, Title = "Original Title" };
        var expectedEditModel = new GoalEditViewModel { Id = goalId, Title = "Original Title" };

        _mockGoalService
            .Setup(s => s.GetDetailsAsync(goalId, _userId))
            .ReturnsAsync(goalDetails);

        _mockMapper
            .Setup(m => m.Map<GoalEditViewModel>(goalDetails))
            .Returns(expectedEditModel);

        // Act
        var result = await _controller.EditAsync(goalId);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = (ViewResult)result;
        Assert.That(viewResult.Model, Is.EqualTo(expectedEditModel));
    }

    [Test]
    public async Task EditAsync_Get_ShouldReturnNotFound_WhenGoalDoesNotExist()
    {
        // Arrange
        int goalId = 999;
        _mockGoalService
            .Setup(s => s.GetDetailsAsync(goalId, _userId))
            .ReturnsAsync((GoalDetailsViewModel?)null);

        // Act
        var result = await _controller.EditAsync(goalId);

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result);
    }

    [Test]
    public async Task EditAsync_Post_ShouldRedirectToIndex_WhenUpdateIsSuccessful()
    {
        // Arrange
        var model = new GoalEditViewModel
        {
            Id = 1,
            Title = "Updated Title",
            TargetDate = DateTime.UtcNow.AddDays(1)
        };

        // Act
        var result = await _controller.EditAsync(model);

        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var redirectResult = (RedirectToActionResult)result;
        Assert.That(redirectResult.ActionName, Is.EqualTo(nameof(_controller.Index)));

        _mockGoalService.Verify(s => s.UpdateAsync(model.Id, model, _userId), Times.Once);
    }

    [Test]
    public async Task EditAsync_Post_ShouldReturnView_WhenValidationFails()
    {
        // Arrange
        var model = new GoalEditViewModel { Id = 1, Title = "" };

        // Act
        var result = await _controller.EditAsync(model);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = (ViewResult)result;
        Assert.That(viewResult.Model, Is.EqualTo(model));
        Assert.IsFalse(_controller.ModelState.IsValid);

        _mockGoalService.Verify(s => s.UpdateAsync(It.IsAny<int>(), It.IsAny<GoalEditViewModel>(), It.IsAny<string>()), Times.Never);
    }

    [Test]
    public async Task EditAsync_Post_ShouldReturnViewWithErrorMessage_WhenServiceThrowsException()
    {
        // Arrange
        var model = new GoalEditViewModel { Id = 1, Title = "Valid Title" };
        _mockGoalService
            .Setup(s => s.UpdateAsync(model.Id, model, _userId))
            .ThrowsAsync(new Exception("Concurrency error"));

        // Act
        var result = await _controller.EditAsync(model);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        Assert.IsFalse(_controller.ModelState.IsValid);
        var error = _controller.ModelState[""]?.Errors.First().ErrorMessage;
        Assert.That(error, Does.Contain("Concurrency error"));
    }

    [Test]
    public async Task DetailsAsync_ShouldReturnNotFound_WhenIdIsZeroOrNegative()
    {
        // Act
        var result = await _controller.DetailsAsync(0);

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result);
    }

    [Test]
    public async Task DetailsAsync_ShouldReturnViewWithModel_WhenGoalExists()
    {
        // Arrange
        int goalId = 10;
        var expectedGoal = new GoalDetailsViewModel { Id = goalId, Title = "Details Title" };

        _mockGoalService
            .Setup(s => s.GetDetailsAsync(goalId, _userId))
            .ReturnsAsync(expectedGoal);

        // Act
        var result = await _controller.DetailsAsync(goalId);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = (ViewResult)result;
        Assert.That(viewResult.Model, Is.EqualTo(expectedGoal));
    }

    [Test]
    public async Task DetailsAsync_ShouldReturnNotFound_WhenGoalDoesNotExist()
    {
        // Arrange
        int goalId = 10;
        _mockGoalService
            .Setup(s => s.GetDetailsAsync(goalId, _userId))
            .ReturnsAsync((GoalDetailsViewModel?)null);

        // Act
        var result = await _controller.DetailsAsync(goalId);

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result);
    }

    [Test]
    public async Task DeleteAsync_ShouldRedirectToIndex_AfterSuccessfulDeletion()
    {
        // Arrange
        int goalId = 1;

        // Act
        var result = await _controller.DeleteAsync(goalId);

        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var redirectResult = (RedirectToActionResult)result;
        Assert.That(redirectResult.ActionName, Is.EqualTo(nameof(_controller.Index)));

        // Service should get called once
        _mockGoalService.Verify(s => s.DeleteAsync(goalId, _userId), Times.Once);
    }

    [Test]
    public async Task ToggleStatus_ShouldRedirectToIndex_AfterStatusChange()
    {
        // Arrange
        int goalId = 5;

        // Act
        var result = await _controller.ToggleStatus(goalId);

        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var redirectResult = (RedirectToActionResult)result;
        Assert.That(redirectResult.ActionName, Is.EqualTo(nameof(_controller.Index)));

        // Service should get called once
        _mockGoalService.Verify(s => s.ToggleGoalStatusAsync(goalId, _userId), Times.Once);
    }

}
