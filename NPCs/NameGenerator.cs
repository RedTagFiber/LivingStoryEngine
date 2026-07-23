namespace LivingStoryEngine.NPCs
{
    /// <summary>
    /// Generates NPC names.
    /// Clean, simple, and free of LogEvent() to avoid ambiguity.
    /// </summary>
    public static class NameGenerator
    {
        private static readonly List<string> FemaleNames = new()
        {
            "Eve", "Luna", "Maya", "Aria", "Sophie", "Clara"
        };

        private static readonly List<string> MaleNames = new()
        {
            "Ryan", "Ethan", "Leo", "Noah", "Caleb", "Julian"
        };

        private static readonly List<string> NeutralNames = new()
        {
            "Alex", "Jordan", "Taylor", "Sky", "River", "Phoenix"
        };

        private static readonly Random rng = new();

        // ============================================================
        // NAME GENERATION
        // ============================================================

        public static string GenerateName(string gender)
        {
            gender = gender.ToLower();

            return gender switch
            {
                "female" => FemaleNames[rng.Next(FemaleNames.Count)],
                "male" => MaleNames[rng.Next(MaleNames.Count)],
                _ => NeutralNames[rng.Next(NeutralNames.Count)]
            };
        }

        // ============================================================
        // RANDOM GENDER
        // ============================================================

        public static string RandomGender()
        {
            int roll = rng.Next(3);
            return roll switch
            {
                0 => "male",
                1 => "female",
                _ => "neutral"
            };
        }
    }
}
