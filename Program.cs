// UI Layer

using VendingMachineApp;

var vendingMachine = new VendingMachine();

while (true)
{
    Console.Clear();
    Console.WriteLine("1) INSERT COIN");
    Console.WriteLine("2) SELECT PRODUCT");
    Console.WriteLine("3) RETURN MY COINS");
    Console.WriteLine();
    if (vendingMachine.ValueInCredit > 0)
        Console.WriteLine($"CREDIT: {vendingMachine.ValueInCredit.ToString("C")}");
    else
        Console.WriteLine("INSERT COIN");

    string input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.Clear();
            Console.WriteLine("PLEASE ENTER 1p, 2p, 5p, 10p, 20p, 50p, £1 OR £2");
            string potentialCoin = Console.ReadLine();
            vendingMachine.InsertCoin(potentialCoin);
            break;
        case "2":
            break;
        case "3":
            break;
        default:
            break;
    }
}