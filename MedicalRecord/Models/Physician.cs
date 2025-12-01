using System.ComponentModel.DataAnnotations;

namespace MedicalRecord.Models
{
    public class Physician
    {
        public int Id { get; set; }

        [Required]
        public string FullDocName { get; set; }

        // Adicione esta propriedade para corrigir o erro CS1061
        [Required]
        public string PhysicianSpecialty { get; set; }

        [Required]
        [MinLength(4), MaxLength(6)]
        public string CRM { get; set; }
        
        [RegularExpression(@"^(\(\d{2}\)\d\.\d{4}-\d{4})$", ErrorMessage = "Phone Number format must be : (XX) X.XXXX-XXXX.")]
        [Display(Name = "Phone Number")]
        [Required]
        public string PhoneNumber { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<Patient> Patients { get; set; } = new List<Patient>();

        public int TotalAppointments(DateTime initial, DateTime final)
        {
            return Appointments.Count(apt => apt.AppointmentDate >= initial && apt.AppointmentDate <= final);
        }

    }
}
