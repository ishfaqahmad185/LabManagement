namespace LabManagement.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateIssued { get; set; }
        public string Status { get; set; } // e.g., Paid, Due, Overdue
        public string PaymentMethod { get; set; } // Cash, EasyPaisa, etc.
        public decimal Discount { get; set; }

        public Patient Patient { get; set; }

        public decimal FinalAmount => Amount - Discount; // Read-only, computed property

        // Helper to set the status
        public void UpdateStatus(bool isPaid)
        {
            if (isPaid)
                Status = "Paid";
            else
                Status = "Due"; // Logic can be extended for overdue detection
        }
    }
}
