using LivingStoryEngine;
using LivingStoryEngine.Characters;

namespace LivingStoryEngine.NPCs;

public static class Jake
{
    public static Character Create()
    {
        var jake = new Character();

        jake.Name = "Jake";
        jake.Location = "Garage";

        jake.Goal = "Build a successful business";
        jake.Need = "Keep customers happy";
        jake.Fear = "Letting people down";
        jake.Want = "Find someone to share life with";

        jake.CurrentDecision = "Thinking";

        jake.Thought = "Another busy day at the shop.";
        jake.JournalEntry = "Work has been steady lately.";

        jake.Happiness = 65;
        jake.Energy = 95;
        jake.Stress = 15;
        jake.Curiosity = 35;

        jake.Traits.Add(new Trait
        {
            Name = "Reliable",
            Description = "People can count on him.",
            Strength = 90
        });

        jake.Traits.Add(new Trait
        {
            Name = "Protective",
            Description = "Looks out for people he cares about.",
            Strength = 85
        });

        jake.Traits.Add(new Trait
        {
            Name = "Blunt",
            Description = "Tells the truth even when it hurts.",
            Strength = 70
        });

        jake.Traits.Add(new Trait
        {
            Name = "Patient",
            Description = "Rarely rushes into decisions.",
            Strength = 80
        });

        return jake;
    }
}