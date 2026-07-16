using System.Text.Json.Serialization;

namespace LivingStoryEngine.Models;

/// <summary>
/// Root object for Friendship.json,
/// Relationship.json,
/// Growth.json,
/// Work.json,
/// Flaws.json
/// </summary>
public class SpecialTraitFile
{
    [JsonPropertyName("version")]
    public string Version { get; set; } = "";

    [JsonPropertyName("traits")]
    public List<SpecialTrait> Traits { get; set; } = new();
}
