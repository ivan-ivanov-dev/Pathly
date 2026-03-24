using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Pathly.DataModels;
using Pathly.GCommon;
using Pathly.Services.Contracts;
using Pathly.Tests.Common;
using Pathly.ViewModels.Tags;
using Pathly.ViewModels.TasksViewModels;
using Pathly.Web.Controllers;

namespace Pathly.Tests;

[TestFixture]
public class TasksControllerTests: ControllerTestsBase
{
    private Mock<ITaskService> _mockTaskService;
    private Mock<ITagService> _mockTagService;
    private Mock<IMapper> _mockMapper;
    private TasksController _controller;
    [SetUp]
    public void Setup()
    {
        _mockTaskService = new Mock<ITaskService>();
        _mockTagService = new Mock<ITagService>();
        _mockMapper = new Mock<IMapper>();
        
        _controller = new TasksController(_mockTaskService.Object, _mockTagService.Object,_mockMapper.Object, _mockUserManager.Object);

        SetupUser(_controller);
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
    public async Task Index_ShouldReturnViewWithModel()
    {
        // Arrange
        var queryModel = new TaskQueryModel();
        var expectedModel = new TaskListViewModel { Tasks = new PagedList<TaskViewModel>(new List<TaskViewModel>(), 0, 1, 0) };

        _mockTaskService.Setup(s => s.GetAllTasksAsync(queryModel, _userId))
            .ReturnsAsync(expectedModel);

        // Act
        var result = await _controller.Index(queryModel);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = (ViewResult)result;
        Assert.That(viewResult.Model, Is.EqualTo(expectedModel));
    }

    [Test]
    public async Task Create_Get_ShouldReturnPartialViewWithModel()
    {
        // Arrange
        int actionId = 10;
        var tags = new List<TagViewModel> { new TagViewModel { Id = 1, Name = "Urgent" } };
        _mockTagService.Setup(s => s.GetUserTagsAsync(_userId)).ReturnsAsync(tags);

        // Act
        var result = await _controller.CreateAsync(actionId);

        // Assert
        Assert.IsInstanceOf<PartialViewResult>(result);
        var partialResult = (PartialViewResult)result;
        Assert.That(partialResult.ViewName, Is.EqualTo("CreatePartialView"));

        var model = (TaskCreateViewModel)partialResult.Model!;
        Assert.That(model.ActionId, Is.EqualTo(actionId));
    }

    [Test]
    public async Task Create_Post_ShouldReturnOk_WhenModelIsValid()
    {
        // Arrange
        var model = new TaskCreateViewModel { Title = "Valid Task", SelectedTagIds = new List<int>() };

        // Act
        var result = await _controller.CreateAsync(model);

        // Assert
        Assert.IsInstanceOf<OkResult>(result);
        _mockTaskService.Verify(s => s.CreateAsync(model, _userId), Times.Once);
    }

    [Test]
    public async Task Create_Post_ShouldReturnPartialView_WhenTooManyTagsSelected()
    {
        // Arrange
        var model = new TaskCreateViewModel
        {
            Title = "Valid Title",
            SelectedTagIds = new List<int> { 1, 2, 3, 4, 5 }
        };

        _mockTagService.Setup(s => s.GetUserTagsAsync(_userId)).ReturnsAsync(new List<TagViewModel>());

        // Act
        var result = await _controller.CreateAsync(model);

        // Assert
        Assert.IsInstanceOf<PartialViewResult>(result);
        var partialResult = (PartialViewResult)result;
        Assert.That(partialResult.ViewName, Is.EqualTo("CreatePartialView"));

        Assert.IsFalse(_controller.ModelState.IsValid);
        Assert.IsTrue(_controller.ModelState.ContainsKey("SelectedTagIds"));
        _mockTaskService.Verify(s => s.CreateAsync(It.IsAny<TaskCreateViewModel>(), _userId), Times.Never);
    }

    [Test]
    public async Task Create_Post_ShouldReturnPartialView_WhenDueDateIsInPast()
    {
        // Arrange
        var model = new TaskCreateViewModel
        {
            Title = "Valid Title",
            DueDate = DateTime.Now.AddDays(-1),
            SelectedTagIds = new List<int>()
        };
        _mockTagService.Setup(s => s.GetUserTagsAsync(_userId)).ReturnsAsync(new List<TagViewModel>());

        // Act
        var result = await _controller.CreateAsync(model);

        // Assert
        Assert.IsInstanceOf<PartialViewResult>(result);
        Assert.IsTrue(_controller.ModelState.ContainsKey("DueDate"));
    }

    [Test]
    public async Task Create_Post_ShouldReturnPartialView_WhenServiceThrowsException()
    {
        // Arrange
        var model = new TaskCreateViewModel { Title = "Task", SelectedTagIds = new List<int>() };
        _mockTaskService.Setup(s => s.CreateAsync(model, _userId)).ThrowsAsync(new Exception("Fail"));
        _mockTagService.Setup(s => s.GetUserTagsAsync(_userId)).ReturnsAsync(new List<TagViewModel>());

        // Act
        var result = await _controller.CreateAsync(model);

        // Assert
        Assert.IsInstanceOf<PartialViewResult>(result);
        Assert.IsFalse(_controller.ModelState.IsValid);
        var error = _controller.ModelState[""]?.Errors.First().ErrorMessage;
        Assert.That(error, Does.Contain("Fail"));
    }

    [Test]
    public async Task Edit_Get_ShouldReturnPartialView_WhenTaskExists()
    {
        // Arrange
        int taskId = 1;
        var taskDetails = new TaskDetailsViewModel { Id = taskId, Title = "Existing Task" };
        var editModel = new TaskEditViewModel { Id = taskId, Title = "Existing Task" };
        var tagIds = new List<int> { 1, 2 };

        _mockTaskService.Setup(s => s.GetDetailsAsync(taskId, _userId)).ReturnsAsync(taskDetails);
        _mockTaskService.Setup(s => s.GetTaskTagIdsAsync(taskId, _userId)).ReturnsAsync(tagIds);
        _mockTagService.Setup(s => s.GetUserTagsAsync(_userId)).ReturnsAsync(new List<TagViewModel>());
        _mockMapper.Setup(m => m.Map<TaskEditViewModel>(taskDetails)).Returns(editModel);

        // Act
        var result = await _controller.EditAsync(taskId);

        // Assert
        Assert.IsInstanceOf<PartialViewResult>(result);
        var partialResult = (PartialViewResult)result;
        Assert.That(partialResult.ViewName, Is.EqualTo("EditPartialView"));

        var model = (TaskEditViewModel)partialResult.Model!;
        Assert.That(model.Id, Is.EqualTo(taskId));
        Assert.That(model.SelectedTagIds, Is.EqualTo(tagIds));
    }

    [Test]
    public async Task Edit_Get_ShouldReturnNotFound_WhenTaskDoesNotExist()
    {
        // Arrange
        _mockTaskService.Setup(s => s.GetDetailsAsync(It.IsAny<int>(), _userId))
            .ReturnsAsync((TaskDetailsViewModel?)null);

        // Act
        var result = await _controller.EditAsync(99);

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result);
    }

    [Test]
    public async Task Edit_Post_ShouldReturnOk_WhenModelIsValidAndIsAjax()
    {
        // Arrange
        var model = new TaskEditViewModel { Id = 1, Title = "Updated Task", SelectedTagIds = new List<int>() };

        // Simulate AJAX Header
        _controller.ControllerContext.HttpContext.Request.Headers["X-Requested-With"] = "XMLHttpRequest";

        // Act
        var result = await _controller.EditAsync(model);

        // Assert
        Assert.IsInstanceOf<OkResult>(result);
        _mockTaskService.Verify(s => s.UpdateWithTagsAsync(model.Id, model, _userId), Times.Once);
    }

    [Test]
    public async Task Edit_Post_ShouldRedirectToIndex_WhenModelIsValidAndNotAjax()
    {
        // Arrange
        var model = new TaskEditViewModel { Id = 1, Title = "Updated Task", SelectedTagIds = new List<int>() };

        // Act
        var result = await _controller.EditAsync(model);

        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var redirect = (RedirectToActionResult)result;
        Assert.That(redirect.ActionName, Is.EqualTo("Index"));
    }

    [Test]
    public async Task Edit_Post_ShouldReturnPartialView_WhenValidationFails()
    {
        // Arrange
        var model = new TaskEditViewModel { Id = 1, Title = "", SelectedTagIds = new List<int>() };
        _mockTagService.Setup(s => s.GetUserTagsAsync(_userId)).ReturnsAsync(new List<TagViewModel>());

        // Act
        var result = await _controller.EditAsync(model);

        // Assert
        Assert.IsInstanceOf<PartialViewResult>(result);
        Assert.IsFalse(_controller.ModelState.IsValid);
    }

    [Test]
    public async Task Delete_Get_ShouldReturnPartialView_WhenTaskExists()
    {
        // Arrange
        int taskId = 1;
        var taskDetails = new TaskDetailsViewModel { Id = taskId, Title = "Task to Delete" };
        var deleteModel = new TaskDeleteViewModel { Id = taskId, Title = "Task to Delete" };

        _mockTaskService.Setup(s => s.GetDetailsAsync(taskId, _userId)).ReturnsAsync(taskDetails);
        _mockMapper.Setup(m => m.Map<TaskDeleteViewModel>(taskDetails)).Returns(deleteModel);

        // Act
        var result = await _controller.DeleteAsync(taskId);

        // Assert
        Assert.IsInstanceOf<PartialViewResult>(result);
        var partialResult = (PartialViewResult)result;
        Assert.That(partialResult.ViewName, Is.EqualTo("DeletePartialView"));
        Assert.That(partialResult.Model, Is.EqualTo(deleteModel));
    }

    [Test]
    public async Task Delete_Get_ShouldReturnNotFound_WhenTaskDoesNotExist()
    {
        // Arrange
        _mockTaskService.Setup(s => s.GetDetailsAsync(It.IsAny<int>(), _userId))
            .ReturnsAsync((TaskDetailsViewModel?)null);

        // Act
        var result = await _controller.DeleteAsync(99);

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result);
    }

    [Test]
    public async Task Delete_Post_ShouldReturnJsonSuccess_WhenAjaxAndSuccessful()
    {
        // Arrange
        var model = new TaskDeleteViewModel { Id = 1 };
        _mockTaskService.Setup(s => s.DeleteAsync(model.Id, _userId)).ReturnsAsync(true);

        // Simulate AJAX Header
        _controller.ControllerContext.HttpContext.Request.Headers["X-Requested-With"] = "XMLHttpRequest";

        // Act
        var result = await _controller.DeleteAsync(model);

        // Assert
        Assert.IsInstanceOf<JsonResult>(result);
        var jsonResult = (JsonResult)result;

        // Use reflection to check annonymous types
        var successProp = jsonResult.Value?.GetType().GetProperty("success")?.GetValue(jsonResult.Value, null);
        Assert.That(successProp, Is.True);
    }

    [Test]
    public async Task Delete_Post_ShouldRedirectToIndex_WhenNotAjax()
    {
        // Arrange
        var model = new TaskDeleteViewModel { Id = 1 };
        _mockTaskService.Setup(s => s.DeleteAsync(model.Id, _userId)).ReturnsAsync(true);

        // Act
        var result = await _controller.DeleteAsync(model);

        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var redirect = (RedirectToActionResult)result;
        Assert.That(redirect.ActionName, Is.EqualTo("Index"));
    }

    [Test]
    public async Task Details_ShouldReturnPartialView_WhenTaskExists()
    {
        // Arrange
        int taskId = 1;
        var expectedModel = new TaskDetailsViewModel { Id = taskId, Title = "Details" };
        _mockTaskService.Setup(s => s.GetDetailsAsync(taskId, _userId)).ReturnsAsync(expectedModel);

        // Act
        var result = await _controller.DetailsAsync(taskId);

        // Assert
        Assert.IsInstanceOf<PartialViewResult>(result);
        var partialResult = (PartialViewResult)result;
        Assert.That(partialResult.ViewName, Is.EqualTo("DetailsPartialView"));
        Assert.That(partialResult.Model, Is.EqualTo(expectedModel));
    }

    [Test]
    public async Task MarkTaskStatus_ShouldRedirectToIndex()
    {
        // Arrange
        int taskId = 1;

        // Act
        var result = await _controller.MarkTaskStatus(taskId);

        // Assert
        _mockTaskService.Verify(s => s.MarkTaskStatusAsync(taskId, _userId), Times.Once);
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var redirect = (RedirectToActionResult)result;
        Assert.That(redirect.ActionName, Is.EqualTo("Index"));
    }

    [Test]
    public async Task UpdatePriority_ShouldCallServiceAndRedirect()
    {
        // Arrange
        int taskId = 1;
        var priority = TaskPriority.High;

        // Act
        var result = await _controller.UpdatePriority(taskId, priority);

        // Assert
        _mockTaskService.Verify(s => s.UpdatePriorityAsync(taskId, priority, _userId), Times.Once);
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var redirect = (RedirectToActionResult)result;
        Assert.That(redirect.ActionName, Is.EqualTo("Index"));
    }
}
