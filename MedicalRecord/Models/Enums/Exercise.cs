using System; // Required for the [Flags] attribute

namespace MedicalRecord.Models.Enums
{
    [Flags] // 👈 STEP 1: Add the [Flags] attribute
    public enum Exercise // select mais de uma opção
    {
        // STEP 2: Assign power-of-two values (Binary flags)
        Sedentary = 0, // Little to no activity (using 0 for single choice or None)
        Walking = 1,
        Running = 2,
        Swimming = 4,
        Cycling = 8,
        WeightTraining = 16,
        YogaPilates = 32,
        TeamSports = 64, // e.g., Soccer, Basketball
        CardioMachine = 128, // e.g., Elliptical, Stair Climber
        Other = 256
    }
}