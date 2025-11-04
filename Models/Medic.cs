using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MedicalRecord.Models
{
    public class Medic
    {
        // Chave Primária
        public int MedicID { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O CRM é obrigatório.")]
        [StringLength(20)]
        public string CRM { get; set; } // Conselho Regional de Medicina

        [StringLength(50)]
        public string Specialty { get; set; }

        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string Email { get; set; }

        // Propriedades de Navegação
        public ICollection<PatientEntry> PatientEntry { get; set; } = new List<PatientEntry>();
    }
}