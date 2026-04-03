using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pathly.DataModels;
using Pathly.Services.Contracts;
using Pathly.ViewModels.TasksViewModels;

namespace Pathly.Web.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly ITagService _tagService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public TasksController(ITaskService taskService, ITagService tagService,IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _taskService = taskService;
            _tagService = tagService;
            _mapper = mapper;
            _userManager = userManager;
        }

        /*List Tasks*/

        public async Task<IActionResult> Index(TaskQueryModel queryModel)
        {
            var userId = _userManager.GetUserId(User);

            var model = await _taskService.GetAllTasksAsync(queryModel, userId);

            return View(model);
        }

        /*Create Tasks*/

        [HttpGet]
        public async Task<IActionResult> CreateAsync(int? actionId)
        {
            var userId = _userManager.GetUserId(User);
            var tags = await _tagService.GetUserTagsAsync(userId);

            var model = new TaskCreateViewModel { ActionId = actionId };
            model.AvailableTags = await GetAvailableTagsSelectList(userId);

            return PartialView("CreatePartialView",model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(TaskCreateViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Title))
            {
                ModelState.AddModelError("Title", "The Title field is required.");
            }
            
            if (model.DueDate.HasValue && model.DueDate.Value < DateTime.Now.Date)
            {
                ModelState.AddModelError("DueDate", "Due date cannot be in the past.");
            }

            if(model.SelectedTagIds.Count > 4)
            {
                ModelState.AddModelError("SelectedTagIds", "You can select up to 4 tags.");
            }

            var userId = _userManager.GetUserId(User);

            if (!ModelState.IsValid)
            {
                var tags = await _tagService.GetUserTagsAsync(userId);

                model.AvailableTags = await GetAvailableTagsSelectList(userId);

                return PartialView("CreatePartialView", model);
            }

            try
            {
                await _taskService.CreateAsync(model,userId);
                return Ok();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while creating the task: " + ex.Message);
                return PartialView("CreatePartialView", model);
            }

        }

        /*Edit Tasks*/

        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            var userId = _userManager.GetUserId(User);
            var taskDetails = await _taskService.GetDetailsAsync(id,userId);

            if (taskDetails == null)
            {
                return NotFound();
            }

            var tags = await _tagService.GetUserTagsAsync(userId);
            var selectedTagIds = await _taskService.GetTaskTagIdsAsync(id, userId);

            var editModel = _mapper.Map<TaskEditViewModel>(taskDetails);

            editModel.SelectedTagIds = await _taskService.GetTaskTagIdsAsync(id, userId);
            editModel.AvailableTags = await GetAvailableTagsSelectList(userId);


            return PartialView("EditPartialView", editModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(TaskEditViewModel model)
        {
            var id = model.Id;
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrWhiteSpace(model.Title))
            {
                ModelState.AddModelError("Title", "The Title field is required.");
            }

            if (model.DueDate.HasValue && model.DueDate.Value < DateTime.Now)
            {
                ModelState.AddModelError("DueDate", "Due date cannot be in the past.");
            }

            if (model.SelectedTagIds.Count > 4)
            {
                ModelState.AddModelError("SelectedTagIds", "You can select up to 4 tags.");
            }

            if (!ModelState.IsValid)
            {
                var tags = await _tagService.GetUserTagsAsync(userId);

                model.AvailableTags = await GetAvailableTagsSelectList(userId);

                return PartialView("EditPartialView", model);
            }

            await _taskService.UpdateWithTagsAsync(id, model, userId);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Ok(); 
            }

            return RedirectToAction("Index", "Tasks");
        }

        /*Delete Tasks*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var userId = _userManager.GetUserId(User);
            var success = await _taskService.DeleteAsync(id, userId);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")//Check if the request is an AJAX request
            {
                return Json(new
                {
                    success = success,
                    message = success ? "Task deleted successfully." : "You do not have permission to delete this task."
                });
            }

            return RedirectToAction(nameof(Index));
        }

        /*View task details Tasks*/

        [HttpGet]
        public async Task<IActionResult> DetailsAsync(int id)
        {
            var userId = _userManager.GetUserId(User);

            var model = await _taskService.GetDetailsAsync(id, userId);

            if(model == null)
            {
                return NotFound();
            }
            return PartialView("DetailsPartialView", model);
        }

        /*Mark Task Status*/

        [HttpPost]
        public async Task<IActionResult> MarkTaskStatus(int id)
        {
            var userId = _userManager.GetUserId(User);

            await _taskService.MarkTaskStatusAsync(id, userId);
            return RedirectToAction(nameof(Index));
        }

        /*Update Task Position*/
        [HttpPost]
        public async Task<IActionResult> UpdatePosition([FromBody] TaskUpdatePositionViewModel model)//The [FromBody] attribute tells ASP.NET Core to look for the data in the request body rather than the query string.
        {
            if (model == null)
            {
                return BadRequest();
            }
            try
            {
                var userId = _userManager.GetUserId(User);
                await _taskService.UpdateTaskPositionAsync(model.Id, userId, model.NewStatus, model.NewPosition);

                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /*Update Task Priority*/

        [HttpPost]
        public async Task<IActionResult> UpdatePriority(int id, TaskPriority priority)
        {
            var userId = _userManager.GetUserId(User);

            await _taskService.UpdatePriorityAsync(id,priority, userId);
            return RedirectToAction(nameof(Index));
        }

        // A helper method to get available tags for the current user and convert them to SelectListItem for dropdowns
        private async Task<IEnumerable<SelectListItem>> GetAvailableTagsSelectList(string userId)
        {
            var tags = await _tagService.GetUserTagsAsync(userId);
            return tags.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name
            }).ToList();
        }
    }
}
