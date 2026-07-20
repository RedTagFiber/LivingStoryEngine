using LivingStoryEngine.Characters;

namespace LivingStoryEngine.Systems
{
    public static class EmotionalDriftSystem
    {
        private static Random rng = new Random();

        public static void Update(Character c)
        {
            // Mood drifts slightly each hour
            c.Mood.Value += rng.Next(-1, 2);

            // Affection drifts slowly
            c.Affection.Value += rng.Next(-1, 2);

            // Trust drifts slower
            if (rng.NextDouble() < 0.1)
                c.Trust.Value += rng.Next(-1, 2);

            // Respect drifts slower
            if (rng.NextDouble() < 0.1)
                c.Respect.Value += rng.Next(-1, 2);

            // Clamp everything
            c.Mood.Value = Math.Clamp(c.Mood.Value, 0, 100);
            c.Affection.Value = Math.Clamp(c.Affection.Value, 0, 100);
            c.Trust.Value = Math.Clamp(c.Trust.Value, 0, 100);
            c.Respect.Value = Math.Clamp(c.Respect.Value, 0, 100);
        }

        internal static void Update(object character)
        {
            throw new NotImplementedException();
        }
    }
}
