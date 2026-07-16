using System.Text.Json.Serialization;

namespace LivingStoryEngine.Models;

/// <summary>
/// Master registry for all Special Trait files.
/// Reads Encyclopedia.json.
/// </summary>
public class SpecialTraitRegistry
{
    [JsonPropertyName("version")]
    public string Version { get; set; } = "";

    [JsonPropertyName("_notes")]
    public NoteData Notes { get; set; } = new();

    [JsonPropertyName("files")]
    public List<string> Files { get; set; } = new();

    [JsonPropertyName("summary")]
    public SummaryData Summary { get; set; } = new();
}

/// <summary>
/// General information about the registry.
/// </summary>
public class NoteData
{
    [JsonPropertyName("purpose")]
    public string Purpose { get; set; } = "";

    [JsonPropertyName("usedBy")]
    public List<string> UsedBy { get; set; } = new();
}

/// <summary>
/// Counts of special traits by category.
/// </summary>
public class SummaryData
{
    [JsonPropertyName("Friendship")]
    public int Friendship { get; set; }

    [JsonPropertyName("Relationship")]
    public int Relationship { get; set; }

    [JsonPropertyName("Growth")]
    public int Growth { get; set; }

    [JsonPropertyName("Work")]
    public int Work { get; set; }

    [JsonPropertyName("Flaws")]
    public int Flaws { get; set; }

    [JsonPropertyName("TotalSpecialTraits")]
    public int TotalSpecialTraits { get; set; }
}