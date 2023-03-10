using VendingMachineApp;

var slots = new List<Slot>
{
    new Slot(id: 1, name: "Cola", price: 1.00, quantity: 3),
    new Slot(id: 2, name: "Crisps", price: 0.50, quantity : 7),
    new Slot(id: 3, name: "Chocolate", price: 0.65, quantity: 4),
};

var coinsToLoad = new List<Coin>
{
    new Coin("1p"),
    new Coin("2p"),
    new Coin("5p"),
    new Coin("10p"),
    new Coin("20p"),
    new Coin("50p"),
    new Coin("£1"),
    new Coin("£2"),
    new Coin("1p"),
    new Coin("2p"),
    new Coin("5p"),
    new Coin("10p"),
    new Coin("20p"),
    new Coin("50p"),
    new Coin("£1"),
    new Coin("£2")
};

var vendingMachine = new VendingMachine(slots, coinsToLoad);

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
        Console.WriteLine("PLEASE COLLECT ITEMS: " + String.Join(", ", vendingMachine.ProductCollectionTray.Select(p => p.Name)));

    if (vendingMachine.CoinReturnTray.Any())
        Console.WriteLine("PLEASE COLLECT COINS: " + String.Join(", ", vendingMachine.CoinReturnTray.Select(c => c.Name)));

    string chosenOption = Console.ReadLine();

    switch (chosenOption)
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

            vendingMachine.Slots.ForEach(s =>
                Console.WriteLine($"{s.Id}) {s.Name} {s.Price.ToString("C")} QTY: {s.Quantity}"));

            int.TryParse(Console.ReadLine(), out var potentialSlotId);
            vendingMachine.SelectProduct(potentialSlotId);
            break;
        case "3":
            break;
        default:
            break;
    }
}