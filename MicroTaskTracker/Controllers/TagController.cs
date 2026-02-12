using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MicroTaskTracker.Models.DBModels;
using MicroTaskTracker.Models.ViewModels.Tags;
using MicroTaskTracker.Services.Interfaces;

namespace MicroTaskTracker.Controllers
{
    [Authorize]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        private readonly UserManager<ApplicationUser> _userManager;
        public TagController(ITagService tagService, UserManager<ApplicationUser> userManager)
        {
            _tagService = tagService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User); 
            var tags = await _tagService.GetUserTagsAsync(userId);
            return View(tags);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new TagViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(TagViewModel model)
        {
            if (String.IsNullOrWhiteSpace(model.Name))
            {
                ModelState.AddModelError("Name", "Tag name is required.");
                return View(model);
            }

            var userId = _userManager.GetUserId(User);

            try
            {
                await _tagService.CreateTagAsync(model.Name, userId);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = _userManager.GetUserId(User);
            await _tagService.DeleteTagAsync(id, userId);
            return RedirectToAction(nameof(Index));
        }
    }
}
