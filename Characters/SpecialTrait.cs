using System.Text.Json.Serialization;

namespace LivingStoryEngine.Models;

/// <summary>
/// Individual special trait.
/// Example: Workaholic, NaturalLeader, DeepThinker.
/// </summary>
public class SpecialTrait
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("category")]
    public string Category { get; set; } = "";

    [JsonPropertyName("alignment")]
    public string Alignment { get; set; } = "";

    [JsonPropertyName("description")]
    public string Description { get; set; } = "";

    [JsonPropertyName("rarity")]
    public string Rarity { get; set; } = "";

    [JsonPropertyName("_traitPurpose")]
    public string TraitPurpose { get; set; } = "";

    [JsonPropertyName("_howItChangesCharacter")]
    public string HowItChangesCharacter { get; set; } = "";

    [JsonPropertyName("_designNotes")]
    public string DesignNotes { get; set; } = "";

    [JsonPropertyName("effects")]
    public Dictionary<string, double> Effects { get; set; } = new();

    [JsonPropertyName("_effectNotes")]
    public Dictionary<string, string> EffectNotes { get; set; } = new();

    [JsonPropertyName("growsFrom")]
    public List<string> GrowsFrom { get; set; } = new();

    [JsonPropertyName("_growthNotes")]
    public string GrowthNotes { get; set; } = "";

    [JsonPropertyName("conflictsWith")]
    public List<string> ConflictsWith { get; set; } = new();

    [JsonPropertyName("_conflictNotes")]
    public string ConflictNotes { get; set; } = "";

    [JsonPropertyName("usedBySystems")]
    public List<string> UsedBySystems { get; set; } = new();

    [JsonPropertyName("_systemNotes")]
    public string SystemNotes { get; set; } = "";

    [JsonPropertyName("relationshipEffects")]
    public List<string> RelationshipEffects { get; set; } = new();

    [JsonPropertyName("_relationshipNotes")]
    public string RelationshipNotes { get; set; } = "";

    [JsonPropertyName("memoryEffects")]
    public List<string> MemoryEffects { get; set; } = new();

    [JsonPropertyName("_memoryNotes")]
    public string MemoryNotes { get; set; } = "";
    [JsonPropertyName("strength")]
    public int Strength { get; set; } = 50;

}
