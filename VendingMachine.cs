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
    public List<Coin> CoinReturnTray { get; private set; } = new List<Coin>();
    // [todo] public bool ExactChangeRequired
    public List<Slot> Slots { get; private set; }
    public List<Product> ProductCollectionTray { get; private set; } = new List<Product>();

    public void InsertCoin(string name)
    {
        try
        {
            _coinsInCredit.Add(new Coin(name));
        }
        catch { }
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

        while (leftToConvert >= 2.00)
        {
            converted.Add(new Coin(2.00));
            leftToConvert -= 2.00;
        }

        while (leftToConvert >= 1.00)
        {
            converted.Add(new Coin(1.00));
            leftToConvert -= 1.00;
        }

        while (leftToConvert >= 0.50)
        {
            converted.Add(new Coin(0.50));
            leftToConvert -= 0.50;
        }

        while (leftToConvert >= 0.20)
        {
            converted.Add(new Coin(0.20));
            leftToConvert -= 0.20;
        }

        while (leftToConvert >= 0.10)
        {
            converted.Add(new Coin(0.10));
            leftToConvert -= 0.10;
        }

        while (leftToConvert >= 0.05)
        {
            converted.Add(new Coin(0.05));
            leftToConvert -= 0.05;
        }

        while (leftToConvert >= 0.02)
        {
            converted.Add(new Coin(0.02));
            leftToConvert -= 0.02;
        }

        while (leftToConvert >= 0.01)
        {
            converted.Add(new Coin(0.01));
            leftToConvert -= 0.01;
        }

        return converted;
    }
}