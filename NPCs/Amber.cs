using LivingStoryEngine.Characters;
using LivingStoryEngine.Relationshipsystems;
using LivingStoryEngine.Emotional;

namespace LivingStoryEngine.NPCs
{
    public static class Amber
    {
        public static Character Create()
        {
            var amber = new Character();

            // ============================
            // BASIC IDENTITY
            // ============================
            amber.Name = "Amber";
            amber.Age = 23;

            // ============================
            // PERSONALITY / MOTIVATION
            // ============================
            amber.Goal = "Spend time with Steve";
            amber.Need = "Keep her apartment";
            amber.Fear = "Being abandoned";

            // ============================
            // EMOTIONAL PROFILE
            // ============================
            amber.Emotion = new EmotionalProfile
            {
                Personality = PersonalityType.Guarded,
                Attachment = AttachmentStyle.Anxious,
                EmotionalArmor = ArmorLevel.Medium
            };

            // ============================
            // RELATIONSHIP WITH STEVE
            // ============================
            amber.Meet(new Character { Name = "Steve" });

            var rel = amber.GetRelationship("Steve");
            rel.Affection = 65;
            rel.Trust = 55;
            rel.Comfort = 50;
            rel.Attraction = 70;
            rel.Type = RelationshipType.Friend;

            return amber;
        }
    }
}
