using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MedicalRecord.Models;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MedicalRecord.Models
{
    public class PatientEntry
    {
        // Chave Primária
        public int EntryID { get; set; }

        [Required]
        [Display(Name = "Data/Hora do Atendimento")]
        public DateTime DateTimeEntry { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "O motivo da consulta é obrigatório.")]
        [StringLength(250)]
        [Display(Name = "Motivo da Consulta")]
        public string ReasonAppointment { get; set; }

        [Required(ErrorMessage = "A anamnese é essencial para o prontuário.")]
        [DataType(DataType.MultilineText)]
        public string PatientInterview { get; set; }

        // (FKs)
        [Display(Name = "Paciente")]
        public int PatientID { get; set; }
        [Display(Name = "Médico Responsável")]
        public int MedicID { get; set; }

        // Propriedades de Navegação (Relacionamentos)
        public Patient Patient { get; set; }
        public Medic Medic { get; set; }

        public ICollection<Test> RequiredExams { get; set; } = new List<Test>();
        public ICollection<Treatment> PrescribedTreatment { get; set; } = new List<Treatment>();
    }
}

// CONSULTA/ AGENDAMENTO - MEDICO - PACIENTE - PACIENTE HISTORICO - TRATAMENTO/RECEITA - PAGAMENTO - EXAMES

// CLINICA 

