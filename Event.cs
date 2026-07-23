namespace LivingStoryEngine;

public class GameEvent
{
    public string Title { get; set; } = "";

    public string Description { get; set; } = "";

    public int Importance { get; set; }

    public DateTime EventDate { get; set; }

    public string CharacterName { get; set; } = "";
}