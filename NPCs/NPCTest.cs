namespace LivingStoryEngine.NPCs
{
    public static class NPCTest
    {
        public static void GenerateTenNPCs()
        {
            Console.WriteLine("=== Generating 10 NPCs ===");

            for (int i = 1; i <= 10; i++)
            {
                var npc = NPCGenerator.GenerateNPC();

                Console.WriteLine($"NPC #{i}");
                Console.WriteLine($"Name: {npc.Character.Name}");
                Console.WriteLine($"History Count: {npc.Character.History.Count}");
                Console.WriteLine($"Trait Count: {npc.Character.SpecialTraits.Count}");

                Console.WriteLine("---------------------------");
            }
        }
    }
}
