using LivingStoryEngine;
using LivingStoryEngine.Characters;

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

        amber.UpdateLoveStatus();
        return amber;
    }
}
