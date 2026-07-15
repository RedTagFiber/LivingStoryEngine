using LivingStoryEngine;
using LivingStoryEngine.Characters;

namespace LivingStoryEngine.NPCs;

public static class NPCTemplate
{
    public static Character Create()
    {
        var npc = new Character();

        npc.Name = "";
        npc.Location = "Home";

        npc.Goal = "";
        npc.Need = "";
        npc.Fear = "";
        npc.Want = "";

        npc.CurrentDecision = "Thinking";

        npc.Thought = "";
        npc.JournalEntry = "";

        npc.Happiness = 50;
        npc.Energy = 100;
        npc.Stress = 0;
        npc.Curiosity = 50;

        return npc;
    }
}
