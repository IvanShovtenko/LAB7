public class Enemy
{
    private static readonly Random Random = new();

    public string Name { get; }
    public int Health { get; private set; }
    public int Damage { get; }
    public string AttackType { get; }
    public int DefenseChance { get; }
    public int EscapeChance { get; }
    public int GoldReward { get; }
    public bool IsDefending { get; private set; }

    public Enemy(string name, int health, int damage,
                 string attackType = "Normal", int defenseChance = 0,
                 int escapeChance = 0, int goldReward = 5)
    {
        Name = name;
        Health = Math.Max(0, health);
        Damage = Math.Max(0, damage);
        AttackType = attackType;
        DefenseChance = Math.Clamp(defenseChance, 0, 100);
        EscapeChance = Math.Clamp(escapeChance, 0, 100);
        GoldReward = Math.Max(0, goldReward);
    }
    public bool IsAlive() => Health > 0;

    public bool TakeDamage(int damage)
    {
        if (damage <= 0 || !IsAlive()) return false;
        int actualDamage = IsDefending ? Math.Max(1, damage / 2) : damage;
        IsDefending = false;
        Health = Math.Max(0, Health - actualDamage);
        return true;
    }

    public bool TryDefend()
    {
        IsDefending = Random.Next(100) < DefenseChance;
        return IsDefending;
    }

    public bool TryEscape() => Random.Next(100) < EscapeChance;
}
