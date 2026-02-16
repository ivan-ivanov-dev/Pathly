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
        public async Task<IActionResult> Create(TagViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(new { errors });
            }

            try
            {
                var userId = _userManager.GetUserId(User);
                await _tagService.CreateTagAsync(model.Name, userId);
                return Ok(new { success = true });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { errors = new[] { ex.Message } });
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
