using System;

class Program
{
    static void Main(String[] args)
    {
        Random random = new Random();
        Trainer trainer = new Trainer("Ash");
        Monster monster = new Monster("Pikachu", 100, 20);
        Monster enemy = new Monster("Mewtwo", 80, 15);

        Console.WriteLine("=== WELCOME TO THE MONSTER BATTLE ARENA ===");
        Console.WriteLine($"A wild {enemy.Name} (HP: {enemy.Health}) appears!\n");

        int round = 1;

        while (monster.Health > 0 && enemy.Health > 0)
        {
            Console.WriteLine($"\n--- Round {round} ---");
            Console.WriteLine($"Your Monster: {monster.Name} (HP: {monster.Health}/{monster.MaxHealth})");
            Console.WriteLine($"Enemy Monster: {enemy.Name} (HP: {enemy.Health}/{enemy.MaxHealth})\n");

            // PLAYER LOGIC
            Console.WriteLine("Choose your action:");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Defend");
            Console.WriteLine("3. Heal");
            string action = Console.ReadLine();
            Console.WriteLine();

            switch (action)
            {
                case "1":
                    int damage = monster.Attack(enemy, random);
                    Console.WriteLine($"{monster.Name} attacks {enemy.Name} for {damage} damage!");
                    break;
                case "2":
                    monster.IsDefending = true;
                    Console.WriteLine($"{monster.Name} is defending!");
                    break;
                case "3":
                    int healed = monster.Heal(random);
                    Console.WriteLine($"{monster.Name} healed themselves for {healed} HP!");
                    break;
                default:
                    Console.WriteLine($"Invalid choice! {trainer.Name} stumbled around and missed their turn!");
                    break;
            }

            // ENEMY LOGIC 

            if (enemy.Health > 0)
            {
                int enemyAction = random.Next(1, 4);
                switch (enemyAction)
                {
                    case 1:
                    case 2:
                    int damage = enemy.Attack(monster, random);
                        Console.WriteLine($"{enemy.Name} attacks {monster.Name} for {damage} damage!");
                        break;
                    case 3:
                        int healed = enemy.Heal(random);
                        Console.WriteLine($"{enemy.Name} recovers their energy and heals for {healed} HP!");
                        break;
                }
            }


            round++;
        }
        
        // Determine the Winner
        Console.WriteLine("\n=== THE BATTLE IS OVER ===");
        if (monster.Health > 0)
        {
            Console.WriteLine($"{monster.Name} has defeated {enemy.Name}! YOU WIN {trainer.Name.ToUpper()}!");
        }
        else
        {
            Console.WriteLine($"{enemy.Name} has defeated {monster.Name}! GAME OVER!");
        }
    }
}