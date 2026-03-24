using Microsoft.AspNetCore.Mvc;

namespace Pathly.Web.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("Errors/Error404")]
        public IActionResult Error404()
        {
            return View();
        }

        [Route("Errors/Error500")]
        public IActionResult Error500()
        {
            return View();
        }
    }
}
