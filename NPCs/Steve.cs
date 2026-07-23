using LivingStoryEngine.Characters;
using LivingStoryEngine.Emotional;

namespace LivingStoryEngine.NPCs
{
    public static class Steve
    {
        public static Character Create()
        {
            var steve = new Character();

            // ============================
            // BASIC IDENTITY
            // ============================
            steve.Name = "Steve";
            steve.Age = 30;

            // ============================
            // PERSONALITY / MOTIVATION
            // ============================
            steve.Goal = "Provide for his future";
            steve.Need = "Keep his job";
            steve.Fear = "Failure";

            // ============================
            // EMOTIONAL PROFILE
            // ============================
            steve.Emotion = new EmotionalProfile
            {
                Personality = PersonalityType.Calm,
                Attachment = AttachmentStyle.Secure,
                EmotionalArmor = ArmorLevel.Medium
            };

            // ============================
            // RELATIONSHIP WITH AMBER
            // ============================
            steve.Meet(new Character { Name = "Amber" });

            var rel = steve.GetRelationship("Amber");
            rel.Affection = 60;
            rel.Trust = 50;
            rel.Comfort = 45;
            rel.Attraction = 65;
            rel.Type = RelationshipType.Friend;

            return steve;
        }
    }
}
