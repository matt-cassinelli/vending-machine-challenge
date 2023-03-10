namespace VendingMachineApp;
using System.Collections;
using System.Xml.Linq;

public class Coin
{
    public Coin(string name)
    {
        var _validCoins = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase){
            {"1p", 0.01},
            {"2p", 0.02},
            {"5p", 0.05},
            {"10p", 0.10},
            {"20p", 0.20},
            {"50p", 0.50},
            {"£1", 1.00},
            {"£2", 2.00}
        };

        if (_validCoins.ContainsKey(name))
        {
            Name = name;
            Value = _validCoins[name];
        }
        else
        {
            throw new ArgumentException($"{name} is not a valid coin");
        }
    }

    public Coin(double numericValue)
    {
        var _validCoins = new Dictionary<double, string>{
            {0.01, "1p"},
            {0.02, "2p"},
            {0.05, "5p"},
            {0.10, "10p"},
            {0.20, "20p"},
            {0.50, "50p"},
            {1.00, "£1"},
            {2.00, "£2"}
        };

        if (_validCoins.ContainsKey(numericValue))
        {
            Name = _validCoins[numericValue];
            Value = numericValue;
        }
        else
        {
            throw new ArgumentException($"No coin exists for {numericValue}");
        }
    }

    public string Name { get; }
    public double Value { get; }
}