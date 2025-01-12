using LabManagement.Data;
using LabManagement.Models;
using LabManagement.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LabManagement.Controllers
{
    public class SamplesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SamplesController(ApplicationDbContext context)
        {
            _context = context;
        }

        ////public IActionResult Index2()
        ////{
        ////    var samples = _context.Samples.Include(s => s.Patient).Include(s => s.Test).ToList();
        ////    return View(samples);
        ////}

        ////public IActionResult Create2()
        ////{
        ////    ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName");
        ////    ViewData["TestId"] = new SelectList(_context.Tests, "Id", "Name");
        ////    return View();
        ////}

        ////[HttpPost]
        ////[ValidateAntiForgeryToken]
        ////public IActionResult Create2(Sample sample)
        ////{
        ////    if (ModelState.IsValid)
        ////    {
        ////        _context.Samples.Add(sample);
        ////        _context.SaveChanges();
        ////        return RedirectToAction(nameof(Index));
        ////    }
        ////    return View(sample);
        ////}

        public IActionResult Index()
        {
            var samples = _context.Samples.Include(s => s.Patient).Include(s => s.Test).Include(s => s.CollectedBy).ToList();
            return View(samples);
        }

        // Create action to add new samples
        public IActionResult Create()
        {
            //var patients = _context.Patients.ToList();
            //var tests = _context.Tests.ToList();
            //var users = _context.Users.ToList();

            //if (!patients.Any() || !tests.Any() || !users.Any())
            //{
            //    // Handle case where no data is available
            //    ModelState.AddModelError("", "Data for patients, tests, or users is missing.");
            //}
            //ViewData["PatientId"] = new SelectList(patients, "Id", "FullName");
            //ViewData["TestId"] = new SelectList(tests, "Id", "Name");
            //ViewData["CollectedById"] = new SelectList(users.Where(u => u.Role.Name == "Lab Technician"), "Id", "FullName");

            var viewModel = new SampleViewModel
            {
                Patients = new SelectList(_context.Patients, "Id", "FullName"),
                Tests = new SelectList(_context.Tests, "Id", "Name"),
                Users = new SelectList(_context.Users, "Id", "FullName")
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sample sample)
        {
            if (ModelState.IsValid)
            {
                _context.Samples.Add(sample);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName");
            //ViewData["TestId"] = new SelectList(_context.Tests, "Id", "Name");
            //ViewData["CollectedById"] = new SelectList(_context.Users.Where(u => u.Role.Name == "Lab Technician"), "Id", "FullName", sample.CollectedById);
            var viewModel = new SampleViewModel
            {
                Patients = new SelectList(_context.Patients, "Id", "FullName"),
                Tests = new SelectList(_context.Tests, "Id", "Name"),
                Users = new SelectList(_context.Users, "Id", "FullName"),
                Sample = sample
            };

            return View(viewModel);
        }

        // Edit action to update collection status and date
        public IActionResult Edit(int id)
        {
            var sample = _context.Samples.Find(id);
            if (sample == null)
            {
                return NotFound();
            }

            //ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName", sample.PatientId);
            //ViewData["TestId"] = new SelectList(_context.Tests, "Id", "Name", sample.TestId);
            //ViewData["CollectedById"] = new SelectList(_context.Users.Where(u => u.Role.Name == "Lab Technician"), "Id", "FullName", sample.CollectedById);
            var viewModel = new SampleViewModel
            {
                Patients = new SelectList(_context.Patients, "Id", "FullName"),
                Tests = new SelectList(_context.Tests, "Id", "Name"),
                Users = new SelectList(_context.Users, "Id", "FullName"),
                Sample = sample
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Sample sample)
        {
            if (id != sample.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sample);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SampleExists(sample.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var viewModel = new SampleViewModel
            {
                Patients = new SelectList(_context.Patients, "Id", "FullName"),
                Tests = new SelectList(_context.Tests, "Id", "Name"),
                Users = new SelectList(_context.Users, "Id", "FullName"),
                Sample = sample
            };
            return View(viewModel);
        }

        // Delete action to remove a sample
        public IActionResult Delete(int id)
        {
            var sample = _context.Samples.Include(s => s.Patient).Include(s => s.Test).FirstOrDefault(s => s.Id == id);
            if (sample == null)
            {
                return NotFound();
            }

            return View(sample);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var sample = _context.Samples.Find(id);
            _context.Samples.Remove(sample);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool SampleExists(int id)
        {
            return _context.Samples.Any(e => e.Id == id);
        }
    }
}