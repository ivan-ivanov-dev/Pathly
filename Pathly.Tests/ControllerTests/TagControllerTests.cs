using Microsoft.AspNetCore.Mvc;
using Moq;
using Pathly.Services.Contracts;
using Pathly.Tests.Common;
using Pathly.ViewModels.Tags;
using Pathly.Web.Controllers;

namespace Pathly.Tests;

[TestFixture]
public class TagControllerTests : ControllerTestsBase
{
    private Mock<ITagService> _mockTagService;
    private TagController _controller;

    [SetUp]
    public void Setup()
    {
        _mockTagService = new Mock<ITagService>();
        _controller = new TagController(_mockTagService.Object, _mockUserManager.Object);

        SetupUser(_controller);
    }

    [TearDown]
    public void TearDown()
    {
        _controller.Dispose();
    }

    [Test]
    public async Task Index_ShouldReturnViewWithTags()
    {
        // Arrange
        var expectedTags = new List<TagViewModel>
        {
            new TagViewModel { Id = 1, Name = "Work" }
        };

        _mockTagService
            .Setup(s => s.GetUserTagsAsync(_userId, It.IsAny<string>()))
            .ReturnsAsync(expectedTags);

        // Act
        var result = await _controller.Index(null);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = (ViewResult)result;
        Assert.That(viewResult.Model, Is.EqualTo(expectedTags));
    }

    [Test]
    public void Create_Get_ShouldReturnViewWithEmptyModel()
    {
        // Act
        var result = _controller.Create();

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = (ViewResult)result;
        Assert.IsInstanceOf<TagViewModel>(viewResult.Model);
    }

    [Test]
    public async Task Create_Post_ShouldReturnOk_WhenSuccessful()
    {
        // Arrange
        var model = new TagViewModel { Name = "NewTag" };

        // Act
        var result = await _controller.Create(model);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
        _mockTagService.Verify(s => s.CreateTagAsync(model.Name, _userId), Times.Once);
    }

    [Test]
    public async Task Create_Post_ShouldReturnBadRequest_WhenModelStateIsInvalid()
    {
        // Arrange
        var model = new TagViewModel { Name = "" };
        _controller.ModelState.AddModelError("Name", "Required");

        // Act
        var result = await _controller.Create(model);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _mockTagService.Verify(s => s.CreateTagAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    [Test]
    public async Task Create_Post_ShouldReturnBadRequest_WhenTagExists()
    {
        // Arrange
        var model = new TagViewModel { Name = "Existing" };
        _mockTagService
            .Setup(s => s.CreateTagAsync(model.Name, _userId))
            .ThrowsAsync(new InvalidOperationException("Tag exists"));

        // Act
        var result = await _controller.Create(model);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        var badRequest = (BadRequestObjectResult)result;
    }

    [Test]
    public async Task Delete_ShouldRedirectToIndex()
    {
        // Arrange
        int tagId = 1;

        // Act
        var result = await _controller.Delete(tagId);

        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var redirect = (RedirectToActionResult)result;
        Assert.That(redirect.ActionName, Is.EqualTo(nameof(_controller.Index)));

        _mockTagService.Verify(s => s.DeleteTagAsync(tagId, _userId), Times.Once);
    }
}
