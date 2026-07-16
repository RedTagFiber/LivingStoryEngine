using LivingStoryEngine.Characters;

namespace LivingStoryEngine.Systems;

public static class DecisionEngine
{
    public static string DecideRelationshipAction(Character character)
    {
        Console.WriteLine(
            $"DEBUG Romanticism = {character.GetModifier("Romanticism")}"
        );

        if (character.GetModifier("Romanticism") > 0.30)
        {
            return "Look for a romantic interaction";
        }

        return "Focus on personal goals";
    }
}