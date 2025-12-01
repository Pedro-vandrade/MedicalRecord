using System.ComponentModel.DataAnnotations;

namespace MedicalRecord.Models.Enums
{
    public enum SmokingStatus
    {
        [Display(Name = "Never Smoked")]
        NeverSmoked,
        [Display(Name = "Current Smoker")]
        CurrentSmoker,
        [Display(Name = "Former Smoker")]
        FormerSmoker,  
    }
}