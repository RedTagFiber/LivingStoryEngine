using LivingStoryEngine.MemorySystem;

namespace LivingStoryEngine.Characters
{
    public class Memories
    {
        public List<Memory> Items { get; private set; } = new();

        public void Add(Memory memory)
        {
            Items.Add(memory);
        }

        public int Count => Items.Count;
    }
}
