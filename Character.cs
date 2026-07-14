namespace LivingStoryEngine;

public class Character
{
    public string Name { get; set; } = "";

    public int Trust { get; set; } = 50;

    public int Comfort { get; set; } = 50;

    public int Respect { get; set; } = 50;

    public int Affection { get; set; } = 50;

    public int Resentment { get; set; } = 0;

    public string Mood { get; set; } = "Neutral";

    public string Goal { get; set; } = "";
    public string Need { get; set; } = "";

    public string Fear { get; set; } = "";

    public string Want { get; set; } = "";

    public string CurrentDecision { get; set; } = "";

    public string Thought { get; set; } = "";
}