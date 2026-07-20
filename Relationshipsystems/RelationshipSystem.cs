using LivingStoryEngine.Characters;
using LivingStoryEngine.Emotional;
using System;

namespace LivingStoryEngine.Relationshipsystems
{
    public static class RelationshipSystem
    {
        public static void MissDate(Character character, string targetName)
        {
            var relationship = character.GetRelationship(targetName);
            if (relationship == null)
                return;

            relationship.Trust = Math.Max(0, relationship.Trust - 5);
            relationship.Resentment = Math.Min(100, relationship.Resentment + 10);
            relationship.Comfort = Math.Max(0, relationship.Comfort - 3);
        }

        public static void Helped(Character character, string targetName)
        {
            var relationship = character.GetRelationship(targetName);
            if (relationship == null)
                return;

            relationship.Trust = Math.Min(100, relationship.Trust + 5);
            relationship.Respect = Math.Min(100, relationship.Respect + 10);
            relationship.Affection = Math.Min(100, relationship.Affection + 5);
        }

        public static void Lied(Character character, string targetName)
        {
            var relationship = character.GetRelationship(targetName);
            if (relationship == null)
                return;

            relationship.Trust = Math.Max(0, relationship.Trust - 15);
            relationship.Resentment = Math.Min(100, relationship.Resentment + 15);
            relationship.Comfort = Math.Max(0, relationship.Comfort - 10);
        }
        public static void UpdateRelationship(Character self, Character other)
        {
            var rel = self.GetRelationship(other.Name);

            if (rel == null) return;

            // Romantic evolution
            if (rel.Affection > 70 && rel.Trust > 60 && rel.Respect > 50)
            {
                if (self.IsRomanticMatch(self, other))
                {
                    if (rel.Type == RelationshipType.Friend)
                        rel.Type = RelationshipType.CloseFriend;

                    else if (rel.Type == RelationshipType.CloseFriend)
                        rel.Type = RelationshipType.Partner;
                }
            }

            // Negative evolution
            if (rel.Trust < 20 || rel.Affection < 20)
            {
                rel.Type = RelationshipType.Enemy;
            }

            // Complicated state
            if (rel.Type == RelationshipType.Partner &&
                self.RelationshipStyle == RelationshipStyle.Monogamous &&
                other.RelationshipStyle == RelationshipStyle.Monogamous &&
                rel.Affection < 40)
            {
                rel.Type = RelationshipType.Complicated;
            }
        }

    }
}
