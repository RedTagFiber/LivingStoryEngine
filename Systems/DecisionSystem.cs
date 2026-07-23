using LivingStoryEngine.Characters;

namespace LivingStoryEngine.Systems
{
    /// <summary>
    /// Offline decision engine.
    /// Uses mood, stress, energy, traits, and memories
    /// to generate thoughts and simple behavior choices.
    /// </summary>
    public static class DecisionSystem
    {
        public static void UpdateThoughtsAndBehavior(Character c)
        {
            float mood = c.Mood.Value / 100f;
            float stress = c.Stress.Value / 100f;
            float energy = c.Energy / 100f;

            bool isLoyal = c.SpecialTraits.Exists(t => t.Name == "Loyal");
            bool isCurious = c.SpecialTraits.Exists(t => t.Name == "Curious");

            // Thought selection
            if (stress > 0.7f && energy < 0.4f)
            {
                c.Thought = "Feeling overwhelmed and drained.";
            }
            else if (mood < 0.3f)
            {
                c.Thought = "Struggling to stay positive.";
            }
            else if (isCurious)
            {
                c.Thought = "Wondering what else life could be.";
            }
            else if (isLoyal)
            {
                c.Thought = "Thinking about the people they care about.";
            }
            else
            {
                c.Thought = "Reflecting on their day.";
            }

            // Simple behavior label
            if (stress > 0.8f)
                c.CurrentDecision = "Withdraw";
            else if (mood > 0.6f && energy > 0.5f)
                c.CurrentDecision = "ReachOut";
            else if (energy < 0.3f)
                c.CurrentDecision = "Rest";
            else
                c.CurrentDecision = "Routine";
        }
    }
}
