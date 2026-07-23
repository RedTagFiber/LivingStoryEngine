using LivingStoryEngine.Characters;
using LivingStoryEngine.Emotional;

public static class Eve
{
    public static Character Create()
    {
        var eve = new Character();

        // ============================
        // BASIC IDENTITY
        // ============================
        eve.Name = "Eve";
        eve.Age = 25;

        // ============================
        // PERSONALITY / MOTIVATION
        // ============================
        eve.Goal = "Spend time with Ryan";
        eve.Need = "Keep her job";
        eve.Fear = "Losing people she cares about";

        // ============================
        // EMOTIONAL PROFILE
        // ============================
        eve.Emotion = new EmotionalProfile
        {
            Personality = PersonalityType.Warm,
            Attachment = AttachmentStyle.Secure,
            EmotionalArmor = ArmorLevel.Low
        };

        // ============================
        // RELATIONSHIP WITH RYAN
        // ============================
        eve.Meet(new Character { Name = "Ryan" });

        var rel = eve.GetRelationship("Ryan");
        rel.Affection = 70;
        rel.Trust = 60;
        rel.Comfort = 55;
        rel.Attraction = 80;
        rel.Type = RelationshipType.CloseFriend;

        return eve;
    }
}
