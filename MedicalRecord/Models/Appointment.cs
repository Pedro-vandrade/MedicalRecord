using MedicalRecord.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedicalRecord.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Display(Name = "Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Display(Name = "Physician")]
        public int PhysicianId { get; set; }
        public Physician Physician { get; set; }

        [Required]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }
        [Required]
        [Display(Name = "Reason for Visit")]
        public string ReasonForVisit { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
       


    } 
}
