using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoList.Data;
using TodoList.Filters;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;

        public HomeController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tasks = _context.Tasks.ToList();
            return View(tasks);
        }

        [HttpPost]
        [TypeFilter(typeof(TimestampResourceFilter))]
        public IActionResult Create(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [TypeFilter(typeof(TimestampResourceFilter))]
        public IActionResult Update(TaskItem task)
        {
            var existingTask = _context.Tasks.Find(task.Id);
            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.IsCompleted = task.IsCompleted;
                existingTask.UpdatedAt = task.UpdatedAt;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
