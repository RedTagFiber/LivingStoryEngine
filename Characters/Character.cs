using LivingStoryEngine.Characters;
using LivingStoryEngine.Emotional;
using LivingStoryEngine.Managers;
using LivingStoryEngine.Models;
using LivingStoryEngine.Money;
using LivingStoryEngine.Relationshipsystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using LivingStoryEngine.Systems;

namespace LivingStoryEngine.Characters
{
    /// <summary>
    /// Base character model used by all NPCs and players.
    /// This file has been rewritten cleanly to remove duplicates,
    /// fix braces, and add a stable relationship system.
    /// </summary>
    public class Character
    {
        // ============================================================
        // BASIC INFO
        // ============================================================
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Goal { get; set; } = "";
        public string Need { get; set; } = "";
        public string Fear { get; set; } = "";
        public Orientation Orientation { get; set; } = Orientation.Straight;
        public RelationshipStyle RelationshipStyle { get; set; } = RelationshipStyle.Monogamous;
        public string Gender { get; set; } = "Unknown";
        
        public Job? Job { get; set; }




        // ============================================================
        // PERSONALITY MODIFIER SYSTEM
        // ============================================================
        private Dictionary<string, double> _modifiers = new();
        public EmotionalProfile Emotion { get; set; } = new EmotionalProfile();

     
             
        public EmotionalProfile Emotional { get; set; } = new EmotionalProfile();

        public void SetModifier(string name, double value)
        {
            _modifiers[name] = value;
        }

        public double GetModifier(string name)
        {
            if (_modifiers.TryGetValue(name, out double value))
                return value;

            return 0.0;
        }

        // ============================================================
        // SOCIAL & RELATIONSHIPS (PLAYER-FOCUSED FIELDS)
        // ============================================================
        public int Love { get; set; } = 0;
        public int TrustLevel { get; set; } = 50;
        public string RelationshipStatus { get; set; } = "Friend";
        public string LoveStatus { get; set; } = "Stranger";
        public string LoveInterest { get; set; } = "";
        public int DatesCompleted { get; set; }
        public bool IsRomanticMatch(Character other, Character other1)

{
    // If either character has no gender set, skip romantic matching
    if (string.IsNullOrEmpty(this.Gender) || string.IsNullOrEmpty(other.Gender))
        return false;

    switch (this.Orientation)
    {
        case Orientation.Straight:
            return (this.Gender == "Male" && other.Gender == "Female")
                || (this.Gender == "Female" && other.Gender == "Male");

        case Orientation.Gay:
            return this.Gender == other.Gender;

        case Orientation.Bisexual:
            return true;

        case Orientation.Pansexual:
            return true;

        case Orientation.Asexual:
            return false;

        default:
            return false;
    }
}

        // ============================================================
        // RELATIONSHIP WEB (NPC ↔ NPC + Player ↔ NPC)
        // ============================================================
        public List<Relationship> Relationships { get; set; } = new();
        public Mood Mood { get; set; } = new Mood();

        public Stress Stress { get; set; } = new Stress();
        public Memories Memories { get; set; } = new Memories();
        public Affection Affection { get; set; } = new Affection();
        public Trust Trust { get; set; } = new Trust();
        public Comfort Comfort { get; set; } = new Comfort();
        public Respect Respect { get; set; } = new Respect();
        public List<HistoryRecord> History { get; set; } = new();
        public List<SpecialTrait> SpecialTraits { get; set; } = new();

        public string Thought { get; set; } = "";
        public string CurrentDecision { get; set; } = "";
        public string Location { get; set; } = "";
        public string Want { get; set; } = "";
        public int Resentment { get; internal set; } = 0;
        public int Happiness { get; internal set; } = 0;
        public int Energy { get; internal set; } = 0;






        // ============================================================
        // GET OR CREATE RELATIONSHIP
        // ============================================================
        /// <summary>
        /// Returns an existing relationship OR creates a new one.
        /// This prevents duplicate relationships and keeps the web clean.
        /// </summary>
        public Relationship GetRelationship(string targetName)
        {
            var rel = Relationships.FirstOrDefault(r => r.TargetName == targetName);

            if (rel == null)
            {
                rel = new Relationship
                {
                    TargetName = targetName,
                    Trust = 30,
                    Respect = 50,
                    Affection = 20,
                    Comfort = 40,
                    Attraction = 0,
                    Type = LivingStoryEngine.Emotional.RelationshipType.Acquaintance,
                    LastInteraction = DateTime.Now
                };

                Relationships.Add(rel);
            }

            return rel;
        }

        // ============================================================
        // MEET ANOTHER CHARACTER
        // ============================================================
        /// <summary>
        /// Creates a relationship if one does not exist.
        /// </summary>
        public void Meet(Character other)
        {
            if (other.Name == this.Name) return;
            GetRelationship(other.Name);
        }

        // ============================================================
        // INTERACT WITH ANOTHER CHARACTER
        // ============================================================
        /// <summary>
        /// Interaction modifies emotional values.
        /// </summary>
        public void Interact(Character other, int impact)
        {
            var rel = GetRelationship(other.Name);

            rel.LastInteraction = DateTime.Now;
            rel.InteractionCount++;

            rel.Affection += impact;
            rel.Trust += impact / 2;
            rel.Comfort += impact / 3;
        }

        // ============================================================
        // DAILY RELATIONSHIP UPDATE (EMOTIONAL DRIFT)
        // ============================================================
        /// <summary>
        /// Relationships weaken over time if no interaction occurs.
        /// </summary>
        public void DailyRelationshipUpdate()
        {
            foreach (var rel in Relationships)
            {
                int days = (DateTime.Now - rel.LastInteraction).Days;

                if (days > 3) rel.Comfort -= 1;
                if (days > 7) rel.Affection -= 1;
                if (days > 14) rel.Trust -= 1;
                if (days > 30) rel.Respect -= 1;
            }
        }

        // ============================================================
        // OPTIONAL: APPLY NEEDS, GOALS, FEARS TO RELATIONSHIPS
        // ============================================================
        /// <summary>
        /// NPC personality influences relationship drift.
        /// </summary>
        public void ApplyNeedsToRelationships()
        {
            foreach (var rel in Relationships)
            {
                switch (Need)
                {
                    case "Connection": rel.Affection += 1; break;
                    case "Safety": rel.Trust += 1; break;
                    case "Achievement": rel.Respect += 1; break;
                    case "Relaxation": rel.Comfort += 1; break;
                }

                if (Goal.Contains(rel.TargetName))
                {
                    rel.Affection += 2;
                    rel.Trust += 1;
                }

                if (Fear.Contains(rel.TargetName))
                {
                    rel.Comfort -= 1;
                }
            }
        }

        // ============================================================
        // UPDATE RELATIONSHIP TYPE BASED ON EMOTIONAL SCORES
        // ============================================================
        public void UpdateRelationshipTypes()
        {
            foreach (var rel in Relationships)
            {
                int closeness = (rel.Trust + rel.Affection + rel.Comfort + rel.Respect) / 4;

                if (closeness > 80) rel.Type = RelationshipType.CloseFriend;
                else if (closeness > 60) rel.Type = RelationshipType.Friend;
                else if (closeness > 40) rel.Type = RelationshipType.Acquaintance;
                else if (closeness < 20) rel.Type = RelationshipType.Rival;
            }
        }   // ============================================================
            // NPC-to-NPC emotional interactions
            // ============================================================

        public void ReceiveEvent(string fromName, string eventType)
        {
            // Ensure relationship exists
            var rel = GetRelationship(fromName);
            if (rel == null)
            {
                Meet(new Character { Name = fromName });
                rel = GetRelationship(fromName);
            }

            // Emotional reaction
            Emotion.ProcessEvent($"{fromName}: {eventType}");

            // Relationship impact
            switch (eventType)
            {
                case "kind gesture":
                    rel.Affection += 5;
                    rel.Trust += 3;
                    break;

                case "support offered":
                    rel.Comfort += 4;
                    rel.Trust += 4;
                    break;

                case "lie detected":
                    rel.Trust -= 8;
                    rel.Affection -= 4;
                    break;

                case "harsh comment":
                    rel.Comfort -= 6;
                    rel.Affection -= 5;
                    break;

                case "ignored":
                    rel.Comfort -= 3;
                    break;

                case "social interaction":
                    rel.Affection += 1;
                    break;
            }
        }
        static string GenerateHellEvent()
        {
            string[] badEvents =
            {
        "harsh comment",
        "lie detected",
        "ignored",
        "argument",
        "betrayal",
        "stress spike",
        "embarrassing moment"
    };

            string[] goodEvents =
            {
        "kind gesture",
        "support offered",
        "encouragement",
        "shared moment",
        "help received",
        "comforting words"
    };

            Random r = new Random();
            bool badDay = r.Next(0, 100) < 65; // 65% chance of bad day

            if (badDay)
                return badEvents[r.Next(badEvents.Length)];
            else
                return goodEvents[r.Next(goodEvents.Length)];
        }

        public string GetEmotionDebug()
        {
            var lastMemory = Emotion.Memories.LastOrDefault();
            string lastEvent = lastMemory != null ? lastMemory.Summary : "None";

            return
                $"{Name}\n" +
                $"  Mood: {Emotion.Mood}\n" +
                $"  Stress: {Emotion.Stress}\n" +
                $"  Comfort: {Emotion.Comfort}\n" +
                $"  Trust: {Emotion.Trust}\n" +
                $"  Affection: {Emotion.Affection}\n" +
                $"  Respect: {Emotion.Respect}\n" +
                $"  Last Event: {lastEvent}\n" +
                $"  Memories: {Emotion.Memories.Count}\n";


        }

        internal void ProcessEvent(string v)
        {
            throw new NotImplementedException();
        }
    }
}
