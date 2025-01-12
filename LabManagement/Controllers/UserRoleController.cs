using LabManagement.Data;
using LabManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabManagement.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserRoleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var roles = _context.UserRoles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                _context.UserRoles.Add(userRole);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(userRole);
        }

        public IActionResult Edit(int id)
        {
            var userRole = _context.UserRoles.Find(id);
            if (userRole == null)
            {
                return NotFound();
            }
            return View(userRole);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UserRole userRole)
        {
            if (id != userRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(userRole);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(userRole);
        }

        public IActionResult Delete(int id)
        {
            var userRole = _context.UserRoles.Find(id);
            if (userRole == null)
            {
                return NotFound();
            }
            return View(userRole);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var userRole = _context.UserRoles.Find(id);
            _context.UserRoles.Remove(userRole);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }

}
