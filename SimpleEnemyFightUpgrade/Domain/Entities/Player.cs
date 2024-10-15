// ReSharper disable All
namespace SimpleEnemyFightUpgrade.Domain.Entities;

public class Player
{
    public string Name;
    public string Style;
    public int Hp;
    public int Damage;
    public int MaxHp;

    public Player(string name, string style, int hp, int damage)
    {
        Name = name;
        Style = style;
        Hp = hp;
        Damage = damage;
        MaxHp = hp;
    }

    public void Attack(Enemy enemy)
    {
        enemy.hp -= Damage;
        Console.WriteLine($"Zaútočil jsi na enemy {enemy.name} a ted má {enemy.hp} životů");
    }
}