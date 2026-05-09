namespace RandomizedRewardSystem.Models
{
    public class Symbol
    {
        public SymbolType Type;
        public int Value;
        public double Probability;
        public bool IsMultiplier;

        public Symbol(SymbolType type, int value, double probability, bool isMultiplier = false)
        {
            Type = type;
            Value = value;
            Probability = probability;
            IsMultiplier = isMultiplier;
        }
    }
}