using Microsoft.AspNetCore.Identity;
using MockQueryable;
using Moq;
using Pathly.DataModels;
using Pathly.Services.Implementation;
using Pathly.Tests.Common;

namespace Pathly.Tests;

public class AdminServiceTests: ServiceTestsBase
{
    private Mock<UserManager<ApplicationUser>> _mockUserManager;
    private AdminService _adminService;
    [SetUp]
    public void Setup()
    {
        base.BaseSetup();

        var store = new Mock<IUserStore<ApplicationUser>>();
        _mockUserManager = new Mock<UserManager<ApplicationUser>>(
            store.Object, null, null, null, null, null, null, null, null);

        _adminService = new AdminService(_mockUserManager.Object, _context);
    }

    [TearDown]
    public void TearDown()
    {
        base.BaseTearDown();
    }

    [Test]
    public async Task ChangeUserRoleAsync_UserNotFound_ReturnsFalse()
    {
        // Arrange
        _mockUserManager.Setup(x => x.FindByIdAsync(It.IsAny<string>()))
            .ReturnsAsync((ApplicationUser)null);

        // Act
        var result = await _adminService.ChangeUserRoleAsync("invalid-id", "Admin");

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task ChangeUserRoleAsync_Successful_ReturnsTrue()
    {
        // Arrange
        var user = new ApplicationUser { Id = "user-1", UserName = "test" };
        var currentRoles = new List<string> { "User" };

        _mockUserManager.Setup(x => x.FindByIdAsync(user.Id)).ReturnsAsync(user);
        _mockUserManager.Setup(x => x.GetRolesAsync(user)).ReturnsAsync(currentRoles);
        _mockUserManager.Setup(x => x.RemoveFromRolesAsync(user, currentRoles)).ReturnsAsync(IdentityResult.Success);
        _mockUserManager.Setup(x => x.AddToRoleAsync(user, "Admin")).ReturnsAsync(IdentityResult.Success);

        // Act
        var result = await _adminService.ChangeUserRoleAsync(user.Id, "Admin");

        // Assert
        Assert.That(result, Is.True);
        _mockUserManager.Verify(x => x.RemoveFromRolesAsync(user, It.IsAny<IEnumerable<string>>()), Times.Once);
        _mockUserManager.Verify(x => x.AddToRoleAsync(user, "Admin"), Times.Once);
    }

    [Test]
    public async Task DeleteUserAsync_UserNotFound_ReturnsFalse()
    {
        // Arrange
        _mockUserManager.Setup(x => x.FindByIdAsync(It.IsAny<string>()))
            .ReturnsAsync((ApplicationUser)null);

        // Act
        var result = await _adminService.DeleteUserAsync("invalid-id");

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task DeleteUserAsync_Successful_ReturnsTrue()
    {
        // Arrange
        var user = new ApplicationUser { Id = "user-to-delete", UserName = "delete-me" };

        _mockUserManager.Setup(x => x.FindByIdAsync(user.Id)).ReturnsAsync(user);
        _mockUserManager.Setup(x => x.DeleteAsync(user)).ReturnsAsync(IdentityResult.Success);

        // Act
        var result = await _adminService.DeleteUserAsync(user.Id);

        // Assert
        Assert.That(result, Is.True);
        _mockUserManager.Verify(x => x.DeleteAsync(user), Times.Once);
    }

    [Test]
    public async Task DeleteUserAsync_IdentityFails_ReturnsFalse()
    {
        // Arrange
        var user = new ApplicationUser { Id = "user-id" };
        _mockUserManager.Setup(x => x.FindByIdAsync(user.Id)).ReturnsAsync(user);
        _mockUserManager.Setup(x => x.DeleteAsync(user)).ReturnsAsync(IdentityResult.Failed());

        // Act
        var result = await _adminService.DeleteUserAsync(user.Id);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task GetAllUsersAsync_ReturnsAllUsersWithRoles()
    {
        // Arrange
        var users = new List<ApplicationUser>
        {
            new ApplicationUser { Id = "1", Email = "admin@pathly.com", UserName = "admin" },
            new ApplicationUser { Id = "2", Email = "user@pathly.com", UserName = "user" }
        };

        var mockUsers = users.BuildMock();

        _mockUserManager.Setup(x => x.Users).Returns(mockUsers);

        _mockUserManager.Setup(x => x.GetRolesAsync(It.IsAny<ApplicationUser>()))
            .ReturnsAsync(new List<string> { "User" });

        _mockUserManager.Setup(x => x.IsLockedOutAsync(It.IsAny<ApplicationUser>()))
            .ReturnsAsync(false);

        // Act
        var result = await _adminService.GetAllUsersAsync();

        // Assert
        Assert.That(result.Count(), Is.EqualTo(2));
        Assert.That(result.First().Email, Is.EqualTo("admin@pathly.com"));
        _mockUserManager.Verify(x => x.GetRolesAsync(It.IsAny<ApplicationUser>()), Times.Exactly(2));
    }
    [Test]
    public async Task GetStatisticsAsync_ReturnsCorrectCounts()
    {
        // Arrange
        var usersList = new List<ApplicationUser> { new ApplicationUser(), new ApplicationUser() };
        var mockUsers = usersList.BuildMock();

        _mockUserManager.Setup(x => x.Users).Returns(mockUsers);

        _context.Goals.Add(new Goal { Title = "Goal 1", UserId = "1" });
        _context.Tasks.Add(new TaskItem { Title = "Task 1", IsCompleted = true, UserId = "1" });
        _context.Tasks.Add(new TaskItem { Title = "Task 2", IsCompleted = false, UserId = "1" });
        await _context.SaveChangesAsync();

        // Act
        var result = await _adminService.GetStatisticsAsync();

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(result.TotalUsers, Is.EqualTo(2), "Users count is wrong");

            //the number is different than 1 because there is data left in the InMemory database
            Assert.That(result.TotalGoals, Is.EqualTo(4), "Goals count is wrong");
            Assert.That(result.CompletedTasks, Is.EqualTo(15), "Completed tasks count is wrong");
        });
    }

    [Test]
    public async Task ToggleUserLockoutAsync_UserNotFound_ReturnsFalse()
    {
        _mockUserManager.Setup(x => x.FindByIdAsync(It.IsAny<string>()))
            .ReturnsAsync((ApplicationUser)null);

        var result = await _adminService.ToggleUserLockoutAsync("invalid");

        Assert.That(result, Is.False);
    }

    [Test]
    public async Task ToggleUserLockoutAsync_WhenLocked_UnlocksUser()
    {
        // Arrange
        var user = new ApplicationUser { Id = "locked-user" };
        _mockUserManager.Setup(x => x.FindByIdAsync(user.Id)).ReturnsAsync(user);
        _mockUserManager.Setup(x => x.IsLockedOutAsync(user)).ReturnsAsync(true);

        _mockUserManager.Setup(x => x.SetLockoutEndDateAsync(user, It.IsAny<DateTimeOffset?>()))
            .ReturnsAsync(IdentityResult.Success);

        // Act
        var result = await _adminService.ToggleUserLockoutAsync(user.Id);

        // Assert
        Assert.That(result, Is.True);
        _mockUserManager.Verify(x => x.SetLockoutEndDateAsync(user, It.Is<DateTimeOffset?>(d => d.Value.Year < DateTimeOffset.UtcNow.Year + 1)), Times.Once);
    }

    [Test]
    public async Task ToggleUserLockoutAsync_WhenUnlocked_LocksUser()
    {
        // Arrange
        var user = new ApplicationUser { Id = "active-user" };
        _mockUserManager.Setup(x => x.FindByIdAsync(user.Id)).ReturnsAsync(user);
        _mockUserManager.Setup(x => x.IsLockedOutAsync(user)).ReturnsAsync(false);

        _mockUserManager.Setup(x => x.SetLockoutEndDateAsync(user, It.IsAny<DateTimeOffset?>()))
            .ReturnsAsync(IdentityResult.Success);

        // Act
        var result = await _adminService.ToggleUserLockoutAsync(user.Id);

        // Assert
        Assert.That(result, Is.True);
        _mockUserManager.Verify(x => x.SetLockoutEndDateAsync(user, It.Is<DateTimeOffset?>(d => d.Value.Year > DateTimeOffset.UtcNow.Year + 50)), Times.Once);
    }
}

