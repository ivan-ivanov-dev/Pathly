using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pathly.DataModels;
using Pathly.Services.Contracts;
using Pathly.ViewModels.Tags;

namespace Pathly.Web.Controllers
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
        public async Task<IActionResult> Index(string searchString)
        {
            var userId = _userManager.GetUserId(User);
            var viewModel = await _tagService.GetUserTagsAsync(userId, searchString);

            ViewData["CurrentFilter"] = searchString;

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new TagViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TagViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
                return BadRequest(error);
            }

            var userId = _userManager.GetUserId(User);
            await _tagService.CreateTagAsync(model.Name, userId);
            return Ok();
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
