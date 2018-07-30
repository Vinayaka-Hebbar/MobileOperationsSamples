namespace MobileSamples.Models
{
    public class Result
    {
        public object Value { get; set; } = "Hello";

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
