using LivingStoryEngine.Characters;

namespace LivingStoryEngine.Player
{
    public static class PlayerFactory
    {
        public static Character CreatePlayer(string name)
        {
            var player = new Character();

            // Basic identity
            player.Name = name;
            player.Age = 25;

            // Core life direction
            player.Goal = "Build a meaningful life";
            player.Need = "Financial stability";
            player.Fear = "Missing opportunities";

            // Player starts with no predefined relationships;
            // they’ll form them during play.

            return player;
        }
    }
}
