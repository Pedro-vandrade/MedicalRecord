using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace MedicalRecord.Models
{
    public class Prescription
    {
        // Primary Key
        public int Id { get; set; }

        [Required]
        public int MedicalRecordId { get; set; } 

        [Required]
        public string MedicationName { get; set; }
        
        [Required]
        public string Dosage { get; set; }
        
        [Required]
        public string Frequency { get; set; } 
        
        [Required]
        public DateTime StartDate { get; set; }
        
        //  CHANGE 1: Made EndDate nullable for long-term treatment.
        public DateTime? EndDate { get; set; } 
        
        public int QuantityDispensed { get; set; }
        
        // CHANGE 2: Added annotation for multi-line text input (textarea in HTML).
        [DataType(DataType.MultilineText)]
        [Display(Name = "Patient Instructions")]
        public string Instructions { get; set; }

        // NAVIGATION PROPERTY
        public MedicalRecs MedicalRecs { get; set; }
    }
}
