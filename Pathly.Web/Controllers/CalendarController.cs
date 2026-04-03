using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pathly.Services.Contracts;
using Pathly.ViewModels.Event;
using System.Security.Claims;

namespace Pathly.Controllers
{
    [Authorize]
    public class CalendarController : Controller
    {
        private readonly IEventService _eventService;

        public CalendarController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var events = await _eventService.GetAllForCalendarAsync(userId!);
            return Json(events);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await _eventService.PrepareFormModelAsync(userId!);
            return PartialView("_CreateEventPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _eventService.CreateAsync(model, userId!);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await _eventService.GetForEditAsync(id, userId!);

            if (model == null) return NotFound();

            return PartialView("_EditEventPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EventFormViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _eventService.UpdateAsync(model, userId!);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _eventService.DeleteAsync(id, userId!);
            return Ok();
        }
    }
}