namespace MedicalRecord.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public string MedicationName { get; set; }
        public string Dosage { get; set; } // e.g., "10 mg", "500 mcg"
        public string Frequency { get; set; } // e.g., "Twice Daily (BID)", "Every 4 Hours"
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } // The date the patient should stop taking the medication
        public int QuantityDispensed { get; set; } // Number of units (pills, mL, etc.) dispensed
        public string Instructions { get; set; }
    }
}
