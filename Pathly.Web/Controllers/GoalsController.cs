using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pathly.DataModels;
using Pathly.Services.Contracts;
using Pathly.ViewModels.Goals;

namespace Pathly.Web.Controllers
{
    [Authorize]
    public class GoalsController : Controller
    {
        private readonly IGoalService _goalService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public GoalsController(IGoalService goalService, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _goalService = goalService;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(GoalQueryModel queryModel)
        {
            var userId = _userManager.GetUserId(User);
            var goals = await _goalService.GetAllAsync(queryModel ,userId);

            return View(goals);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new GoalCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(GoalCreateViewModel model)
        {
            var today = DateTime.UtcNow.Date;
            if (string.IsNullOrWhiteSpace(model.Title))
            {
                ModelState.AddModelError("Title", "Title is required.");
            }

            if (model.TargetDate.HasValue && model.TargetDate.Value < today)
            {
                ModelState.AddModelError("TargetDate", "Target date cannot be in the past.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = _userManager.GetUserId(User);

            try
            {
                await _goalService.CreateAsync(model, userId);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while creating the task: " + ex.Message);
                return View(model);
            }

        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            var userId = _userManager.GetUserId(User);
            var goal = await _goalService.GetDetailsAsync(id, userId);
            if (goal == null)
            {
                return NotFound();
            }
            
            var model = _mapper.Map<GoalEditViewModel>(goal);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(GoalEditViewModel model)
        {
            var today = DateTime.UtcNow.Date;
            if (string.IsNullOrWhiteSpace(model.Title))
            {
                ModelState.AddModelError("Title", "Title is required.");
            }
            if (model.TargetDate.HasValue && model.TargetDate.Value < today)
            {
                ModelState.AddModelError("TargetDate", "Target date cannot be in the past.");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userId = _userManager.GetUserId(User);
            try
            {
                await _goalService.UpdateAsync(model.Id, model, userId);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while creating the task: " + ex.Message);
                return View(model);
            }

        }

        [HttpGet]
        public async Task<IActionResult> DetailsAsync(int id)
        {
            // Validate id to ensure it's a valid id
            if (id <= 0)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
            var goal = await _goalService.GetDetailsAsync(id, userId);
            if (goal == null)
            {
                return NotFound();
            }
            return View(goal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var userId = _userManager.GetUserId(User);
            await _goalService.DeleteAsync(id, userId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var userId = _userManager.GetUserId(User);
            await _goalService.ToggleGoalStatusAsync(id,userId);
            return RedirectToAction(nameof(Index));
        }
    }
}
