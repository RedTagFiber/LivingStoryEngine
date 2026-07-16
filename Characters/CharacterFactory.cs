using LivingStoryEngine.Managers;
using LivingStoryEngine.Models;

namespace LivingStoryEngine.Characters;

internal static class CharacterFactory
{
    public static Character CreateEve()
    {
        var eve = new Character();

        eve.Name = "Eve";
        eve.Location = "Home";
        eve.Energy = 100;

        eve.Goal = "Spend time with Ryan";
        eve.Need = "Keep her job";
        eve.Fear = "Losing people she cares about";
        eve.Want = "Go on a date with Ryan";

        eve.SpecialTraits.Add("HopelessRomantic");
        eve.SpecialTraits.Add("HeartOnSleeve");
        eve.SpecialTraits.Add("FaithfulPartner");

        ApplySpecialTraits(eve);

        Console.WriteLine(
            $"Eve Modifiers Count = {eve.TraitModifiers.Count}"
        );

        return eve;
    }

    private static void ApplySpecialTraits(Character character)
    {
        Console.WriteLine("Applying Traits...");

        foreach (var traitName in character.SpecialTraits)
        {
            Console.WriteLine($"Found Trait: {traitName}");

            var trait = SpecialTraitManager.GetTrait(traitName);

            if (trait == null)
            {
                Console.WriteLine("Trait NOT FOUND!");
                continue;
            }

            Console.WriteLine($"Loaded Trait: {trait.Name}");

            foreach (var effect in trait.Effects)
            {
                Console.WriteLine(
                    $"Adding {effect.Key} = {effect.Value}"
                );

                if (!character.TraitModifiers.ContainsKey(effect.Key))
                {
                    character.TraitModifiers[effect.Key] = 0;
                }

                character.TraitModifiers[effect.Key] += effect.Value;
            }
        }

        Console.WriteLine(
            $"Total Modifiers: {character.TraitModifiers.Count}"
        );
    }
}