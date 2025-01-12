namespace LabManagement.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public string RoleName { get; set; } // Admin, Lab Technician, Receptionist, etc.
        public string Description { get; set; }
    }
}
