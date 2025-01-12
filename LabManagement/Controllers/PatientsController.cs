using LabManagement.Data;
using LabManagement.Models;
using LabManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabManagement.Controllers
{
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ActivityLogService _activityLogService;

        public PatientsController(ApplicationDbContext context, ActivityLogService activityLogService)
        {
            _context = context;
            _activityLogService = activityLogService;
        }

        // GET: Patients
        public async Task<IActionResult> Index(string search)
        {
            var patients = from p in _context.Patients select p;

            if (!string.IsNullOrEmpty(search))
            {
                patients = patients.Where(p => p.Name.Contains(search));
            }

            return View(await patients.ToListAsync());
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var patient = await _context.Patients.FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null) return NotFound();

            return View(patient);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Gender,DateOfBirth,Phone,Address")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient);
                await _context.SaveChangesAsync();

                _activityLogService.LogActivity("Admin", $"Added patient {patient.Name}");
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var patient = await _context.Patients.FindAsync(id);
            if (patient == null) return NotFound();

            return View(patient);
        }

        // POST: Patients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gender,DateOfBirth,Phone,Address")] Patient patient)
        {
            if (id != patient.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {

                    //var existingPatient = _context.Patients.Find(id);
                    //if (existingPatient != null)
                    //{
                    //    existingPatient.Name = patient.Name;
                    //    existingPatient.CreatedAt = updatedPatient.LastName;
                    //    existingPatient.DateOfBirth = updatedPatient.DateOfBirth;
                    //    existingPatient.Gender = updatedPatient.Gender;
                    //    existingPatient.ContactNumber = updatedPatient.ContactNumber;
                    //    existingPatient.Email = updatedPatient.Email;
                    //    existingPatient.Address = updatedPatient.Address;

                    //    _context.SaveChanges();

                    //    _activityLogService.LogActivity("Admin", $"Updated patient {existingPatient.Name}");
                    //}



                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                    _activityLogService.LogActivity("Admin", $"Updated patient {patient.Name}");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.Id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var patient = await _context.Patients.FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null) return NotFound();

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.Id == id);
        }
    }
}
