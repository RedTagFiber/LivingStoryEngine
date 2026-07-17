namespace LivingStoryEngine.Models;


public class HistoryRecord
{
    // =====================================================
    // TIMELINE
    // =====================================================

    public int Age { get; set; }

    // =====================================================
    // EVENT DATA
    // =====================================================

    public string Category { get; set; } = "";

    public string Event { get; set; } = "";

    public string Description { get; set; } = "";

    // =====================================================
    // PERSONALITY EFFECTS
    // =====================================================

    public Dictionary<string, int> Effects
    {
        get;
        set;
    } = new();

    // =====================================================
    // SPECIAL TRAITS GRANTED
    // =====================================================

    public List<string> GrantedTraits
    {
        get;
        set;
    } = new();
}