using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
namespace RandomizedRewardSystem.Models
{
    public class Symbol
    {
        public SymbolType Type { get; set; }
        public int Value { get; set; }
        public double Probability { get; set; }
        public bool IsMultiplier { get; set; }

        public Bitmap Image { get; set;}

        public Symbol(SymbolType type, int value, double probability, string imagePath, bool isMultiplier = false) // class for symbol object
        {
            Type = type;
            Value = value;
            Probability = probability;
            IsMultiplier = isMultiplier;
            
            try
            {
                Image = new Bitmap(AssetLoader.Open(new Uri(imagePath)));
            }
            catch
            {
                Image = null;
            }
        }
    }
}