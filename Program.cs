var vendingMachine = new VendingMachine();

while (true)
{
    Console.WriteLine("PLEASE ENTER 1p, 2p, 5p, 10p, 20p, 50p, £1 OR £2");
    string potentialCoin = Console.ReadLine();
    vendingMachine.InsertCoin(potentialCoin);
}

public class VendingMachine
{
    public List<string> CoinsInCredit = new List<string>();

    public void InsertCoin(string name)
    {
        CoinsInCredit.Add(name);
    }
}