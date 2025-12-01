using MedicalRecord.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedicalRecord.Models
{
    public class PatientHistory
    {
        // Primary Key (Can also be the Foreign Key to Patient in a one-to-one relationship)
        public int Id { get; set; }

        // Foreign Key (Links this history record directly to the Patient)
        public int PatientId { get; set; }

        [Required]
        [Display(Name = "Blood Type")]
        public BloodType BloodType { get; set; }

        // Medical History
        [Display(Name = "Known Conditions")]
        public DiseasesConditions KnownConditionsAndDiseases { get; set; } 
        [Display(Name = "Surgical Procedures")]
        public SurgicalProcedures SurgicalHistory { get; set; } 

        // Lifestyle Factors
        [Display(Name = "Primary Exercise")]
        public Exercise ExerciseActivity { get; set; } 
        [Display(Name = "Exercise Frequency")]
        public ExFrequency ExerciseFrequency { get; set; } 
        [Display(Name = "Smoker")]
        public SmokingStatus Smoker { get; set; } 
        [Display(Name = "Alcohol Consumption")]
        public AlcConsumption AlcoholConsumption { get; set; } 

        // Navigation Property
        public Patient Patient { get; set; }
    }
}
