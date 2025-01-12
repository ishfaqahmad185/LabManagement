using LabManagement.Data;
using LabManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LabManagement.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvoiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var invoices = _context.Invoices.Include(i => i.Patient).ToList();
            return View(invoices);
        }

        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Invoice invoice, bool isPaid)
        {
            if (ModelState.IsValid)
            {
                invoice.DateIssued = DateTime.Now;
                invoice.UpdateStatus(isPaid);
                _context.Invoices.Add(invoice);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(invoice);
        }

        public IActionResult Edit(int id)
        {
            var invoice = _context.Invoices.Find(id);
            if (invoice == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName", invoice.PatientId);
            return View(invoice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Invoice invoice, bool isPaid)
        {
            if (id != invoice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                invoice.UpdateStatus(isPaid);
                _context.Update(invoice);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(invoice);
        }

        public IActionResult Delete(int id)
        {
            var invoice = _context.Invoices.Find(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return View(invoice);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var invoice = _context.Invoices.Find(id);
            _context.Invoices.Remove(invoice);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }

}
