using LabManagement.Data;
using LabManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabManagement.Controllers
{
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tests = _context.Tests.ToList();
            return View(tests);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Test test)
        {
            if (ModelState.IsValid)
            {
                test.CreatedAt = DateTime.Now;
                _context.Tests.Add(test);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(test);
        }

        public IActionResult Edit(int id)
        {
            var test = _context.Tests.Find(id);
            if (test == null)
            {
                return NotFound();
            }
            return View(test);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Test test)
        {
            if (id != test.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(test);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(test);
        }

        public IActionResult Delete(int id)
        {
            var test = _context.Tests.Find(id);
            if (test == null)
            {
                return NotFound();
            }
            return View(test);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var test = _context.Tests.Find(id);
            _context.Tests.Remove(test);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
