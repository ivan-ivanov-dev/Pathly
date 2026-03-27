using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pathly.DataModels;
using Pathly.ViewModels.Settings;

namespace Pathly.Web.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public SettingsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Account");

            var model = new SettingsViewModel
            {
                Username = user.UserName!,
                Email = user.Email!
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(SettingsViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound();

            user.UserName = model.Username;
            user.Email = model.Email;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                await _signInManager.RefreshSignInAsync(user);
                TempData["SuccessMessage"] = "Profile updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors) ModelState.AddModelError("", error.Description);
            return View(nameof(Index), model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(SettingsViewModel model)
        {
            if (string.IsNullOrEmpty(model.CurrentPassword) || string.IsNullOrEmpty(model.NewPassword))
            {
                ModelState.AddModelError("", "Password fields are required.");
                return View("Index", model);
            }

            var user = await _userManager.GetUserAsync (User);
            if (user == null) return NotFound();

            var result = await _userManager.ChangePasswordAsync(user,model.CurrentPassword,model.NewPassword);
            if (result.Succeeded)
            {
                await _signInManager.RefreshSignInAsync(user);
                TempData["SuccessMessage"] = "Password changed successfully!";
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors) 
            { 
                ModelState.AddModelError("", error.Description); 
            
            }
            return View("Index", model);
        }
    }
}
