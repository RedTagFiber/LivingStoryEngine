namespace LivingStoryEngine.Emotional
{
    public class Respect
    {
        public int Value { get; set; }

        public Respect()
        {
            Value = 50; // Default baseline respect
        }

        public Respect(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
