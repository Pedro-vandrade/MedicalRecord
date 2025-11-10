<<<<<<< HEAD
﻿using MedicalRecord.Models;
=======
>>>>>>> 527054badab8739bc4371679d389b7e0161fb781
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalRecord.Models
{
    public class PatientHistory
    {
        // Chave Primária
<<<<<<< HEAD
        // public int PatientHistoryID { get; set; }
=======
        public int PatientHistoryID { get; set; }
>>>>>>> 527054badab8739bc4371679d389b7e0161fb781

        // --- Relacionamento Chave ---
        // A chave primária (PK) também pode ser a chave estrangeira (FK), forçando 1:1.
        // Neste exemplo, vamos usar um relacionamento 1:1, onde cada Paciente tem um único PatientHistory.
<<<<<<< HEAD
        public int ID { get; set; }
=======
        public int PacienteID { get; set; }
>>>>>>> 527054badab8739bc4371679d389b7e0161fb781

        // --- Histórico Clínico ---

        [Display(Name = "Doenças Prévias/Crônicas")]
        [DataType(DataType.MultilineText)]
        public string PreviousDiseases { get; set; } // Doenças prévias (ex: diabetes, hipertensão)

        [Display(Name = "Alergias a Medicamentos")]
        [DataType(DataType.MultilineText)]
        public string DrugAllergies { get; set; } // Alergias a medicamentos

<<<<<<< HEAD

=======
>>>>>>> 527054badab8739bc4371679d389b7e0161fb781
        [Display(Name = "Histórico Cirúrgico")]
        [DataType(DataType.MultilineText)]
        public string SurgicalHistory { get; set; } // Cirurgias realizadas

        [Display(Name = "Doenças Familiares")]
        [DataType(DataType.MultilineText)]
        public string FamilyDiseases { get; set; } // Doenças prévias na família

        // --- Antropometria e Hábitos ---

<<<<<<< HEAD
        [Display(Name = "Altura (cm)")]
=======
        [Display(Name = "Altura (m)")]
>>>>>>> 527054badab8739bc4371679d389b7e0161fb781
        public double? Height { get; set; } // Altura (em metros), nullable

        [Display(Name = "Peso (kg)")]
        public double? Weight { get; set; } // Peso (em kg), nullable

        [Display(Name = "Tipo Sanguíneo")]
        [StringLength(5)]
<<<<<<< HEAD
        public string BloodType { get; set; } // USAR ENUM 

        [Display(Name = "Faz Atividade Física?")]
        public bool DoesPhysicalActivity { get; set; } // USAR ENUM 

        [Display(Name = "Frequência da Atividade")]
        [StringLength(100)]
        public string ActivityFrequency { get; set; } // Se sim, com que frequência (ex: "3x por semana") // USAR ENUM 

        // --- Propriedade de Navegação (Relacionamento 1:1) ---
        // Indica que este histórico pertence a um único paciente.
//        [ForeignKey("PacienteID")]

        public int PatientId { get ; set; }
        public Patient Patient { get; set; }
=======
        public string BloodType { get; set; }

        [Display(Name = "Faz Atividade Física?")]
        public bool DoesPhysicalActivity { get; set; }

        [Display(Name = "Frequência da Atividade")]
        [StringLength(100)]
        public string ActivityFrequency { get; set; } // Se sim, com que frequência (ex: "3x por semana")

        // --- Propriedade de Navegação (Relacionamento 1:1) ---
        // Indica que este histórico pertence a um único paciente.
        [ForeignKey("PacienteID")]
        public Paciente Paciente { get; set; }
>>>>>>> 527054badab8739bc4371679d389b7e0161fb781
    }
}