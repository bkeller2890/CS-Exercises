class Monster
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int AttackPower { get; set; }
    public bool IsDefending { get; set; }



    public Monster(string name, int maxHealth, int attackPower)
    {
        Name = name;
        MaxHealth = maxHealth;
        Health = maxHealth;
        AttackPower = attackPower;
    }

    public int Attack(Monster enemy, Random random)
    {
        int variance = random.Next(-3, 4);
        int damage = AttackPower + variance;

        if (enemy.IsDefending)
        {
            damage /= 2;
            enemy.IsDefending = false;
            Console.WriteLine($"{enemy.Name} braced for the impact and blocked half the damage!");

        }

        if (damage < 0) damage = 0;

        enemy.Health -= damage;
        return damage;
    }

    public int Heal(Random random)
    {
        int healAmount = random.Next(10, 21);
        Health += healAmount;
        if (Health > MaxHealth) Health = MaxHealth;
        return healAmount;
    }

}