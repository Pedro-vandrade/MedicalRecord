using MedicalRecord.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedicalRecord.Models
{
    public class Patient
    {
        public int Id { get; set; }

        // Core Demographics - All Required
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public GenderIdentity Gender { get; set; }

        [Required]
        public MaritalStatus MaritalStatus { get; set; }

        

        // Contact Information - All Required
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }

        [Required]
        public DateTime DateRegistered { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}
