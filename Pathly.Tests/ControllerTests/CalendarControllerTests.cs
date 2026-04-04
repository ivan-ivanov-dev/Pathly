using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Pathly.Controllers;
using Pathly.Services.Contracts;
using Pathly.Tests.Common;
using Pathly.ViewModels.Event;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pathly.Tests.Controllers
{
    [TestFixture]
    public class CalendarControllerTests : ControllerTestsBase
    {
        private Mock<IEventService> _mockEventService;
        private CalendarController _controller;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            _mockEventService = new Mock<IEventService>();
            _controller = new CalendarController(_mockEventService.Object, _mockUserManager.Object);
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
        public void Index_ReturnsView()
        {
            // Act
            var result = _controller.Index();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public async Task GetEvents_Success_ReturnsJsonEvents()
        {
            // Arrange
            var events = new List<EventCalendarViewModel> { new EventCalendarViewModel { Title = "Test" } };
            _mockEventService.Setup(s => s.GetAllForCalendarAsync(_userId)).ReturnsAsync(events);

            // Act
            var result = await _controller.GetEvents();

            // Assert
            Assert.IsInstanceOf<JsonResult>(result);
            var jsonResult = (JsonResult)result;
            Assert.That(jsonResult.Value, Is.EqualTo(events));
        }

        [Test]
        public async Task GetEvents_NoUserId_ReturnsEmptyListJson()
        {
            // Arrange
            _mockUserManager.Setup(um => um.GetUserId(It.IsAny<System.Security.Claims.ClaimsPrincipal>())).Returns(string.Empty);

            // Act
            var result = await _controller.GetEvents();

            // Assert
            Assert.IsInstanceOf<JsonResult>(result);
            var jsonResult = (JsonResult)result;
            Assert.IsInstanceOf<List<EventCalendarViewModel>>(jsonResult.Value);
            Assert.IsEmpty((List<EventCalendarViewModel>)jsonResult.Value!);
        }

        [Test]
        public async Task GetEvents_OnException_ReturnsEmptyListJson()
        {
            // Arrange
            _mockEventService.Setup(s => s.GetAllForCalendarAsync(_userId)).ThrowsAsync(new InvalidOperationException());

            // Act
            var result = await _controller.GetEvents();

            // Assert
            Assert.IsInstanceOf<JsonResult>(result);
            var jsonResult = (JsonResult)result;
            Assert.IsEmpty((IEnumerable<EventCalendarViewModel>)jsonResult.Value!);
        }

        [Test]
        public async Task Create_Get_ReturnsPartialViewWithModel()
        {
            // Arrange
            var model = new EventFormViewModel();
            _mockEventService.Setup(s => s.PrepareFormModelAsync(_userId)).ReturnsAsync(model);

            // Act
            var result = await _controller.Create();

            // Assert
            Assert.IsInstanceOf<PartialViewResult>(result);
            var partial = (PartialViewResult)result;
            Assert.That(partial.ViewName, Is.EqualTo("_CreateEventPartial"));
            Assert.That(partial.Model, Is.EqualTo(model));
        }

        [Test]
        public async Task Create_Post_ValidModel_ReturnsOk()
        {
            // Arrange
            var model = new EventFormViewModel { Title = "New Event" };

            // Act
            var result = await _controller.Create(model);

            // Assert
            _mockEventService.Verify(s => s.CreateAsync(model, _userId), Times.Once);
            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        public async Task Create_Post_InvalidModelState_ReturnsBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("Title", "Required");
            var model = new EventFormViewModel();

            // Act
            var result = await _controller.Create(model);

            // Assert
            Assert.IsInstanceOf<BadRequestResult>(result);
        }

        [Test]
        public async Task Create_Post_ServiceThrowsArgumentException_ReturnsBadRequestWithMessage()
        {
            // Arrange
            var model = new EventFormViewModel();
            _mockEventService.Setup(s => s.CreateAsync(model, _userId)).ThrowsAsync(new ArgumentException("Error"));

            // Act
            var result = await _controller.Create(model);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            var badRequest = (BadRequestObjectResult)result;
            Assert.That(badRequest.Value, Is.EqualTo("Error"));
        }

        [Test]
        public async Task Edit_Get_ValidId_ReturnsPartialView()
        {
            // Arrange
            int eventId = 1;
            var model = new EventFormViewModel { Id = eventId };
            _mockEventService.Setup(s => s.GetForEditAsync(eventId, _userId)).ReturnsAsync(model);

            // Act
            var result = await _controller.Edit(eventId);

            // Assert
            Assert.IsInstanceOf<PartialViewResult>(result);
            var partial = (PartialViewResult)result;
            Assert.That(partial.ViewName, Is.EqualTo("_EditEventPartial"));
        }

        [Test]
        public async Task Edit_Get_ModelNull_ReturnsNotFound()
        {
            // Arrange
            _mockEventService.Setup(s => s.GetForEditAsync(1, _userId)).ReturnsAsync((EventFormViewModel?)null);

            // Act
            var result = await _controller.Edit(1);

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }

        [Test]
        public async Task Edit_Get_ThrowsException_ReturnsInternalServerError()
        {
            // Arrange
            _mockEventService.Setup(s => s.GetForEditAsync(1, _userId)).ThrowsAsync(new Exception("Fail"));

            // Act
            var result = await _controller.Edit(1);

            // Assert
            var statusResult = (ObjectResult)result;
            Assert.That(statusResult.StatusCode, Is.EqualTo(500));
        }

        [Test]
        public async Task Edit_Post_ValidUpdate_ReturnsOk()
        {
            // Arrange
            var model = new EventFormViewModel { Id = 1 };

            // Act
            var result = await _controller.Edit(model);

            // Assert
            _mockEventService.Verify(s => s.UpdateAsync(model, _userId), Times.Once);
            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        public async Task Edit_Post_ServiceThrows_ReturnsBadRequest()
        {
            // Arrange
            var model = new EventFormViewModel { Id = 1 };
            _mockEventService.Setup(s => s.UpdateAsync(model, _userId)).ThrowsAsync(new Exception("Error"));

            // Act
            var result = await _controller.Edit(model);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public async Task Delete_Post_CallsService_ReturnsOk()
        {
            // Act
            var result = await _controller.Delete(1);

            // Assert
            _mockEventService.Verify(s => s.DeleteAsync(1, _userId), Times.Once);
            Assert.IsInstanceOf<OkResult>(result);
        }
    }
}