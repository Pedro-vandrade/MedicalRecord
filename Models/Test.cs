using System.ComponentModel.DataAnnotations;

namespace MedicalRecord.Models
{
    public class Test
    {
        // Chave Primária
        public int TestID { get; set; }

        [Required(ErrorMessage = "O nome do exame é obrigatório.")]
        [StringLength(100)]
        [Display(Name = "Nome do Exame")]
        public string TestName { get; set; }

        [Required(ErrorMessage = "A data de realização é obrigatória.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Realização")]
        public DateTime DateTest { get; set; }

        [DataType(DataType.MultilineText)]
        public string Result { get; set; } // O resultado em texto

        // Chave Estrangeira (Nullable)
        [Display(Name = "Consulta Relacionada (Opcional)")]
        public int? EntryId { get; set; }

        // Propriedade de Navegação
        public PatienEntry PatienEntry { get; set; }
    }
}