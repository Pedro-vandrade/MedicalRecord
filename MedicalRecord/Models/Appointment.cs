namespace MedicalRecord.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int PhysicianId { get; set; }
        public Physician Physician { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public string ReasonForVisit { get; set; }
        [Required]
        public string Notes { get; set; }

        

    }
}
