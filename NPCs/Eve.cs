using LivingStoryEngine;
using LivingStoryEngine.Characters;

namespace LivingStoryEngine.NPCs;

public static class Eve
{
    public static Character Create()
    {
        var eve = new Character();

        eve.Name = "Eve";
        eve.Location = "Home";

        eve.Goal = "Spend time with Ryan";
        eve.Need = "Keep her job";
        eve.Fear = "Losing people she cares about";
        eve.Want = "Go on a date with Ryan";

        eve.CurrentDecision = "Thinking";

        eve.Thought = "I wonder what today will bring.";
        eve.JournalEntry = "Today feels like a normal day.";

        eve.Happiness = 50;
        eve.Energy = 100;
        eve.Stress = 0;
        eve.Curiosity = 50;

        eve.Traits.Add(new Trait
        {
            Name = "Curious",
            Description = "Wants answers and investigates things.",
            Strength = 90
        });

        eve.Traits.Add(new Trait
        {
            Name = "Supportive",
            Description = "Likes helping people she cares about.",
            Strength = 80
        });

        eve.Traits.Add(new Trait
        {
            Name = "Overthinks",
            Description = "Can become trapped in her own thoughts.",
            Strength = 75
        });

        return eve;
    }
}