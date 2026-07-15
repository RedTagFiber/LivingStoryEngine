using LivingStoryEngine.Characters;

namespace LivingStoryEngine.Relationshipsystems
{
    public static class RelationshipSystem
    {
        public static void MissDate(Character character, string targetName)
        {
            var relationship = character.GetRelationship(targetName);
            if (relationship == null)
                return;

            // Decrease trust and increase resentment when a date is missed
            relationship.Trust = Math.Max(0, relationship.Trust - 5);
            relationship.Resentment = Math.Min(100, relationship.Resentment + 5);
        }

        // Update the relationship status based on the new values   Helped Someone
        public static void Helped(Character character, string targetName)
        {
            var relationship = character.GetRelationship(targetName);
            if (relationship == null)
                return;

            relationship.Trust = Math.Min(1, relationship.Trust + 5);
            relationship.Respect = Math.Min(100, relationship.Respect + 5);
        }

        // Update the relationship status based on the new values  Lied
        public static void Lied(Character character, string targetName)
        {
            var relationship = character.GetRelationship(targetName);
            if (relationship == null)
                return;

            relationship.Trust = Math.Max(0, relationship.Trust - 15);
            relationship.Resentment = Math.Min(100, relationship.Resentment + 10);
        }

        // Update the relationship status based on the new values  Emotional Support
        public static void EmotionalSupport(Character character, string targetName)
        {
            var relationship = character.GetRelationship(targetName);
            if (relationship == null)
                return;

            relationship.Trust = Math.Min(100, relationship.Trust + 10);
            relationship.Love = Math.Min(100, relationship.Love + 5);
        }
    }
}