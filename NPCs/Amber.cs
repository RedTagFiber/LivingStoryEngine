using LivingStoryEngine;
using LivingStoryEngine.Characters;
using LivingStoryEngine.Relationshipsystems;

namespace LivingStoryEngine.NPCs;

public static class Amber
{
    public static Character Create()
    {
        var amber = new Character();

        amber.Name = "Amber";
        amber.Location = "Home";

        amber.Goal = "Spend time with Steve";
        amber.Need = "Keep her apartment";
        amber.Fear = "Being abandoned";
        amber.Want = "Build a future with Steve";

        amber.CurrentDecision = "Thinking";

        amber.Thought = "I wonder if Steve will call today.";
        amber.JournalEntry = "Things feel normal today.";

        amber.Happiness = 60;
        amber.Energy = 100;
        amber.Stress = 10;
        amber.Curiosity = 40;
        amber.Love = 75;
        amber.LoveInterest = "Steve";
        amber.Looks = 75;
        amber.Charisma = 85;
        amber.Confidence = 80;
        amber.Maturity = 60;

        amber.LikesLooks = 60;
        amber.LikesCharisma = 90;
        amber.LikesConfidence = 85;
        amber.LikesMaturity = 40;
        amber.UpdateLoveStatus();
        amber.UpdateLoveStatus();
        amber.Relationships.Add(new Relationship
        {
            TargetName = "Steve",

            Trust = 75,
            Respect = 80,
            Affection = 85,
            Attraction = 70,
            Love = 75,

            Status = "Dating"
        });
        amber.Finances.Balance = 900;
        amber.Finances.WeeklyIncome = 700;
        amber.Finances.MonthlyBills = 1400;
        amber.Finances.Savings = 1000;
        amber.Finances.Debt = 2000;
        amber.Finances.FinancialStress = 40;

        amber.Spending.Food = 100;
        amber.Spending.Entertainment = 200;
        amber.Spending.HobbySpending = 150;
        amber.Spending.SavingsRate = .05m;


        //job
        amber.Job.Title = "Graphic Designer";
        amber.Job.WeeklyIncome = 700;
        amber.Job.StressLevel = 20;
        amber.Job.Workplace = "Design Studio";
        return amber;
    }
}
