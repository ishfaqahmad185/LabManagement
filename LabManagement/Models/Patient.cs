using System.ComponentModel.DataAnnotations;

namespace LabManagement.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
