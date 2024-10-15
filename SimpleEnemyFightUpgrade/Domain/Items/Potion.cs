// ReSharper disable All
namespace SimpleEnemyFightUpgrade.Domain.Entities;

public class Potion
{
    public string Name { get; set; }
    public int HealAmount { get; set; }
    public int StrengthBoost { get; set; }

    public Potion(string name, int healAmount, int strengthBoost)
    {
        Name = name;
        HealAmount = healAmount;
        StrengthBoost = strengthBoost;
    }

    public static Potion GenerateRandomPotion()
    {
        Potion[] potions = {
            new Potion("Heal Potion", 30, 0),
            new Potion("Strength Potion", 0, 3)
        };

        Random rand = new Random();
        int randomIndex = rand.Next(potions.Length);
        return potions[randomIndex];
    }
}