namespace LivingStoryEngine.Emotional
{
    public class Affection
    {
        public int Value { get; set; }

        public Affection()
        {
            Value = 50; // baseline affection
        }

        public Affection(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
