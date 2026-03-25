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
        public async Task<IActionResult> Users()
        {
            var users = await _adminService.GetAllUsersAsync();
            return View(users);
        }
    }
}
