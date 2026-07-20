namespace LivingStoryEngine.Emotional
{
    public class Mood
    {
        public int Value { get; set; }

        public Mood()
        {
            Value = 50;
        }

        public Mood(int value)
        {
            Value = value;
        }

        public override string ToString() => Value.ToString();
    }
}
