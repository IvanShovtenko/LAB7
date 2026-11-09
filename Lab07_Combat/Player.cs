public class Player
{
    public string Name { get; }
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }
    public int Gold { get; private set; }
    public int Level { get; private set; } = 1;
    public int Experience { get; private set; }
    public List<Item> Inventory { get; } = new();

    public Player(string name, int maxHealth, int gold)
    {
        Name = name;
        MaxHealth = Math.Max(0, maxHealth);
        Health = MaxHealth;
        Gold = Math.Max(0, gold);
    }

    public void experience(int amount)
    {
        if (amount <= 0) { Console.WriteLine("Error"); return; }

        Experience += amount;
        while (Experience >= Level * 100)
        {
            Experience -= Level * 100;
            Level++;
            MaxHealth += 20;
            Health = MaxHealth;
            Console.WriteLine($"{Name} leveled up to {Level}! Max Health: {MaxHealth}");
        }
    }
    public bool IsAlive() => Health > 0;
    public bool TakeDamage(int damage)
    {
        if (damage <= 0 || !IsAlive()) return false;
        Health = Math.Max(0, Health - damage);
        return true;
    }

    public bool Heal(int amount)
    {
        if (amount <= 0 || !IsAlive() || Health == MaxHealth) return false;
        Health = Math.Min(MaxHealth, Health + amount);
        return true;
    }

    

    public void AddGold(int amount)
    {
        if (amount > 0) Gold += amount;
    }

    public bool SpendGold(int amount)
    {
        if (amount <= 0 || Gold < amount) return false;
        Gold -= amount;
        return true;
    }

    public void AddItem(Item item)
    {
        if (item != null) Inventory.Add(item);
    }

    public void ShowInventory()
    {
        Console.WriteLine("Inventory:");
        if (Inventory.Count == 0) { Console.WriteLine("Empty"); return; }
        for (int i = 0; i < Inventory.Count; i++)
            Console.WriteLine($"{i + 1}. {Inventory[i].Name} - healing: {Inventory[i].HealAmount}, quantity: {Inventory[i].Quantity}");
    }

    public bool UseItem(int index)
    {
        if (index < 0 || index >= Inventory.Count || !IsAlive()) return false;
        Item item = Inventory[index];
        if (item.Quantity <= 0 || Health >= MaxHealth) return false;
        if (!item.UseOne()) return false;
        Heal(item.HealAmount);
        return true;
    }
}
