using LabManagement.Data;
using LabManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LabManagement.Controllers
{
    public class TestResultController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestResultController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var results = _context.TestResults.Include(r => r.Patient).Include(r => r.Test).ToList();
            return View(results);
        }

        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName");
            ViewData["TestId"] = new SelectList(_context.Tests, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TestResult testResult)
        {
            if (ModelState.IsValid)
            {
                testResult.CreatedAt = DateTime.Now;
                _context.TestResults.Add(testResult);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(testResult);
        }

        public IActionResult Edit(int id)
        {
            var testResult = _context.TestResults.Find(id);
            if (testResult == null)
            {
                return NotFound();
            }
            return View(testResult);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TestResult testResult)
        {
            if (id != testResult.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(testResult);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(testResult);
        }

        public IActionResult Delete(int id)
        {
            var testResult = _context.TestResults.Find(id);
            if (testResult == null)
            {
                return NotFound();
            }
            return View(testResult);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var testResult = _context.TestResults.Find(id);
            _context.TestResults.Remove(testResult);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }

}
