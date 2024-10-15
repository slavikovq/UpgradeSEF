using SimpleEnemyFightUpgrade.Domain.Room;
// ReSharper disable All

namespace SimpleEnemyFightUpgrade.Domain.Entities;

public class Boss : Enemy
{
    private bool isPhaseTwo;
    public static int MaxHp; 

    public Boss(string name, string style, int hp, int baseDmg) 
        : base(name, style, hp, baseDmg)
    {
        isPhaseTwo = false;
        MaxHp = hp;
    }
    
    public override void Attack(Player player)
    {
        if (hp <= MaxHp / 2 && !isPhaseTwo)
        {
            isPhaseTwo = true;
            BaseDmg *= 2;
            Console.WriteLine($"{name} je v druhe fazi");
        }
        base.Attack(player);
    }
    
    public static Boss CreateFinalBoss()
    {
        return new Boss("Shadow Overlord", "\ud83d\udc79", 200, 5);
    }
}