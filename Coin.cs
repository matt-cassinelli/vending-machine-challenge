namespace VendingMachineApp;
using System.Collections;

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

    public string Name { get; }
    public double Value { get; }
}