using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MedicalRecord.Models.Enums;
using MedicalRecord.Models; // Include if you need to reference the Patient model

namespace MedicalRecord.ViewModels
{
    public class PatientHistoryViewModel
    {
        public Patient Patient { get; set; }
        public int Id { get; set; }
        public int PatientId { get; set; }

        [Display(Name = "Known Conditions")]
        public List<string> KnownConditionsAndDiseases { get; set; } = new List<string>();

        [Display(Name = "Surgical Procedures")]
        public List<string> SurgicalHistory { get; set; } = new List<string>();

        // --- 3. Single-Select/Dropdown Fields ---

        [Required]
        [Display(Name = "Blood Type")]
        public BloodType BloodType { get; set; }

        [Display(Name = "Primary Exercise")]
        public List<string> ExerciseActivity { get; set; } = new List<string>();

      //  public Exercise ExerciseActivity { get; set; }

        [Display(Name = "Exercise Frequency")]
        public ExFrequency ExerciseFrequency { get; set; }

        [Display(Name = "Smoker")]
        public SmokingStatus Smoker { get; set; }

        [Display(Name = "Alcohol Consumption")]
        public AlcConsumption AlcoholConsumption { get; set; }
    }
}