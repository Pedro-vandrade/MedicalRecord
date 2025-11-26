using System.ComponentModel.DataAnnotations;

namespace MedicalRecord.Models
{
    public class MedicalRecs
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        public int PhysicianId { get; set; }

        public Physician Physician { get; set; }

        public DateTime RecordDate { get; set; } = DateTime.Now;

        [DataType(DataType.MultilineText)]
        public string Symptom { get; set; }

        [DataType(DataType.MultilineText)]
        public string Treatment { get; set; }

        [DataType(DataType.MultilineText)]
        public string DoctorNotes { get; set; }

        public ICollection<Prescription> Prescription { get; set; } = new List<Prescription>();
    }
}
