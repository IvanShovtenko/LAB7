public class Item
{
    public string Name { get; }
    public int HealAmount { get; }
    public int Quantity { get; private set; }

    public Item(string name, int healAmount, int quantity)
    {
        Name = name;
        HealAmount = Math.Max(0, healAmount);
        Quantity = Math.Max(0, quantity);
    }

    public bool UseOne()
    {
        if (Quantity <= 0) return false;
        Quantity--;
        return true;
    }
}
