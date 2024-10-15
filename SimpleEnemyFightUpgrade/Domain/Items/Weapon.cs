// ReSharper disable All
namespace SimpleEnemyFightUpgrade.Domain.Entities;

public class Weapon
{
    public string Name { get; set; }
    public int DamageBoost { get; set; }

    public Weapon(string name, int damageBoost)
    {
        Name = name;
        DamageBoost = damageBoost;
    }

    public static Weapon GenerateRandomWeapon()
    {
        Weapon[] weapons = {
            new Weapon("Meč", 3),
            new Weapon("Sekera", 5),
            new Weapon("Dýka", 2)
        };

        Random rand = new Random();
        int randomIndex = rand.Next(weapons.Length);
        return weapons[randomIndex];
    }
}