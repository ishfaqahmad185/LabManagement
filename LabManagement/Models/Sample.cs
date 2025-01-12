namespace LabManagement.Models
{
    public class Sample
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int TestId { get; set; }
        public string CollectionStatus { get; set; } // e.g., Collected, Not Collected
        public DateTime CollectedAt { get; set; }
        public string Notes { get; set; }
        public int CollectedById { get; set; } // Technician who collected the sample

        public Patient Patient { get; set; }
        public Test Test { get; set; }
        public User CollectedBy { get; set; } // Technician user

    }
}
