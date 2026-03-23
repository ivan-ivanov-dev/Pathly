using Microsoft.AspNetCore.Mvc;
using Moq;
using Pathly.Services.Contracts;
using Pathly.Tests.Common;
using Pathly.ViewModels.Dashboard;
using Pathly.Web.Controllers;
using System.Security.Claims;

namespace Pathly.Tests;

[TestFixture]
public class DashboardControllerTests: ControllerTestsBase
{
    private Mock<IDashboardService> _mockDashboardService;
    private DashboardController _controller;

    [SetUp]
    public void Setup()
    {
        _mockDashboardService = new Mock<IDashboardService>();
        _controller = new DashboardController(_mockDashboardService.Object);

        SetupUser(_controller);
    }

    [TearDown]
    public void TearDown()
    {
        _controller.Dispose();
    }

    [Test]
    public async Task Index_ShouldReturnViewWithCorrectModelIndex_ShouldReturnViewWithCorrectModel()
    {
        // Arrange
        var expectedStats = new DashboardStatsViewModel 
        {
            TotalGoals = 5, 
            CompletedGoals = 2, 
            TotalTasks = 3, 
            CompletedTasks = 1, 
            TotalTasksDueToday = 2, 
            CompletedTasksDueToday = 0 
        };
        var expectedFocusLists = new DashboardFocusListsViewModel
        {
            OverdueTasks = new List<TaskSummaryViewModel>(),
            DueTodayTasks = new List<TaskSummaryViewModel>(),
            FutureHighPriorityTasks = new List<TaskSummaryViewModel>()
        };

        _mockDashboardService
            .Setup(s => s.GetDashboardStatsAsync(_userId))
            .ReturnsAsync(expectedStats);

        _mockDashboardService
            .Setup(s => s.GetDashboardFocusListsAsync(_userId))
            .ReturnsAsync(expectedFocusLists);

        // Act
        var result = await _controller.Index();

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = (ViewResult)result;

        Assert.IsInstanceOf<DashboardViewModel>(viewResult.Model);
        var model = (DashboardViewModel)viewResult.Model!;

        // Check if data has reached the model
        Assert.That(model.Stats, Is.EqualTo(expectedStats));
        Assert.That(model.FocusLists, Is.EqualTo(expectedFocusLists));
    }
    [Test]
    public async Task Index_ShouldReturnUnauthorized_WhenUserIdClaimIsMissing()
    {
        // Arrange
        // Cause an error by giving making an Identity with no claims
        var emptyUser = new ClaimsPrincipal(new ClaimsIdentity());
        _controller.ControllerContext.HttpContext.User = emptyUser;

        // Act
        var result = await _controller.Index();

        // Assert
        Assert.IsInstanceOf<UnauthorizedResult>(result);

        _mockDashboardService.Verify(s => s.GetDashboardStatsAsync(It.IsAny<string>()), Times.Never);
    }
}
