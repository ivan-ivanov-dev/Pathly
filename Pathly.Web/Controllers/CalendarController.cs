using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pathly.DataModels;
using Pathly.Services.Contracts;
using Pathly.ViewModels.Event;
using System.Security.Claims;

namespace Pathly.Controllers
{
    [Authorize]
    public class CalendarController : Controller
    {
        private readonly IEventService _eventService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CalendarController(IEventService eventService, UserManager<ApplicationUser> userManager)
        {
            _eventService = eventService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
                return Json(new List<EventCalendarViewModel>());

            try
            {
                var events = await _eventService.GetAllForCalendarAsync(userId);
                return Json(events);
            }
            catch (InvalidOperationException)
            {
                return Json(new List<EventCalendarViewModel>());
            }
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
            var userId = _userManager.GetUserId(User);

            try
            {
                var model = await _eventService.GetForEditAsync(id, userId);

                if (model == null)
                {
                    return NotFound("Event not found or access denied.");
                }

                return PartialView("_EditEventPartial", model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
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