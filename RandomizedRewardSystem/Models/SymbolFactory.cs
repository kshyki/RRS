using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomizedRewardSystem.Models
{    
    public static class SymbolFactory{
        private static List<Symbol> _availableSymbols = new()
        {
            new Symbol(SymbolType.Cherry, 10, 0.4),
            new Symbol(SymbolType.Lemon, 20, 0.3),
            new Symbol(SymbolType.Seven, 50, 0.15), 
            new Symbol(SymbolType.Diamond, 100, 0.1),
            new Symbol(SymbolType.Multiplier, 0, 0.05, true)
        };

        private static Random _random = new();

        public static Symbol GetRandomSymbol()
        {
            double diceRoll = _random.NextDouble();
            double cumulative = 0.0;

            foreach(var symbol in _availableSymbols)
            {
                cumulative += symbol.Probability;

                if(diceRoll < cumulative)
                {
                    return symbol;
                }
            }

            return _availableSymbols[0];
        }
    }
}