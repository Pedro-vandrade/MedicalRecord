using MedicalRecord.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedicalRecord.Models
{
    public class Patient
    {
        public int Id { get; set; }

        // Core Demographics - All Required
        [Required]
        [Display(Name = "Full Name")]
        [MinLength(2), MaxLength(50)]
        public string FullName { get; set; }
        
        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public GenderIdentity Gender { get; set; }

        [Required]
        [Display(Name = "Marital Status")]
        public MaritalStatus MaritalStatus { get; set; }

        // Contact Information - All Required
        
        [Required]
        [RegularExpression(@"^(\(\d{2}\) \d\.\d{4}-\d{4})$", ErrorMessage = "Phone Number format must be : (XX) X.XXXX-XXXX.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [Display(
        public string PostalCode { get; set; }

        [Required]
        public DateTime DateRegistered { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}
