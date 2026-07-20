using LivingStoryEngine.Characters;
using LivingStoryEngine.Relationshipsystems;
using LivingStoryEngine.Emotional;

namespace LivingStoryEngine.NPCs
{
    public static class Jake
    {
        public static Character Create()
        {
            var jake = new Character();

            // ============================
            // BASIC IDENTITY
            // ============================
            jake.Name = "Jake";
            jake.Age = 28;

            // ============================
            // PERSONALITY / MOTIVATION
            // ============================
            jake.Goal = "Build a successful business";
            jake.Need = "Keep customers happy";
            jake.Fear = "Letting people down";

            // ============================
            // EMOTIONAL PROFILE
            // ============================
            jake.Emotion = new EmotionalProfile
            {
                Personality = PersonalityType.Determined,
                Attachment = AttachmentStyle.Avoidant,
                EmotionalArmor = ArmorLevel.High
            };

            // ============================
            // RELATIONSHIPS
            // ============================
            // Jake starts neutral toward everyone
            // (No Meet() calls here unless you want to add them)

            return jake;
        }
    }
}
