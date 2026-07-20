
namespace LivingStoryEngine.Emotional
{
    public class Trust
    {
        public int Value { get; set; }

        public Trust()
        {
            Value = 50; // baseline trust
        }

        public Trust(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
