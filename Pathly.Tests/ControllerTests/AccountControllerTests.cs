using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Pathly.Data;
using Pathly.DataModels;
using Pathly.Tests.Common;
using Pathly.ViewModels.Authentication;
using Pathly.Web.Areas.Identity.Controllers;

namespace Pathly.Tests;

[TestFixture]
public class AccountControllerTests : IdentityTestBase
{
    private AccountController _controller;
    private Mock<ApplicationDbContext> _mockContext;
    [SetUp]
    public override void Setup()
    {
        base.Setup();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .Options;

        var mockConfiguration = new Mock<IConfiguration>();

        _mockContext = new Mock<ApplicationDbContext>(options, mockConfiguration.Object);

        _controller = new AccountController(
            MockUserManager.Object,
            MockSignInManager.Object,
            _mockContext.Object);
    }

    [TearDown]
    public void Teardown()
    {
        if (_controller != null)
        {
            _controller.Dispose();
        }
    }

    [Test]
    public void Register_ReturnsView()
    {
        // Act
        var result = _controller.Register();

        // Assert
        Assert.That(result, Is.TypeOf<ViewResult>());
    }

    [Test]
    public async Task RegisterPost_InvalidModelState_ReturnsViewWithModel()
    {
        // Arrange
        var model = new SignInViewModel();
        _controller.ModelState.AddModelError("Email", "Required");

        // Act
        var result = await _controller.RegisterAsync(model);

        // Assert
        var viewResult = (ViewResult)result;
        Assert.That(viewResult, Is.Not.Null);
        Assert.That(viewResult.Model, Is.EqualTo(model));
    }

    [Test]
    public async Task RegisterPost_SuccessfulRegistration_RedirectsToHome()
    {
        // Arrange
        var model = new SignInViewModel
        {
            UserName = "newuser",
            Email = "test@pathly.com",
            Password = "SecurePassword123!"
        };

        MockUserManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Success);

        MockSignInManager.Setup(x => x.SignInAsync(It.IsAny<ApplicationUser>(), false, null))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.RegisterAsync(model);

        // Assert
        var redirectResult = (RedirectToActionResult)result;
        Assert.That(redirectResult, Is.Not.Null);
        Assert.That(redirectResult.ActionName, Is.EqualTo("Index"));
        Assert.That(redirectResult.ControllerName, Is.EqualTo("Home"));
    }

    [Test]
    public async Task RegisterPost_IdentityError_AddsErrorsToModelState()
    {
        // Arrange
        var model = new SignInViewModel { UserName = "user", Email = "email@e.com", Password = "1" };
        var identityError = new IdentityError { Description = "Password too weak" };

        MockUserManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Failed(identityError));

        // Act
        var result = await _controller.RegisterAsync(model);

        // Assert
        Assert.That(_controller.ModelState.IsValid, Is.False);
        var viewResult = (ViewResult)result;
        Assert.That(viewResult, Is.Not.Null);
    }

    [Test]
    public void Login_Get_ReturnsView()
    {
        var result = _controller.Login();
        Assert.That(result, Is.TypeOf<ViewResult>());
    }

    [Test]
    public async Task Login_Post_InvalidModelState_ReturnsViewWithModel()
    {
        // Arrange
        var model = new LoginViewModel();
        _controller.ModelState.AddModelError("Email", "Required");

        // Act
        var result = await _controller.Login(model);

        // Assert
        var viewResult = result as ViewResult;
        Assert.That(viewResult, Is.Not.Null);
        Assert.That(viewResult.Model, Is.EqualTo(model));
    }

    [Test]
    public async Task Login_Post_WrongPassword_ReturnsViewWithErrorMessage()
    {
        var user = new ApplicationUser { UserName = "testuser", Email = "test@test.com" };
        var model = new LoginViewModel { Email = "test@test.com", Password = "wrongpassword" };

        MockUserManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(user);

        MockSignInManager.Setup(x => x.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false))
            .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Failed);

        var result = await _controller.Login(model);

        Assert.That(_controller.ModelState.IsValid, Is.False);
        Assert.That(result, Is.TypeOf<ViewResult>());
    }

    [Test]
    public async Task Login_Post_Successful_RedirectsToHome()
    {
        // Arrange
        var user = new ApplicationUser { UserName = "testuser", Email = "test@test.com" };
        var model = new LoginViewModel { Email = "test@test.com", Password = "CorrectPassword123!", RememberMe = true };

        MockUserManager.Setup(x => x.FindByEmailAsync(model.Email))
            .ReturnsAsync(user);

        MockSignInManager.Setup(x => x.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false))
            .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

        // Act
        var result = await _controller.Login(model);

        // Assert
        var redirect = result as RedirectToActionResult;
        Assert.That(redirect, Is.Not.Null);
        Assert.That(redirect.ActionName, Is.EqualTo("Index"));
        Assert.That(redirect.ControllerName, Is.EqualTo("Home"));
    }

    [Test]
    public async Task Logout_Post_SignsOutAndRedirectsToLogin()
    {
        // Arrange
        MockSignInManager.Setup(x => x.SignOutAsync())
            .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.Logout();

        // Assert
        var redirect = result as RedirectToActionResult;
        Assert.That(redirect, Is.Not.Null);
        Assert.That(redirect.ActionName, Is.EqualTo("Login"));
        Assert.That(redirect.ControllerName, Is.EqualTo("Account"));
        Assert.That(redirect.RouteValues["area"], Is.EqualTo("Identity"));

        MockSignInManager.Verify(x => x.SignOutAsync(), Times.Once);
    }
}
