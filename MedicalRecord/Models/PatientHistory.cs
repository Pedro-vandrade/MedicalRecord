using MedicalRecord.Models.Enums;

namespace MedicalRecord.Models
{
    public class PatientHistory
    {
        // Primary Key (Can also be the Foreign Key to Patient in a one-to-one relationship)
        public int Id { get; set; }

        // Foreign Key (Links this history record directly to the Patient)
        public int PatientId { get; set; }

        // Medical History
        [Display(Name = "Known Conditions")]
        public DiseasesConditions KnownConditionsAndDiseases { get; set; } // e.g., "Hypertension, Type 2 Diabetes"
       
        [Display(Name = "Surgical Procedures")]
        public SurgicalProcedures SurgicalHistory { get; set; } // e.g., "Appendectomy (2010), Knee Replacement (2022)"

        // Lifestyle Factors
        [Display(Name = "Primary Exercise")]
        public Exercise ExerciseActivity { get; set; } // e.g., "Running, Weightlifting"
        [Display(Name = "Exercise Frequency")]
        public ExFrequency ExerciseFrequency { get; set; } // e.g., "3 times per week"
        [Display(Name = "Smoker")]
        public bool Smoker { get; set; } // True/False flag
        [Display(Name = "Alcohol Consumption")]
        public string AlcoholConsumption { get; set; } // e.g., "Socially, 1-2 drinks per week"

        // Navigation Property
        public Patient Patient { get; set; }
    }
}
