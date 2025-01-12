namespace LabManagement.Models
{
    public class TestResult
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int TestId { get; set; }
        public string Result { get; set; }
        public DateTime DateTested { get; set; }
        public string ReportTemplate { get; set; } // For customizing the report template
        public string Status { get; set; } // e.g., Pending, Completed
        public DateTime CreatedAt { get; set; }

        public Patient Patient { get; set; }
        public Test Test { get; set; }
    }
}
