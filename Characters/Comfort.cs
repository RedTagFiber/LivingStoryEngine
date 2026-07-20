namespace LivingStoryEngine.Emotional
{
    public class Comfort
    {
        public int Value { get; set; }

        public Comfort()
        {
            Value = 50;
        }

        public Comfort(int value)
        {
            Value = value;
        }

        public override string ToString() => Value.ToString();
    }
}
