using System;

namespace MedicalRecord.Models.Enums
{
    [Flags] // 👈 STEP 1: Add the [Flags] attribute
    public enum DiseasesConditions
    {
        // STEP 2: Assign power-of-two values (Binary flags)
        None = 0,
        Hypertension = 1, // High blood pressure
        Type2DiabetesMellitus = 2,
        Type1DiabetesMellitus = 4,
        Asthma = 8,
        ChronicObstructivePulmonaryDisease = 16, // COPD
        GastroesophagealRefluxDisease = 32, // GERD
        CoronaryArteryDisease = 64, // CAD, heart disease
        Hyperlipidemia = 128, // High cholesterol
        Hypothyroidism = 256,
        Migraine = 512,
        AnxietyDisorder = 1024,
        MajorDepressiveDisorder = 2048,
        Osteoarthritis = 4096,
        RheumatoidArthritis = 8192,
        Cancer = 16384,
        KidneyDisease = 32768,
        Other = 65536
    }
}