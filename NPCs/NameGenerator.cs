using System;

namespace LivingStoryEngine.NPCs
{
    public static class NameGenerator
    {
        private static readonly string[] FirstNames =
        {
            "Evelyn", "Sophia", "Isabella", "Mia", "Charlotte",
            "Liam", "Noah", "Oliver", "Elijah", "James",
            "Ryan", "Amber", "Jake", "Steve", "Ava",
            "Lucas", "Henry", "Benjamin", "Harper", "Ella"
        };

        private static readonly string[] LastNames =
        {
            "Johnson", "Smith", "Williams", "Brown", "Taylor",
            "Davis", "Miller", "Wilson", "Moore", "Anderson",
            "Clark", "Hall", "Lewis", "Young", "King"
        };

        private static readonly Random rng = new();

        public static string GenerateFirstName()
        {
            return FirstNames[rng.Next(FirstNames.Length)];
        }

        public static string GenerateLastName()
        {
            return LastNames[rng.Next(LastNames.Length)];
        }

        public static string GenerateFullName()
        {
            return $"{GenerateFirstName()} {GenerateLastName()}";
        }

    }
}
