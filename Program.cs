using LivingStoryEngine.Characters;
using LivingStoryEngine.Systems;

namespace LivingStoryEngine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== NPC AI TEST (llama3 + phi3) ===");
            Console.WriteLine();

            // Create an NPC (Eve or any NPC your generator makes)
            NPC npc = NPCGenerator.GenerateNPC();
            Character c = npc.Character;

            Console.WriteLine($"Loaded NPC: {c.Name}");
            Console.WriteLine("-----------------------------------");

            // Run a 24-hour simulation
            for (int hour = 0; hour < 24; hour++)
            {
                Console.WriteLine();
                Console.WriteLine($"===== Hour {hour} =====");

                // Sleep / Work / Idle
                if (IsSleeping(hour))
                {
                    NPCGenerator.ApplySleep(c);
                    c.LastEvent = "Slept peacefully.";
                }
                else if (IsWorking(c, hour))
                {
                    NPCGenerator.ApplyJobEffects(c, hour);
                    c.LastEvent = "Worked a job shift.";
                }
                else
                {
                    NPCGenerator.ApplyIdle(c);
                    c.LastEvent = "Relaxed during free time.";
                }

                // Generate emotional thought (phi3)
                string thought = DialogueSystem.GenerateThought(c);
                c.Thought = thought;

                // Generate spoken dialogue (llama3)
                string spoken = DialogueSystem.GenerateDialogue(c, "How are you feeling right now?");
                c.SpokenLine = spoken;

                // Print NPC status
                PrintNPCState(c);
            }

            Console.WriteLine();
            Console.WriteLine("=== Simulation Complete ===");
        }

        // ============================================================
        // Helper Methods
        // ============================================================

        static bool IsSleeping(int hour)
        {
            return hour >= 22 || hour < 6;
        }

        static bool IsWorking(Character c, int hour)
        {
            if (c.Job == null || c.Job.Shifts == null)
                return false;

            return c.Job.Shifts.Any(s =>
                (s.StartHour < s.EndHour && hour >= s.StartHour && hour < s.EndHour) ||
                (s.StartHour > s.EndHour && (hour >= s.StartHour || hour < s.EndHour))
            );
        }

        static void PrintNPCState(Character c)
        {
            Console.WriteLine($"{c.Name}'s State:");
            Console.WriteLine($"  Mood: {c.Mood.Value}");
            Console.WriteLine($"  Stress: {c.Stress.Value}");
            Console.WriteLine($"  Energy: {c.Energy}");
            Console.WriteLine($"  Happiness: {c.Happiness}");
            Console.WriteLine($"  Decision: {c.CurrentDecision}");
            Console.WriteLine($"  Last Event: {c.LastEvent}");
            Console.WriteLine();
            Console.WriteLine($"  Thought (phi3): {c.Thought}");
            Console.WriteLine($"  Dialogue (llama3): {c.SpokenLine}");
            Console.WriteLine("-----------------------------------");
        }
    }
}
