using LabManagement.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabManagement.Controllers
{
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index2()
        {
            var roles = _context.Roles.ToList();
            return View(roles);
        }

        // Display a form to assign roles to users
        public IActionResult AssignRole()
        {
            ViewBag.Users = _context.Users.ToList();
            ViewBag.Roles = _context.Roles.ToList();
            return View();
        }

        public IActionResult AssignRole2(int userId, int roleId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                user.RoleId = roleId;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Display all roles and their assigned users
        public IActionResult Index()
        {
            var roles = _context.Roles.Include(r => r.Users).ToList();
            return View(roles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AssignRole(int userId, int roleId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                user.RoleId = roleId;
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}


