using Microsoft.AspNetCore.Mvc.Rendering;

namespace LabManagement.Models.ViewModels
{
    public class SampleViewModel
    {
        public int PatientId { get; set; }
        public int TestId { get; set; }
        public int CollectedById { get; set; }

        public SelectList Patients { get; set; }
        public SelectList Tests { get; set; }
        public SelectList Users { get; set; }
        public Sample Sample { get; set; }
    }
}
