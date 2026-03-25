using Microsoft.AspNetCore.Mvc;
using Pathly.Services.Contracts;
using Pathly.Services.Implementation;

namespace Pathly.Web.Areas.Admin.Controllers
{
    public class DashboardController : AdminBaseController
    {
        private readonly IAdminService _adminService;
        public DashboardController(IAdminService adminService)
        {
         _adminService = adminService;   
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var users = await _adminService.GetAllUsersAsync();
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var success = await _adminService.DeleteUserAsync(userId);

            if (success)
            {
                return Json(new { success = true, message = "User deleted successfully!" });
            }
            return Json(new { success = false, message = "User couldn't get deleted" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeRole(string userId, string newRole)
        {
            var success = await _adminService.ChangeUserRoleAsync(userId, newRole);

            if (success)
            {
                return Json(new { success = true, message = $"Role updated to {newRole}!" });
            }

            return Json(new { success = false, message = "User couldn't get their role updated" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleLockout(string userId)
        {
            var success = await _adminService.ToggleUserLockoutAsync(userId);

            if (success)
            {
                return Json(new { success = true, message = "User status updated successfully!" });
            }

            return Json(new { success = false, message = "Error updating lockout status." });
        }
    }
}
