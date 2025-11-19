namespace MedicalRecord.Models
{
    public class PatientHistory
    {
        // Primary Key (Can also be the Foreign Key to Patient in a one-to-one relationship)
        public int PatientHistoryId { get; set; }

        // Foreign Key (Links this history record directly to the Patient)
        public int PatientId { get; set; }

        // Medical History
        public string KnownConditionsAndDiseases { get; set; } // e.g., "Hypertension, Type 2 Diabetes"
        public string SurgicalHistory { get; set; } // e.g., "Appendectomy (2010), Knee Replacement (2022)"

        // Lifestyle Factors
        public string ExerciseActivity { get; set; } // e.g., "Running, Weightlifting"
        public string ExerciseFrequency { get; set; } // e.g., "3 times per week"
        public bool Smoker { get; set; } // True/False flag
        public string AlcoholConsumption { get; set; } // e.g., "Socially, 1-2 drinks per week"

        // Navigation Property
        public Patient Patient { get; set; }
    }
}
