using System; // Required for the [Flags] attribute

namespace MedicalRecord.Models.Enums
{
    [Flags] // 👈 STEP 1: Add the [Flags] attribute
    public enum SurgicalProcedures
    {
        // STEP 2: Assign power-of-two values (Binary flags)
        None = 0,
        Appendectomy = 1,
        Tonsillectomy = 2,
        Cholecystectomy = 4, // Gallbladder removal
        HerniaRepair = 8,
        KneeReplacement = 16,
        HipReplacement = 32,
        CSection = 64,
        Other = 128
    }
}