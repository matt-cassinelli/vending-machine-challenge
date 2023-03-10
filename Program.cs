using VendingMachineApp;

var vendingMachine = new VendingMachine();

while (true)
{
    Console.WriteLine("PLEASE ENTER 1p, 2p, 5p, 10p, 20p, 50p, £1 OR £2");
    if (vendingMachine.ValueInCredit > 0)
        Console.WriteLine($"CREDIT: {vendingMachine.ValueInCredit.ToString("C")}");

    string potentialCoin = Console.ReadLine();
    vendingMachine.InsertCoin(potentialCoin);
}

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

public class Slot
{
    public Slot(int id, string name, double price, int quantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }
    public int Id { get; }
    public string Name { get; }
    public double Price { get; }
    public int Quantity { get; private set; }
}