using System.ComponentModel.DataAnnotations;

namespace MedicalRecord.Models
{
    public class Test
    {
        // Chave Primária
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do exame é obrigatório.")]
        [StringLength(100)]
        [Display(Name = "Nome do Exame")] // // USAR ENUM 
        public string TestName { get; set; }

        [Required(ErrorMessage = "A data de realização é obrigatória.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Realização")]
        public DateTime DateTest { get; set; }

        [DataType(DataType.MultilineText)]
        public string Result { get; set; } // O resultado em texto

        public string Sampling { get; set; } // Enum ?

        // Chave Estrangeira (Nullable)
        [Display(Name = "Consulta Relacionada (Opcional)")]
        public int? EntryId { get; set; }

        // Propriedade de Navegação
        public PatientEntry Entry { get; set; }
    }
}