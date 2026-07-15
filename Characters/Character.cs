namespace LivingStoryEngine.Characters;

using LivingStoryEngine.Money;
using LivingStoryEngine.Relationshipsystems;
using LivingStoryEngine.Systems;
using LivingStoryEngine.Player;
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
    public string JournalEntry { get; set; } = "";

    public string RelationshipStatus { get; set; } = "Friend";

    public string Location { get; set; } = "";

    public int Happiness { get; set; } = 50;
    public int Love { get; set; } = 0;
    public string LoveStatus { get; set; } = "Stranger";
    public string LoveInterest { get; set; } = "";
    public List<Relationship> Relationships { get; set; } = new();
    public Relationship? GetRelationship(string targetName)
    {
        return Relationships
            .FirstOrDefault(r => r.TargetName == targetName);
    }
    public int Heartbreak { get; set; } = 0;
    public int Looks { get; set; } = 50;
    public string Sex { get; set; } = "";
    public Appearance Appearance { get; set; } = new();
    public int Attractiveness { get; set; } = 50;
    public int Charisma { get; set; } = 50;

    public int Confidence { get; set; } = 50;

    public int Maturity { get; set; } = 50;

    public int LikesLooks { get; set; } = 50;

    public int LikesCharisma { get; set; } = 50;

    public int LikesConfidence { get; set; } = 50;

    public int LikesMaturity { get; set; } = 50;
    public int Curiosity { get; set; } = 50;
    public List<string> Questions { get; set; } = new();
    public List<Trait> Traits { get; set; } = new();
    public int Energy { get; set; } = 100;
    public int Stress { get; internal set; }
    public Money Finances { get; set; } = new();

    public SpendingProfile Spending { get; set; } = new();
    public Job Job { get; set; } = new();

    public void UpdateRelationshipStatus()
    {
        if (Trust >= 80)
        {
            RelationshipStatus = "Best Friend";
        }
        else if (Trust >= 60)
        {
            RelationshipStatus = "Close Friend";
        }
        else if (Trust >= 40)
        {
            RelationshipStatus = "Friend";
        }
        else if (Trust >= 20)
        {
            RelationshipStatus = "Acquaintance";
        }
        else
        {
            RelationshipStatus = "Stranger";
        }
    }

    public void UpdateLoveStatus()
    {
        if (Love >= 90)
        {
            LoveStatus = "Soulmate";
        }
        else if (Love >= 75)
        {
            LoveStatus = "In Love";
        }
        else if (Love >= 60)
        {
            LoveStatus = "Dating";
        }
        else if (Love >= 40)
        {
            LoveStatus = "Interested";
        }
        else if (Love >= 20)
        {
            LoveStatus = "Friend";
        }
        else
        {
            LoveStatus = "Stranger";
        }
    }

 
   

    public void RecoverFromHeartbreak()
    {
        if (Heartbreak > 0)
        {
            Heartbreak--;
        }
    }

}


