
using LivingStoryEngine.Emotional;

namespace LivingStoryEngine.Characters
{
    public static class CharacterFactory
    {
        // ============================================================
        // CREATE A RANDOM NPC
        // ============================================================
        public static Character CreateRandomNPC()
        {
            var npc = new Character();

            // Give the NPC an emotional profile
            npc.Emotion = new EmotionalProfile();

            // Apply personality + attachment + armor modifiers
            npc.Emotion.ApplyAllModifiers();

            return npc;
        }

        // ============================================================
        // CREATE EVE
        // ============================================================
        public static Character CreateEve()
        {
            var eve = new Character();

            // BASIC INFO
            eve.Name = "Eve";
            eve.Age = 25;
            eve.Goal = "Spend time with Ryan";
            eve.Need = "Keep her job";
            eve.Fear = "Losing people she cares about";

            // EMOTIONAL PROFILE
            eve.Emotion.Personality = PersonalityType.Warm;
            eve.Emotion.Attachment = AttachmentStyle.Secure;
            eve.Emotion.EmotionalArmor = ArmorLevel.Low;

            // Apply modifiers based on her traits
            eve.Emotion.ApplyAllModifiers();

            return eve;
        }
    }
}
