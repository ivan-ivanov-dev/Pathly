using Microsoft.AspNetCore.Mvc;
using Moq;
using Pathly.Services.Contracts;
using Pathly.Services.Implementation;
using Pathly.Tests.Common;
using Pathly.ViewModels.Admin;
using Pathly.Web.Areas.Admin.Controllers;

namespace Pathly.Tests;

public class AdminDashboardControllerTests: ControllerTestsBase
{
    private Mock<IAdminService> _mockAdminService;
    private DashboardController _controller;
    [SetUp]
    public void Setup()
    {
        _mockAdminService = new Mock<IAdminService>();
        _controller = new DashboardController(_mockAdminService.Object);

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
    public async Task IndexAsync_ReturnsViewWithStatistics()
    {
        // Arrange
        var expectedStats = new AdminStatisticsViewModel
        {
            TotalUsers = 10,
            TotalGoals = 5,
            CompletedTasks = 20
        };

        _mockAdminService.Setup(s => s.GetStatisticsAsync())
            .ReturnsAsync(expectedStats);

        // Act
        var result = await _controller.IndexAsync();

        // Assert
        var viewResult = (ViewResult)result;
        Assert.That(viewResult, Is.Not.Null);
        Assert.That(viewResult.Model, Is.EqualTo(expectedStats));
        _mockAdminService.Verify(s => s.GetStatisticsAsync(), Times.Once);
    }

    [Test]
    public async Task Users_ReturnsViewWithUserList()
    {
        // Arrange
        var expectedUsers = new List<UserListViewModel>
            {
                new UserListViewModel { Id = "1", UserName = "admin", Email = "a@a.com" },
                new UserListViewModel { Id = "2", UserName = "user", Email = "u@u.com" }
            };

        _mockAdminService.Setup(s => s.GetAllUsersAsync())
            .ReturnsAsync(expectedUsers);

        // Act
        var result = await _controller.Users();

        // Assert
        var viewResult = (ViewResult)result;
        Assert.That(viewResult, Is.Not.Null);
        Assert.That(viewResult.Model, Is.EqualTo(expectedUsers));
        _mockAdminService.Verify(s => s.GetAllUsersAsync(), Times.Once);
    }

    [Test]
    public async Task DeleteUser_ReturnsSuccessJson_WhenServiceSucceeds()
    {
        // Arrange
        _mockAdminService.Setup(s => s.DeleteUserAsync("user-1")).ReturnsAsync(true);

        // Act
        var result = await _controller.DeleteUser("user-1");

        // Assert
        var jsonResult = result as JsonResult;
        Assert.That(jsonResult, Is.Not.Null);

        var data = jsonResult.Value.GetType().GetProperty("success").GetValue(jsonResult.Value, null);
        var message = jsonResult.Value.GetType().GetProperty("message").GetValue(jsonResult.Value, null);

        Assert.That(data, Is.True);
        Assert.That(message, Is.EqualTo("User deleted successfully!"));
    }

    [Test]
    public async Task DeleteUser_ReturnsErrorJson_WhenServiceFails()
    {
        // Arrange
        _mockAdminService.Setup(s => s.DeleteUserAsync("user-1")).ReturnsAsync(false);

        // Act
        var result = await _controller.DeleteUser("user-1");

        // Assert
        var jsonResult = result as JsonResult;
        var data = jsonResult.Value.GetType().GetProperty("success").GetValue(jsonResult.Value, null);

        Assert.That(data, Is.False);
    }

    [Test]
    public async Task ChangeRole_ReturnsSuccessJson_WhenRoleUpdated()
    {
        // Arrange
        string userId = "user-1";
        string role = "Admin";
        _mockAdminService.Setup(s => s.ChangeUserRoleAsync(userId, role)).ReturnsAsync(true);

        // Act
        var result = await _controller.ChangeRole(userId, role);

        // Assert
        var jsonResult = result as JsonResult;
        var data = jsonResult.Value.GetType().GetProperty("success").GetValue(jsonResult.Value, null);
        var message = jsonResult.Value.GetType().GetProperty("message").GetValue(jsonResult.Value, null);

        Assert.That(data, Is.True);
        Assert.That(message, Is.EqualTo($"Role updated to {role}!"));
    }

    [Test]
    public async Task ChangeRole_ReturnsErrorJson_WhenUpdateFails()
    {
        // Arrange
        _mockAdminService.Setup(s => s.ChangeUserRoleAsync(It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(false);

        // Act
        var result = await _controller.ChangeRole("1", "Admin");

        // Assert
        var jsonResult = result as JsonResult;
        var data = jsonResult.Value.GetType().GetProperty("success").GetValue(jsonResult.Value, null);
        Assert.That(data, Is.False);
    }

    [Test]
    public async Task ToggleLockout_ReturnsSuccessJson_WhenToggled()
    {
        // Arrange
        _mockAdminService.Setup(s => s.ToggleUserLockoutAsync("user-1")).ReturnsAsync(true);

        // Act
        var result = await _controller.ToggleLockout("user-1");

        // Assert
        var jsonResult = result as JsonResult;
        var data = jsonResult.Value.GetType().GetProperty("success").GetValue(jsonResult.Value, null);

        Assert.That(data, Is.True);
        Assert.That(jsonResult.Value.GetType().GetProperty("message").GetValue(jsonResult.Value, null),
            Is.EqualTo("User status updated successfully!"));
    }

    [Test]
    public async Task ToggleLockout_ReturnsErrorJson_WhenServiceFails()
    {
        // Arrange
        _mockAdminService.Setup(s => s.ToggleUserLockoutAsync(It.IsAny<string>())).ReturnsAsync(false);

        // Act
        var result = await _controller.ToggleLockout("user-1");

        // Assert
        var jsonResult = result as JsonResult;
        var data = jsonResult.Value.GetType().GetProperty("success").GetValue(jsonResult.Value, null);
        Assert.That(data, Is.False);
    }

}
