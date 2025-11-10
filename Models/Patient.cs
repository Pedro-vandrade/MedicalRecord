using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MedicalRecord.Models
{
    public class Patient
    {
        // Chave Primária
        public int ID { get; set; }

        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DateBirth { get; set; }

        public Boolean Gender { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(14)]
        public string CPF { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string Email { get; set; }

        [StringLength(200)]
        [Display(Name = "Endereço Completo")]
        public string Address { get; set; }



        // Propriedades de Navegação (para os relacionamentos)
        public ICollection<PatientEntry> PatientEntry { get; set; } = new List<PatientEntry>();
        public ICollection<Test> Test { get; set; } = new List<Test>();
        public ICollection<Treatment> Treatment { get; set; } = new List<Treatment>();
    }
}