namespace LivingStoryEngine.Models;

public class HistoryEventDefinition
{
    public string Name { get; set; } = "";

    public string Category { get; set; } = "";

    public string Polarity { get; set; } = "Neutral";

    public int MinAge { get; set; }

    public int MaxAge { get; set; }

    public int Weight { get; set; } = 10;

    public string Description { get; set; } = "";

    public List<string> Traits { get; set; }
        = new();
}
