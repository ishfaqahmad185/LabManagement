using LabManagement.Data;
using LabManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabManagement.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult RevenueReport()
        {
            var report = new RevenueReport
            {
                TotalRevenue = _context.Invoices.Sum(i => i.Amount),
                TotalInvoices = _context.Invoices.Count(),
                AverageInvoiceAmount = _context.Invoices.Average(i => i.Amount)
            };

            return View(report);
        }

        public IActionResult TestPopularityReport()
        {
            var report = _context.TestResults
                .GroupBy(r => r.TestId)
                .Select(g => new
                {
                    TestName = g.FirstOrDefault().Test.Name,
                    TotalTests = g.Count()
                })
                .OrderByDescending(t => t.TotalTests)
                .ToList();

            return View(report);
        }

        public IActionResult StaffProductivityReport()
        {
            var report = _context.TestResults
                .GroupBy(r => r.PatientId)
                .Select(g => new
                {
                    StaffName = g.FirstOrDefault().Patient.Name, // Assumed staff is linked to patient
                    TestsPerformed = g.Count()
                })
                .OrderByDescending(t => t.TestsPerformed)
                .ToList();

            return View(report);
        }
    }

}
