using Microsoft.AspNetCore.Mvc;

namespace Pathly.Web.Areas.Admin.Controllers
{
    public class DashboardController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
