using LabManagement.Data;
using LabManagement.Models;

namespace LabManagement.Services
{
    public class ActivityLogService
    {
        private readonly ApplicationDbContext _context;

        public ActivityLogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void LogActivity(string user, string action)
        {
            var log = new ActivityLog
            {
                User = user,
                Action = action,
                Timestamp = DateTime.Now
            };

            _context.ActivityLogs.Add(log);
            _context.SaveChanges();
        }
    }
}
