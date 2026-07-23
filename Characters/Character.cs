using LivingStoryEngine.Financial;
using LivingStoryEngine.MemorySystem;
using LivingStoryEngine.Relationshipsystems;

namespace LivingStoryEngine.Characters
{
    /// <summary>
    /// Core character model used by NPCs and players.
    /// Contains:
    /// - Identity
    /// - Emotional stats
    /// - Job
    /// - Finances
    /// - Relationships
    /// - Traits
    /// </summary>
    public class Character
    {
        // ============================
        // BASIC INFO
        // ============================

        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Gender { get; set; } = "";

        // ============================
        // EMOTIONAL SYSTEM
        // ============================

        public int Trust { get; set; } = 50;
        public int Comfort { get; set; } = 50;
        public int Respect { get; set; } = 50;
        public int Affection { get; set; } = 50;
        public int Attraction { get; set; } = 50;
        public int Energy { get; set; } = 70;

        // ============================
        // JOB + MONEY
        // ============================

        public Job? Job { get; set; }

        // Your new unified financial model
        public SpendingProfile Wallet { get; set; } = new SpendingProfile();
        public SpendingProfile Spending { get; set; } = new SpendingProfile();

        // ============================
        // RELATIONSHIPS
        // ============================

        public List<Relationship> Relationships { get; set; } = new();

        public Relationship? GetRelationship(string targetName)
        {
            return Relationships.FirstOrDefault(r => r.TargetName == targetName);
        }

        // ============================
        // MEMORY SYSTEM
        // ============================

        public List<Memory> Memories { get; set; } = new();

        public void AddMemory(string summary, int importance)
        {
            Memories.Add(new Memory
            {
                Summary = summary,
                Importance = importance,
                DateCreated = DateTime.Now
            });
        }
    }
}
