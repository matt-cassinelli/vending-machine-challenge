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