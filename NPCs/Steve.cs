using LivingStoryEngine;
using LivingStoryEngine.Characters;

namespace LivingStoryEngine.NPCs;

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

        steve.Happiness = 55;
        steve.Energy = 90;
        steve.Stress = 20;
        steve.Curiosity = 30;
        steve.Love = 75;

        steve.UpdateLoveStatus();
        return steve;
    }
}