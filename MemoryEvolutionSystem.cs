using LivingStoryEngine.Characters;
using LivingStoryEngine.MemorySystem;
using System;

namespace LivingStoryEngine
{
    public static class MemoryEvolutionSystem
    {
        public static void AddMemory(Character c, string summary, string polarity, int importance)
        {
            var memory = new Memory
            {
                Summary = summary,
                Polarity = polarity,
                Importance = importance,
                EmotionalWeight = importance,
                DateCreated = DateTime.Now,
                Clarity = 100
            };

            c.Memories.Add(memory);
        }

        // ⭐ NEW METHOD — prevents your crash
        public static void DailyMemoryUpdate(Character c)
        {
            foreach (var memory in c.Memories.Items)
            {
                // Memories fade over time
                memory.Clarity -= 1;

                // Emotional weight softens
                memory.EmotionalWeight -= 1;

                // Keep values in range
                if (memory.Clarity < 0) memory.Clarity = 0;
                if (memory.EmotionalWeight < 0) memory.EmotionalWeight = 0;
            }
        }
    }
}
