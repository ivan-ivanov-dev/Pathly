using Microsoft.AspNetCore.Mvc;
using Pathly.Services.Contracts;

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
            return Json(new { success = false, message = "Users couldn't get deleted" });
        }
    }
}
