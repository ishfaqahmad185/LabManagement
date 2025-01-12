namespace LabManagement.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; } // e.g., Blood Tests, Imaging, Pathology
        public string Parameters { get; set; } // Comma-separated list of test parameters
        public DateTime CreatedAt { get; set; }
    }
}
