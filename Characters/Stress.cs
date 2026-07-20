namespace LivingStoryEngine.Emotional
{
    public class Stress
    {
        public int Value { get; set; }

        public Stress()
        {
            Value = 0; // baseline stress
        }

        public Stress(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
