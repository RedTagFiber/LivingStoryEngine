using LivingStoryEngine.Characters;
using LivingStoryEngine.NPCs;
using LivingStoryEngine.Systems;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        // Load jobs from JSON
        JobDatabase.LoadJobs();

        // Generate 1 NPC for testing
        NPC npc = NPCGenerator.GenerateNPC();
        var c = npc.Character;

        Console.WriteLine("===== BEGINNING STATS =====");
        PrintStats(c);

        Console.WriteLine($"Assigned Job: {c.Job?.Title ?? "None"}");
        if (c.Job != null)
        {
            foreach (var shift in c.Job.Shifts)
                Console.WriteLine($"Shift: {shift.StartHour}:00 - {shift.EndHour}:00");
        }

        Console.WriteLine("\n===== SIMULATING 48 HOURS (2 DAYS) =====");

        for (int hour = 0; hour < 48; hour++)
        {
            int day = hour / 24;
            int hourOfDay = hour % 24;

            Console.WriteLine($"\nDay {day}, Hour {hourOfDay}");

            // Sleep check
            if (SleepSystem.ShouldSleep(c, hourOfDay))
            {
                SleepSystem.ApplySleep(c);
                Console.WriteLine("NPC is sleeping...");
            }
            else
            {
                // Job effects
                NPCGenerator.ApplyJobEffects(c, hourOfDay);
                Console.WriteLine("NPC is awake.");

                if (c.Job != null && SleepSystem.IsWorkingHour(c.Job, hourOfDay))
                    Console.WriteLine("NPC is working this hour.");
            }

            // Print hourly changes
            Console.WriteLine($"Energy: {c.Energy}");
            Console.WriteLine($"Stress: {c.Stress.Value}");
            Console.WriteLine($"Mood: {c.Mood.Value}");
        }

        Console.WriteLine("\n===== ENDING STATS =====");
        PrintStats(c);
    }

    private static void PrintStats(Character c)
    {
        Console.WriteLine("========================================");
        Console.WriteLine($"Name: {c.Name}");
        Console.WriteLine($"Job: {c.Job?.Title ?? "None"}");
        Console.WriteLine($"Energy: {c.Energy}");
        Console.WriteLine($"Stress: {c.Stress.Value}");
        Console.WriteLine($"Mood: {c.Mood.Value}");
        Console.WriteLine($"Comfort: {c.Comfort.Value}");
        Console.WriteLine($"Trust: {c.Trust.Value}");
        Console.WriteLine($"Respect: {c.Respect.Value}");
        Console.WriteLine($"Affection: {c.Affection.Value}");
        Console.WriteLine("========================================");
    }
}
