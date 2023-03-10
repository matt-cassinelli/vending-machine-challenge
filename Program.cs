using VendingMachineApp;

var vendingMachine = new VendingMachine();

while (true)
{
    Console.WriteLine("PLEASE ENTER 1p, 2p, 5p, 10p, 20p, 50p, £1 OR £2");
    string potentialCoin = Console.ReadLine();
    vendingMachine.InsertCoin(potentialCoin);
}

public class VendingMachine
{
    private List<Coin> _coinsInCredit = new List<Coin>();
    public double ValueInCredit => _coinsInCredit.Select(c => c.Value).Sum();

    public void InsertCoin(string name)
    {
        _coinsInCredit.Add(new Coin(name));
    }
}