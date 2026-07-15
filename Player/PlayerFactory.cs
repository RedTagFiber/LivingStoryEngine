using LivingStoryEngine.Characters;

namespace LivingStoryEngine.Player;

public static class PlayerFactory
{
    public static Character CreatePlayer(
        string name,
        string sex)
    {
        var player = new Character();

        player.Name = name;
        player.Sex = sex;

        player.Location = "Home";

        player.Goal = "Build a meaningful life";
        player.Need = "Financial stability";
        player.Fear = "Missing opportunities";
        player.Want = "Find happiness";

        player.CurrentDecision = "Thinking";

        player.Thought = "A new chapter begins.";
        player.JournalEntry = "Today is the start of something new.";

        player.Happiness = 50;
        player.Energy = 100;
        player.Stress = 0;
        player.Curiosity = 50;

        player.Finances.Balance = 1000;
        player.Finances.WeeklyIncome = 0;
        player.Finances.MonthlyBills = 0;
        player.Finances.Savings = 0;
        player.Finances.Debt = 0;

        return player;
    }
}