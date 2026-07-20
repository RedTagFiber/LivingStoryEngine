using LivingStoryEngine.Characters;
using LivingStoryEngine.Emotional;
using System;

namespace LivingStoryEngine.Relationshipsystems
{
    public class Relationship
    {
        public string TargetName { get; set; } = "";

        // Emotional dimensions
        public int Trust { get; set; } = 50;
        public int Respect { get; set; } = 50;
        public int Affection { get; set; } = 50;
        public int Comfort { get; set; } = 50;
        public int Attraction { get; set; } = 0;

        // Negative emotion
        public int Resentment { get; set; } = 0;

        // Type (Friend, Rival, Partner, etc.)
        public RelationshipType Type { get; set; } = RelationshipType.Acquaintance;

        // Interaction history
        public DateTime LastInteraction { get; set; } = DateTime.Now;
        public int InteractionCount { get; set; } = 0;
        public bool IsRomanticMatch(Character self, Character other)
        {
            return self.Orientation switch
            {
                Orientation.Straight => other.Gender == "Female" && self.Gender == "Male"
                                        || other.Gender == "Male" && self.Gender == "Female",

                Orientation.Gay => other.Gender == self.Gender,

                Orientation.Bisexual => true,

                Orientation.Pansexual => true,

                Orientation.Asexual => false,

                _ => false
            };
        }

    }
}