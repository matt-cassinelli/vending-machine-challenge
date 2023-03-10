namespace VendingMachineApp;

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
    public Product? Dispense()
    {
        if (Quantity > 0)
            return new Product(Name);
        else
            return null;
    }
}