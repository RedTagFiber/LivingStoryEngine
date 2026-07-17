using LivingStoryEngine.Managers;
using LivingStoryEngine.Models;
using LivingStoryEngine.Systems;

namespace LivingStoryEngine.Characters;

/// <summary>
/// Creates and initializes characters.
/// Handles:
/// - History Generation
/// - History Effects
/// - History Trait Grants
/// - Special Trait Modifiers
/// </summary>
internal static class CharacterFactory
{
    // =====================================================
    // CREATE EVE
    // =====================================================

    public static Character CreateEve()
    {
        var eve = new Character();

        // =====================================================
        // BASIC INFO
        // =====================================================

        eve.Name = "Eve";
        eve.Location = "Home";
        eve.Energy = 100;
        eve.Age = 25;

        // =====================================================
        // GOALS
        // =====================================================

        eve.Goal = "Spend time with Ryan";
        eve.Need = "Keep her job";
        eve.Fear = "Losing people she cares about";
        eve.Want = "Go on a date with Ryan";

        // =====================================================
        // LIFE HISTORY
        // =====================================================

        eve.History = HistoryGenerator.Generate(eve.Age);

        // =====================================================
        // MANUAL PERSONALITY TRAITS
        // =====================================================

        eve.SpecialTraits.Add("HopelessRomantic");
        eve.SpecialTraits.Add("HeartOnSleeve");
        eve.SpecialTraits.Add("FaithfulPartner");

        // =====================================================
        // APPLY HISTORY
        // =====================================================

        ApplyHistoryEffects(eve);
        ApplyHistoryTraits(eve);

        // =====================================================
        // APPLY SPECIAL TRAIT MODIFIERS
        // =====================================================

        ApplySpecialTraits(eve);

        // =====================================================
        // DEBUG
        // =====================================================

        Console.WriteLine(
            $"Total Modifiers Loaded: {eve.TraitModifiers.Count}"
        );

        return eve;
    }

    // =====================================================
    // APPLY HISTORY EFFECTS
    // =====================================================

    private static void ApplyHistoryEffects(
        Character character)
    {
        foreach (var record in character.History)
        {
            foreach (var effect in record.Effects)
            {
                switch (effect.Key)
                {
                    case "Trust":

                        character.Trust += effect.Value;

                        break;

                    case "Confidence":

                        character.Confidence += effect.Value;

                        break;

                    case "Happiness":

                        character.Happiness += effect.Value;

                        break;

                    case "Love":

                        character.Love += effect.Value;

                        break;

                    case "Curiosity":

                        character.Curiosity += effect.Value;

                        break;
                }
            }
        }
    }

    // =====================================================
    // APPLY HISTORY GRANTED TRAITS
    // =====================================================

    private static void ApplyHistoryTraits(
        Character character)
    {
        foreach (var record in character.History)
        {
            foreach (var trait in record.GrantedTraits)
            {
                if (!character.SpecialTraits.Contains(trait))
                {
                    character.SpecialTraits.Add(trait);

                    Console.WriteLine(
                        $"History Added Trait: {trait}"
                    );
                }
            }
        }
    }

    // =====================================================
    // APPLY SPECIAL TRAIT EFFECTS
    // =====================================================

    private static void ApplySpecialTraits(
        Character character)
    {
        Console.WriteLine("Applying Traits...");

        foreach (var traitName in character.SpecialTraits)
        {
            var trait =
                SpecialTraitManager.GetTrait(traitName);

            if (trait == null)
            {
                Console.WriteLine(
                    $"Trait Not Found: {traitName}"
                );

                continue;
            }

            Console.WriteLine(
                $"Loaded Trait: {trait.Name}"
            );

            foreach (var effect in trait.Effects)
            {
                if (!character.TraitModifiers
                    .ContainsKey(effect.Key))
                {
                    character.TraitModifiers[effect.Key] = 0;
                }

                character.TraitModifiers[effect.Key]
                    += effect.Value;

                Console.WriteLine(
                    $"{effect.Key} +{effect.Value}"
                );
            }
        }

        Console.WriteLine(
            $"Total Modifiers: {character.TraitModifiers.Count}"
        );
    }
}