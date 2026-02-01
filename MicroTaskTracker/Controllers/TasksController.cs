using Microsoft.AspNetCore.Mvc;
using MicroTaskTracker.Data;
using MicroTaskTracker.Models.DBModels;
using MicroTaskTracker.Models.ViewModels;

namespace MicroTaskTracker.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var tasks = new List<TaskViewModel>();
            foreach (var task in _context.Tasks)
            {
                var model = new TaskViewModel
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    IsCompleted = task.IsCompleted,
                    CreatedOn = DateTime.Now,
                    DueDate = task.DueDate,
                    Priority = task.Priority
                };
                tasks.Add(model);
            }
            return View(tasks);
        }

        /*Create Tasks*/

        [HttpGet]
        public IActionResult Create()
        {
            var model = new TaskCreateViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(TaskCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            /*Implement authentication*/

            var task = new TaskItem
            {
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                CreatedOn = DateTime.Now,
                IsCompleted = false,
                Priority = model.Priority
            };
            _context.Tasks.Add(task);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        /*Edit Tasks*/

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            /*Implement authentication*/

            var model = new TaskEditViewModel
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id, TaskEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            /*Implement authentication*/

            task.Title = model.Title;
            task.Description = model.Description;
            task.DueDate = model.DueDate;

            _context.Tasks.Update(task);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        /*Delete Tasks*/

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            /*Implement authentication*/

            var model = new TaskDeleteViewModel
            {
                Id = task.Id,
                Title = task.Title
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(int id, TaskDeleteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            /*Implement authentication*/

            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
