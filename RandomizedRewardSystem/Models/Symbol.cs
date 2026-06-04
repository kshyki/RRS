using System;
namespace RandomizedRewardSystem.Models
{
    public class Symbol
    {
        public SymbolType Type { get; set; }
        public int Value { get; set; }
        public double Probability { get; set; }
        public bool IsMultiplier { get; set; }

        public string ImagePath =>
                    Type switch
                    {
                        SymbolType.Cherry => Config.Cherry,
                        SymbolType.Lemon => Config.Lemon,
                        SymbolType.Seven => Config.Seven,
                        SymbolType.Diamond => Config.Diamond,
                        SymbolType.Multiplier => Config.Multiplier,
                        _ => null
                    };

        public Symbol(SymbolType type, int value, double probability, bool isMultiplier = false)
        {
            Type = type;
            Value = value;
            Probability = probability;
            IsMultiplier = isMultiplier;
        }
    }
}