namespace VendingMachineApp;

public class VendingMachine
{
    private List<Coin> _coinsInCredit = new List<Coin>();
    private List<Coin> _coinsInSafe;

    public VendingMachine(List<Slot> slots, List<Coin> coinsToLoad)
    {
        Slots = slots;
        _coinsInSafe = coinsToLoad;
    }

    public double ValueInCredit => _coinsInCredit.Select(c => c.Value).Sum();

    public List<Slot> Slots { get; private set; }
    public List<Product> ProductCollectionTray { get; private set; } = new List<Product>();
    public List<Coin> CoinReturnTray { get; private set; } = new List<Coin>();
    // [todo] public bool ExactChangeRequired

    public void InsertCoin(string name)
    {
        _coinsInCredit.Add(new Coin(name));
    }

    public void SelectProduct(int slotId)
    {
        var slot = Slots.Find(s => s.Id == slotId);

        if (slot != null && slot.Quantity > 0 && ValueInCredit >= slot.Price)
        {
            CoinReturnTray.AddRange(
                NumberToCoins(ValueInCredit - slot.Price)
            );

            _coinsInSafe.AddRange(_coinsInCredit);
            _coinsInCredit.Clear();

            var product = slot.Dispense();
            ProductCollectionTray.Add(product);
        }
    }

    public void PressCoinReturnButton()
    {
        CoinReturnTray.AddRange(_coinsInCredit);
        _coinsInCredit.Clear();
    }

    private List<Coin> NumberToCoins(double amount)
    {
        var leftToConvert = amount;
        var converted = new List<Coin>();

        while (leftToConvert >= 50)
        {
            converted.Add(new Coin(50));
            leftToConvert -= 50;
        }

        while (leftToConvert >= 20)
        {
            converted.Add(new Coin(20));
            leftToConvert -= 20;
        }

        while (leftToConvert >= 10)
        {
            converted.Add(new Coin(10));
            leftToConvert -= 10;
        }

        while (leftToConvert >= 5)
        {
            converted.Add(new Coin(5));
            leftToConvert -= 5;
        }

        while (leftToConvert >= 2)
        {
            converted.Add(new Coin(2));
            leftToConvert -= 2;
        }

        while (leftToConvert >= 1)
        {
            converted.Add(new Coin(1));
            leftToConvert -= 1;
        }

        return converted;
    }
}