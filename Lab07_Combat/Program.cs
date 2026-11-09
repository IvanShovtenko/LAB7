class Program
{
    static readonly Random random = new();

    static void Main()
    {
        Console.WriteLine("choose task 1-9: ");
        if (!int.TryParse(Console.ReadLine(), out int task) || task < 1 || task > 9)
        {
            Console.WriteLine("Error1");
            return;
        }

        switch (task)
        {
            case 1: Task1(); break;
            case 2: Task2(); break;
            case 3: Task3(); break;
            case 4: Task4(); break;
            case 5: Task5(); break;
            case 6: Task6(); break;
            case 7: Task7(); break;
            case 8: Task8(); break;
            case 9: Task9(); break;
        }
    }

    static void Task1()
    {
        Player player = new("Hero", 100, 20);
        int[] gains = { 30, 70, 250 };
        foreach (int xp in gains)
        {
            player.AddExperience(xp);
            Console.WriteLine($"Level: {player.Level}, XP: {player.Experience}, HP: {player.Health}/{player.MaxHealth}");
        }
    }

    static void Task2()
    {
        Player player = new("Hero", 100, 0);
        Enemy enemy = new("Enemy", 30, 8);
        Console.WriteLine($"Player damage 0: {player.TakeDamage(0)}");
        Console.WriteLine($"Player damage -5: {player.TakeDamage(-5)}");
        Console.WriteLine($"Player damage 20: {player.TakeDamage(20)}");
        Console.WriteLine($"Player heal 0: {player.Heal(0)}");
        Console.WriteLine($"Player heal -5: {player.Heal(-5)}");
        Console.WriteLine($"Enemy damage 10: {enemy.TakeDamage(10)}");
        enemy.TakeDamage(100);
        Console.WriteLine($"Damage by defeated enemy: {enemy.TakeDamage(5)}");
        Console.WriteLine($"HP: player = {player.Health}, enem y= {enemy.Health}");
    }

    static void Task3()
    {
        Player p1 = new("P", 100, 10);
        Player p2 = new("P1", 120, 15);
        Enemy goblin = new("E", 30, 5);
        Enemy orc = new("E1", 70, 12);

        goblin.TakeDamage(10);
        p1.TakeDamage(20);

        Console.WriteLine($"{p1.Name}: {p1.Health} HP; {p2.Name}: {p2.Health} HP");
        Console.WriteLine($"{goblin.Name}: {goblin.Health} HP; {orc.Name}: {orc.Health} HP");
    }

    static List<Enemy> CreateEnemies() => new()
    {
        new Enemy("Goblin", 30, 7),
        new Enemy("Bat", 20, 5),
        new Enemy("Orc", 70, 12),
        new Enemy("Skeleton", 40, 9),
        new Enemy("Troll", 100, 15)
    };

    static void Task4()
    {
        List<Enemy> enemies = CreateEnemies();
        int totalHp = 0, defeated = 0;
        Enemy? strongest = null;

        foreach (Enemy enemy in enemies)
        {
            Console.WriteLine($"{enemy.Name}: {enemy.Health} HP");
            totalHp += enemy.Health;
            if (!enemy.IsAlive()) defeated++;
            else Console.WriteLine($"Alive: {enemy.Name}");
            if (strongest == null || enemy.Health > strongest.Health) strongest = enemy;
        }

        
    }

