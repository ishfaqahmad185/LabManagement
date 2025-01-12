namespace LabManagement.Models
{
    public class ActivityLog
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
