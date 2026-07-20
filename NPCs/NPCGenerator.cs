using LivingStoryEngine.Characters;
using LivingStoryEngine.Models;
using LivingStoryEngine.Systems;
using System;

namespace LivingStoryEngine.NPCs
{
    public static class NPCGenerator
    {
        private static readonly Random rng = new();

        public static NPC GenerateNPC()
        {
            var c = new Character();

            // Identity
            c.Name = NameGenerator.GenerateFullName();
            c.Location = "Home";
            c.RelationshipStatus = "Single";

            // Emotional Stats
            c.Mood.Value = rng.Next(0, 100);
            c.Stress.Value = rng.Next(0, 100);
            c.Comfort.Value = rng.Next(0, 100);
            c.Trust.Value = rng.Next(0, 100);
            c.Respect.Value = rng.Next(0, 100);
            c.Affection.Value = rng.Next(0, 100);
            c.Resentment = rng.Next(0, 100);
            c.Happiness = rng.Next(0, 100);
            c.Energy = rng.Next(0, 100);

            // Cognitive State
            c.Thought = "Thinking about their day";
            c.CurrentDecision = "None";
            c.Want = "Connection";
            c.Goal = "Improve their life";
            c.Need = "Stability";
            c.Fear = "Failure";

            // History
            c.History.Add(new HistoryRecord { Age = 7, Category = "Childhood", Event = "Moved", Description = "Family relocated." });
            c.History.Add(new HistoryRecord { Age = 16, Category = "Teen", Event = "Won Award", Description = "Won a school competition." });
            c.History.Add(new HistoryRecord { Age = 22, Category = "Adult", Event = "New Job", Description = "Started a new career." });

            // Traits
            c.SpecialTraits.Add(new SpecialTrait { Name = "Loyal" });
            c.SpecialTraits.Add(new SpecialTrait { Name = "Curious" });

            // Memories
            MemoryEvolutionSystem.AddMemory(c, "Moved to a new town", "Neutral", 40);
            MemoryEvolutionSystem.AddMemory(c, "Lost a close friend", "Negative", 80);
            MemoryEvolutionSystem.AddMemory(c, "Won a school award", "Positive", 60);

            // Assign job
            c.Job = JobDatabase.GetRandomJob();

            // Return NPC
            return new NPC
            {
                Character = c
            };
        }

        // ⭐ THIS MUST BE OUTSIDE GenerateNPC()
        public static void ApplyJobEffects(Character c, int hour)
        {
            var job = c.Job;

            if (job == null || job.Shifts == null)
                return;

            foreach (var shift in job.Shifts)
            {
                bool working = IsWorkingHour(shift, hour);

                if (working)
                {
                    c.Stress.Value += job.BaseStress / 10;
                    c.Energy -= job.PhysicalFatigue / 5;
                    c.Mood.Value -= job.MentalFatigue / 10;
                }
            }

            // Clamp
            c.Stress.Value = Math.Clamp(c.Stress.Value, 0, 100);
            c.Energy = Math.Clamp(c.Energy, 0, 100);
            c.Mood.Value = Math.Clamp(c.Mood.Value, 0, 100);
        }

        private static bool IsWorkingHour(JobShift shift, int hour)
        {
            // Normal shift (start < end)
            if (shift.StartHour < shift.EndHour)
                return hour >= shift.StartHour && hour < shift.EndHour;

            // Overnight shift (start > end)
            return hour >= shift.StartHour || hour < shift.EndHour;
        }
    }
}
