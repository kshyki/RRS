namespace RandomizedRewardSystem.Models
{
    public class Symbol
    {
        public SymbolType Type { get; set; }
        public int Value { get; set; }
        public double Probability { get; set; }
        public bool IsMultiplier { get; set; }

        public string ImagePath { get; set; }

        public Symbol(SymbolType type, int value, double probability, bool isMultiplier = false)
        {
            Type = type;
            Value = value;
            Probability = probability;
            IsMultiplier = isMultiplier;
        }
    }
}