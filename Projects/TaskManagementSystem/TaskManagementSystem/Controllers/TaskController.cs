using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public  TaskController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var tasks = _context.Tasks.ToList();
            return View(tasks);
        }

        public IActionResult Create(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        public IActionResult Edit(int id)
        {
            var task = _context.Tasks.Find(id);
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(TaskModel task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
