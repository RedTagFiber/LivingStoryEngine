using LivingStoryEngine.Characters;
using LivingStoryEngine.Relationshipsystems;

namespace LivingStoryEngine.NPCs
{
    public static class NPCTemplate
    {
        public static Character Create(string name, int age)
        {
            var npc = new Character();

            // Basic identity
            npc.Name = name;
            npc.Age = age;

            // Personality (empty defaults)
            npc.Goal = "";
            npc.Need = "";
            npc.Fear = "";

            // No relationships yet — they will be added later
            // npc.Meet(new Character { Name = "Someone" });

            return npc;
        }
    }
}
