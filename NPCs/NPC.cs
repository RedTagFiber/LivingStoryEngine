using LivingStoryEngine.Characters;
using LivingStoryEngine.Models;

public class NPC
{
    public Character Character { get; set; }

    // NPC-level traits (optional)
    public List<SpecialTrait> Traits { get; set; } = new();

    // NPC-level history (optional)
    public List<HistoryRecord> History { get; set; } = new();

    public NPC()
    {
        Character = new Character();
    }
}
