using LivingStoryEngine;
using LivingStoryEngine.Characters;

namespace LivingStoryEngine.Relationshipsystems
{
    namespace NPCs
    {
        public static class Steve
        {
            public static Character Create()
            {
                var steve = new Character();

                steve.Name = "Steve";
                steve.Location = "Work";

                steve.Goal = "Provide for his future";
                steve.Need = "Keep his job";
                steve.Fear = "Failure";
                steve.Want = "Spend more time with Amber";

                steve.CurrentDecision = "Thinking";

                steve.Thought = "I should probably call Amber later.";
                steve.JournalEntry = "Work has been busy.";
                steve.Looks = 70;
                steve.Charisma = 55;
                steve.Confidence = 65;
                steve.Maturity = 90;
                steve.Happiness = 55;
                steve.Energy = 90;
                steve.Stress = 20;
                steve.Curiosity = 30;
                steve.Love = 75;
                steve.LoveInterest = "Amber";
                steve.UpdateLoveStatus();


                steve.Relationships.Add(new Relationship
                {
                    TargetName = "Amber",

                    Trust = 85,
                    Respect = 80,
                    Affection = 85,
                    Attraction = 70,
                    Love = 80,

                    Status = "Dating"
                });

                ///finances
                steve.Finances.Balance = 400;
                steve.Finances.WeeklyIncome = 1200;
                steve.Finances.MonthlyBills = 1800;
                steve.Finances.Savings = 250;
                steve.Finances.Debt = 5000;
                steve.Finances.FinancialStress = 75;

                steve.Spending.Food = 100;
                steve.Spending.Entertainment = 50;
                steve.Spending.HobbySpending = 25;
                steve.Spending.SavingsRate = .30m;

                //job information
                steve.Job.Title = "Engineer";
                steve.Job.WeeklyIncome = 1200;
                steve.Job.StressLevel = 40;
                steve.Job.Workplace = "Tech Corp";

                return steve;
            }
        }
    }
}