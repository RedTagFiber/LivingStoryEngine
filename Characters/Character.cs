namespace LivingStoryEngine.Characters;

using LivingStoryEngine.Managers;
using LivingStoryEngine.Models;
using LivingStoryEngine.Money;
using LivingStoryEngine.Player;
using LivingStoryEngine.Relationshipsystems;

/// <summary>
/// Base character model used by all NPCs and players.
/// Stores personality, relationships, finances,
/// appearance, history, and life information.
/// </summary>
public class Character
{
    // =====================================================
    // BASIC INFORMATION
    // =====================================================

    public string Name { get; set; } = "";
    public string Sex { get; set; } = "";
    public string Location { get; set; } = "";
    public int Age { get; set; } = 18;

    // =====================================================
    // LIFE HISTORY
    // =====================================================

    public List<HistoryRecord> History { get; set; } = new();

    // =====================================================
    // PERSONALITY & EMOTIONS
    // =====================================================

    public int Trust { get; set; } = 50;
    public int Comfort { get; set; } = 50;
    public int Respect { get; set; } = 50;
    public int Affection { get; set; } = 50;
    public int Resentment { get; set; } = 0;

    public int Confidence { get; set; } = 50;
    public int Maturity { get; set; } = 50;
    public int Curiosity { get; set; } = 50;

    public string Mood { get; set; } = "Neutral";

    // =====================================================
    // GOALS & MOTIVATIONS
    // =====================================================

    public string Goal { get; set; } = "";
    public string Need { get; set; } = "";
    public string Want { get; set; } = "";
    public string Fear { get; set; } = "";

    // =====================================================
    // DECISION SYSTEM
    // =====================================================

    public string CurrentDecision { get; set; } = "";

    // =====================================================
    // THOUGHTS & JOURNAL
    // =====================================================

    public string Thought { get; set; } = "";
    public string JournalEntry { get; set; } = "";

    // =====================================================
    // SPECIAL TRAITS
    // =====================================================

    public List<string> SpecialTraits { get; set; } = new();

    public Dictionary<string, double> TraitModifiers
    {
        get;
        set;
    } = new();

    // =====================================================
    // CORE TRAITS
    // =====================================================

    public List<Trait> Traits { get; set; } = new();

    // =====================================================
    // SOCIAL & RELATIONSHIPS
    // =====================================================

    public int Love { get; set; } = 0;
    public int TrustLevel { get; set; } = 50;

    public string RelationshipStatus { get; set; } = "Friend";
    public string LoveStatus { get; set; } = "Stranger";
    public string LoveInterest { get; set; } = "";

    public int DatesCompleted { get; set; }

    public List<Relationship> Relationships
    {
        get;
        set;
    } = new();

    // =====================================================
    // HEARTBREAK & RECOVERY
    // =====================================================

    public int Heartbreak { get; set; } = 0;

    // =====================================================
    // APPEARANCE
    // =====================================================

    public int Looks { get; set; } = 50;
    public int Attractiveness { get; set; } = 50;
    public int Charisma { get; set; } = 50;

    public Appearance Appearance { get; set; }
        = new();

    // =====================================================
    // PREFERENCES
    // =====================================================

    public int LikesLooks { get; set; } = 50;
    public int LikesCharisma { get; set; } = 50;
    public int LikesConfidence { get; set; } = 50;
    public int LikesMaturity { get; set; } = 50;

    // =====================================================
    // QUESTIONS & CURIOSITY
    // =====================================================

    public List<string> Questions
    {
        get;
        set;
    } = new();

    // =====================================================
    // HEALTH & ENERGY
    // =====================================================

    public int Energy { get; set; } = 100;
    public int Happiness { get; set; } = 50;
    public int Stress { get; internal set; }

    // =====================================================
    // FINANCES & CAREER
    // =====================================================

    public Money Finances { get; set; } = new();

    public SpendingProfile Spending
    {
        get;
        set;
    } = new();

    public Job Job { get; set; } = new();

    // =====================================================
    // TRAIT HELPERS
    // =====================================================

    public double GetModifier(string stat)
    {
        return TraitModifiers.TryGetValue(stat, out var value)
            ? value
            : 0.0;
    }

    public bool HasTrait(string traitName)
    {
        return SpecialTraits.Contains(traitName);
    }

    // =====================================================
    // RELATIONSHIP HELPERS
    // =====================================================

    public Relationship? GetRelationship(
        string targetName)
    {
        return Relationships
            .FirstOrDefault(
                r => r.TargetName == targetName
            );
    }

    public void UpdateRelationshipStatus()
    {
        if (Love >= 90)
            RelationshipStatus = "Soulmates";
        else if (Love >= 75)
            RelationshipStatus = "Dating";
        else if (Love >= 50)
            RelationshipStatus = "Interested";
        else if (Love >= 25)
            RelationshipStatus = "Friends";
        else
            RelationshipStatus = "Strangers";
    }

    public void UpdateLoveStatus()
    {
        if (Love >= 90)
            LoveStatus = "Soulmate";
        else if (Love >= 75)
            LoveStatus = "In Love";
        else if (Love >= 60)
            LoveStatus = "Dating";
        else if (Love >= 40)
            LoveStatus = "Interested";
        else if (Love >= 20)
            LoveStatus = "Friend";
        else
            LoveStatus = "Stranger";
    }

    // =====================================================
    // RECOVERY SYSTEM
    // =====================================================

    public void RecoverFromHeartbreak()
    {
        if (Heartbreak > 0)
        {
            Heartbreak--;
        }
    }
}