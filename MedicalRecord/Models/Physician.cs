using System.ComponentModel.DataAnnotations;

namespace MedicalRecord.Models
{
    public class Physician
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        // Adicione esta propriedade para corrigir o erro CS1061
        public string PhysicianSpecialty { get; set; }

        [Required]
        public string CRM { get; set; }
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
