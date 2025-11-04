using System.ComponentModel.DataAnnotations;

namespace MedicalRecord.Models
{
    public class Treatment
    {
        // Chave Primária
        public int TreatmentId { get; set; }

        [Required(ErrorMessage = "A descrição do tratamento/medicação é obrigatória.")]
        [StringLength(250)]
        [Display(Name = "Descrição (Medicação/Procedimento)")]
        public string Description { get; set; }

        [StringLength(100)]
        public string Dosage { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Início")]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Final (Opcional)")]
        public DateTime? DataEnd { get; set; } // O ponto de interrogação indica que é opcional (nullable)

        // Chave Estrangeira
        [Display(Name = "Consulta Relacionada")]
        public int EntryID { get; set; }

        // Propriedade de Navegação
        public PatientEntry PatientEntry { get; set; }
    }
}