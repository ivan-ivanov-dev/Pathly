using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Pathly.DataModels;
using Pathly.GCommon;
using Pathly.Services;
using Pathly.Tests.Common;
using Pathly.ViewModels.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pathly.Tests.Services
{
    [TestFixture]
    public class EventServiceTests : ServiceTestsBase
    {
        private EventService _eventService;
        private readonly string _userId = "test-user-123";

        [SetUp]
        public void SetUp()
        {
            BaseSetup();
            _eventService = new EventService(_context, _mapper);
        }

        [TearDown]
        public void TearDown()
        {
            BaseTearDown();
        }

        [Test]
        public async Task GetAllForCalendarAsync_Success_ReturnsMappedViewModels()
        {
            // Arrange
            await _context.Events.AddAsync(new Event { Title = "Event 1", UserId = _userId, Start = DateTime.UtcNow, End = DateTime.UtcNow.AddHours(1) });
            await _context.SaveChangesAsync();

            // Act
            var result = await _eventService.GetAllForCalendarAsync(_userId);

            // Assert
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().Title, Is.EqualTo("Event 1"));
        }

        [Test]
        public void GetAllForCalendarAsync_NoEvents_ThrowsInvalidOperationException()
        {
            // Act & Assert
            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () => await _eventService.GetAllForCalendarAsync(_userId));
            Assert.That(ex.Message, Is.EqualTo(ErrorMessages.NoEventsFound));
        }

        [Test]
        public async Task PrepareFormModelAsync_FiltersDoneTasks_ReturnsActiveItems()
        {
            // Arrange
            await _context.Tasks.AddAsync(new TaskItem { Title = "Active", UserId = _userId, Status = DataModels.TaskStatus.Todo });
            await _context.Tasks.AddAsync(new TaskItem { Title = "Done", UserId = _userId, Status = DataModels.TaskStatus.Done });
            await _context.Goals.AddAsync(new Goal { Title = "My Goal", UserId = _userId });
            await _context.SaveChangesAsync();

            // Act
            var result = await _eventService.PrepareFormModelAsync(_userId);

            // Assert
            Assert.That(result.AvailableTasks.Count, Is.EqualTo(1));
            Assert.That(result.AvailableTasks.First().Text, Is.EqualTo("Active"));
            Assert.That(result.AvailableGoals.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task CreateAsync_ValidModel_SavesToDatabase()
        {
            // Arrange
            var model = new EventFormViewModel { Title = "New", Start = DateTime.UtcNow.AddDays(1), End = DateTime.UtcNow.AddDays(1).AddHours(2) };

            // Act
            await _eventService.CreateAsync(model, _userId);

            // Assert
            var dbEntry = await _context.Events.FirstOrDefaultAsync(e => e.Title == "New");
            Assert.That(dbEntry, Is.Not.Null);
            Assert.That(dbEntry.UserId, Is.EqualTo(_userId));
        }

        [Test]
        public void CreateAsync_EndBeforeStart_ThrowsArgumentException()
        {
            // Arrange
            var model = new EventFormViewModel { Start = DateTime.UtcNow.AddDays(2), End = DateTime.UtcNow.AddDays(1) };

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _eventService.CreateAsync(model, _userId));
            Assert.That(ex.Message, Is.EqualTo(ErrorMessages.EndDateMustBeAfterStartDate));
        }

        [Test]
        public void CreateAsync_StartInPast_ThrowsArgumentException()
        {
            // Arrange
            var model = new EventFormViewModel { Start = DateTime.UtcNow.AddMinutes(-10), End = DateTime.UtcNow.AddHours(1) };

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _eventService.CreateAsync(model, _userId));
            Assert.That(ex.Message, Is.EqualTo(ErrorMessages.StartDateCannotBeInThePast));
        }

        [Test]
        public void CreateAsync_InvalidTaskId_ThrowsArgumentException()
        {
            // Arrange
            var model = new EventFormViewModel { Start = DateTime.UtcNow.AddDays(1), End = DateTime.UtcNow.AddDays(2), TaskId = 99 };

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _eventService.CreateAsync(model, _userId));
            Assert.That(ex.Message, Is.EqualTo(ErrorMessages.SelectedTaskDoesNotExist));
        }

        [Test]
        public void CreateAsync_InvalidGoalId_ThrowsArgumentException()
        {
            // Arrange
            var model = new EventFormViewModel { Start = DateTime.UtcNow.AddDays(1), End = DateTime.UtcNow.AddDays(2), GoalId = 99 };

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _eventService.CreateAsync(model, _userId));
            Assert.That(ex.Message, Is.EqualTo(ErrorMessages.SelectedGoalDoesNotExist));
        }

        [Test]
        public async Task GetForEditAsync_ValidOwner_ReturnsMappedForm()
        {
            // Arrange
            var ev = new Event { Id = 10, Title = "Edit Me", UserId = _userId };
            await _context.Events.AddAsync(ev);
            await _context.SaveChangesAsync();

            // Act
            var result = await _eventService.GetForEditAsync(10, _userId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Title, Is.EqualTo("Edit Me"));
        }

        [Test]
        public void GetForEditAsync_WrongUser_ThrowsUnauthorizedAccessException()
        {
            // Arrange
            var ev = new Event { Id = 10, UserId = "real-owner", Title = "Required Title" };
            _context.Events.Add(ev);
            _context.SaveChanges();

            // Act & Assert
            Assert.ThrowsAsync<UnauthorizedAccessException>(async () => await _eventService.GetForEditAsync(10, "wrong-user"));
        }

        [Test]
        public async Task UpdateAsync_ValidUpdate_PersistsChanges()
        {
            // Arrange
            var ev = new Event { Id = 5, Title = "Old", UserId = _userId, Start = DateTime.UtcNow.AddDays(1), End = DateTime.UtcNow.AddDays(1).AddHours(1) };
            await _context.Events.AddAsync(ev);
            await _context.SaveChangesAsync();
            var model = new EventFormViewModel { Id = 5, Title = "Updated", Start = DateTime.UtcNow.AddDays(2), End = DateTime.UtcNow.AddDays(2).AddHours(1) };

            // Act
            await _eventService.UpdateAsync(model, _userId);

            // Assert
            var updated = await _context.Events.FindAsync(5);
            Assert.That(updated.Title, Is.EqualTo("Updated"));
        }

        [Test]
        public void UpdateAsync_MissingEvent_ThrowsUnauthorizedAccessException()
        {
            // Arrange
            var model = new EventFormViewModel { Id = 500 };

            // Act & Assert
            Assert.ThrowsAsync<UnauthorizedAccessException>(async () => await _eventService.UpdateAsync(model, _userId));
        }

        [Test]
        public async Task DeleteAsync_ValidOwner_RemovesFromDb()
        {
            // Arrange
            await _context.Events.AddAsync(new Event { Id = 1, UserId = _userId, Title = "Required Title" });
            await _context.SaveChangesAsync();

            // Act
            await _eventService.DeleteAsync(1, _userId);

            // Assert
            var exists = await _context.Events.AnyAsync(e => e.Id == 1);
            Assert.That(exists, Is.False);
        }

        [Test]
        public void DeleteAsync_AccessDenied_ThrowsUnauthorizedAccessException()
        {
            // Arrange
            _context.Events.Add(new Event { Id = 1, UserId = "owner", Title = "Required Title" });
            _context.SaveChanges();

            // Act & Assert
            Assert.ThrowsAsync<UnauthorizedAccessException>(async () => await _eventService.DeleteAsync(1, "hacker"));
        }
    }
}
