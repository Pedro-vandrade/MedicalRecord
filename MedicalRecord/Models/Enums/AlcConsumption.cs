namespace MedicalRecord.Models.Enums
{
    public enum AlcConsumption
    {
        Never, // Abstinence
        FormerDrinker, // Stopped drinking
        Rarely, // Less than once a month or only special occasions
        LightModerate, // Up to 3 drinks per week (Low Risk)
        SocialWeekly, // 4-7 drinks per week (Typical social drinker range)
        HeavyWeekly, // 8-15 drinks per week (Increased Risk)
        HighRiskDaily, // 16+ drinks per week or >4 per day (High Risk)
        Unknown
    }
}
