namespace VendingMachineApp;

public class VendingMachine
{
    private List<Coin> _coinsInCredit = new List<Coin>();

    public VendingMachine()
    {
        Slots = new List<Slot>
        {
            new Slot(id: 1, name: "Cola", price: 1.00, quantity: 3),
            new Slot(id: 2, name: "Crisps", price: 0.50, quantity : 7),
            new Slot(id: 3, name: "Chocolate", price: 0.65, quantity: 4),
        };
    }

    public List<Slot> Slots { get; private set; }
    public double ValueInCredit => _coinsInCredit.Select(c => c.Value).Sum();

    public void InsertCoin(string name)
    {
        _coinsInCredit.Add(new Coin(name));
    }
}