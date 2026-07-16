using System.Text.Json;
using LivingStoryEngine.Models;

namespace LivingStoryEngine.Managers;

public static class SpecialTraitManager
{
    public static Dictionary<string, SpecialTrait> Traits
        = new();

    public static void Load(string filePath)
    {
        string json = File.ReadAllText(filePath);

        SpecialTraitFile? traitFile =
            JsonSerializer.Deserialize<SpecialTraitFile>(json);

        if (traitFile == null)
            return;

        foreach (var trait in traitFile.Traits)
        {
            Traits[trait.Name] = trait;
        }
    }

    public static void LoadAll()
    {
        string basePath = Path.Combine(
            AppContext.BaseDirectory,
            "Data",
            "SpecialTraits"
        );

        Load(Path.Combine(basePath, "Friendship.json"));
        Load(Path.Combine(basePath, "Relationship.json"));
        Load(Path.Combine(basePath, "Growth.json"));
        Load(Path.Combine(basePath, "Work.json"));
        Load(Path.Combine(basePath, "Flaws.json"));
    }
    public static SpecialTrait? GetTrait(string name)
    {
        return Traits.TryGetValue(name, out var trait)
            ? trait
            : null;
    }
}