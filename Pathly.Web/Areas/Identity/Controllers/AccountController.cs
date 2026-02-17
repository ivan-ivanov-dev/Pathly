using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pathly.Data;
using Pathly.DataModels;
using Pathly.ViewModels.Authentication;
using System.Threading.Tasks;

namespace Pathly.Web.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAsync(SignInViewModel signInViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(signInViewModel);
            }
            var user = new ApplicationUser
            {
                UserName = signInViewModel.UserName,
                Email = signInViewModel.Email
            };
            var result = await _userManager.CreateAsync(user, signInViewModel.Password);
            if(result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(signInViewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var user = await _userManager.FindByEmailAsync(loginViewModel.Email.Trim());

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    user.UserName,
                    loginViewModel.Password,
                    loginViewModel.RememberMe,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }

            ModelState.AddModelError("", "Incorrect email or password");

            return View(loginViewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account", new { area = "Identity" });
        }
        /*The only action and controller in the entire project which talk directly to the db context*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAccount()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Account", new { area = "Identity" });

            var userId = user.Id;

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var userGoalIds = await _context.Goals
                    .Where(g => g.UserId == userId)
                    .Select(g => g.Id)
                    .ToListAsync();

                var userRoadmapIds = await _context.Roadmaps
                    .Where(r => userGoalIds.Contains(r.GoalId))
                    .Select(r => r.Id)
                    .ToListAsync();

                var userTags = _context.Tags.Where(t => t.UserId == userId);
                _context.Tags.RemoveRange(userTags);

                var actions = _context.Actions.Where(a => userRoadmapIds.Contains(a.RoadmapId));
                _context.Actions.RemoveRange(actions);

                var roadmaps = _context.Roadmaps.Where(r => userRoadmapIds.Contains(r.Id));
                _context.Roadmaps.RemoveRange(roadmaps);

                var tasks = _context.Tasks.Where(t => t.UserId == userId);
                _context.Tasks.RemoveRange(tasks);

                var goals = _context.Goals.Where(g => g.UserId == userId);
                _context.Goals.RemoveRange(goals);

                await _context.SaveChangesAsync();

                var result = await _userManager.DeleteAsync(user);
                if (!result.Succeeded) throw new Exception("Identity user deletion failed");

                await transaction.CommitAsync();

                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return RedirectToAction("Index", "Dashboard", new { area = "" });
            }
        }
    }
}
