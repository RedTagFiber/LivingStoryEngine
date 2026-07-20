namespace LivingStoryEngine.Emotional
{
    public class Resentment
    {
        public int Value { get; set; }

        public Resentment()
        {
            Value = 0; // baseline resentment
        }

        public Resentment(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
