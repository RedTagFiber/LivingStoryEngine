using System;
using LivingStoryEngine.Characters;
using LivingStoryEngine.Models;

namespace LivingStoryEngine.NPCs
{
    public static class NPCPrinter
    {
        public static void PrintNPC(NPC npc)

        {
            var c = npc.Character;

            Console.WriteLine("=======================================");
            Console.WriteLine($"NPC: {c.Name}");
            Console.WriteLine("---------------------------------------");

            // Core emotional stats
            Console.WriteLine($"Mood: {c.Mood}");
            Console.WriteLine($"Stress: {c.Stress}");
            Console.WriteLine($"Comfort: {c.Comfort}");
            Console.WriteLine($"Trust: {c.Trust}");
            Console.WriteLine($"Respect: {c.Respect}");
            Console.WriteLine($"Affection: {c.Affection}");
            Console.WriteLine($"Resentment: {c.Resentment}");

            // Basic identity fields your Character actually has
            Console.WriteLine($"Goal: {c.Goal}");
            Console.WriteLine($"Need: {c.Need}");
            Console.WriteLine($"Fear: {c.Fear}");
            Console.WriteLine($"Want: {c.Want}");
            Console.WriteLine($"Thought: {c.Thought}");
            Console.WriteLine($"Decision: {c.CurrentDecision}");
            Console.WriteLine($"Relationship Status: {c.RelationshipStatus}");
            Console.WriteLine($"Location: {c.Location}");
            Console.WriteLine($"Happiness: {c.Happiness}");
            Console.WriteLine($"Energy: {c.Energy}");

            // Traits
            Console.WriteLine("Traits:");
            foreach (var t in c.SpecialTraits)
                Console.WriteLine($" - {t.Name}");

            // History
            Console.WriteLine("History:");
            foreach (var h in c.History)
                Console.WriteLine($" - Age {h.Age}: {h.Category} ({h.Polarity})");

        }
    }
}