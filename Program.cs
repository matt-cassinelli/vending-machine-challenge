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
        Console.WriteLine("PLEASE INSERT COIN");

    if (vendingMachine.ProductCollectionTray.Any())
        Console.WriteLine($"PLEASE COLLECT: {vendingMachine.ProductCollectionTray.Select(p => p.Name)}");

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
            Console.Clear();
            Console.WriteLine("SELECT PRODUCT:");
            foreach (var slot in vendingMachine.Slots)
            {
                Console.WriteLine($"{slot.Id}) {slot.Name} {slot.Price.ToString("C")} QTY: {slot.Quantity}");
            }
            int.TryParse(Console.ReadLine(), out var potentialSlotId);
            vendingMachine.SelectProduct(potentialSlotId);
            break;
        case "3":
            break;
        default:
            break;
    }
}