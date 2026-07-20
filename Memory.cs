namespace LivingStoryEngine.MemorySystem
{
    public class Memory
    {
        public string Summary { get; set; } = "";
        public int Importance { get; set; } = 50;   // 0–100
        public DateTime DateCreated { get; set; } = DateTime.Now;

        // How strongly the memory affects the character emotionally
        public int EmotionalWeight { get; set; } = 50;

        // Whether the memory is positive, negative, or neutral
        public string Polarity { get; set; } = "Neutral";

        // How much the memory has faded over time
        public int Clarity { get; set; } = 100;     // 0–100
    }
}
