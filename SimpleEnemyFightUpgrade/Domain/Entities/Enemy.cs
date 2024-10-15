using SimpleEnemyFightUpgrade.Domain.Room;
// ReSharper disable All

namespace SimpleEnemyFightUpgrade.Domain.Entities;

public class Enemy
{
    public string name;
    public string style;
    public int hp;
    public static int BaseDmg;

    public Enemy(string name, string style, int hp, int baseDmg)
    {
        this.name = name;
        this.style = style;
        this.hp = hp;
        BaseDmg = baseDmg;
    }

    public class Factory
    {
        public static Enemy CreateBlightclaw()
        {
            return new Enemy("Blightclaw", "\ud83d\udc3e", 100, 2);
        }
        public static Enemy CreateScornfang()
        {
            return new Enemy("Scornfang ", "\ud83e\uddb7", 100, 2);
        }
        public static Enemy CreateGrimspire()
        {
            return new Enemy("Grimspire ", "\u2694\ufe0f", 100, 2);
        }
    }
    
    public virtual void Attack(Player player)
    {
        player.Hp -= BaseDmg;
        Console.WriteLine($"Zaútočil na tebe enemy {RoomSystem.CurrentEnemy.name} a ted máš {player.Hp} životů");
    }
}