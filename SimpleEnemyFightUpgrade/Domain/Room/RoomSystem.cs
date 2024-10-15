using SimpleEnemyFightUpgrade.Domain.Entities;
// ReSharper disable All
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace SimpleEnemyFightUpgrade.Domain.Room;

public class RoomSystem
{
    public static Enemy CurrentEnemy;
    public static int RoomCount = 1;
    public static Weapon CurrentWeapon;
    public static Potion CurrentPotion;
    public static bool ChestOpened = false;

    public static void RoomStart(int RoomStartCount)
    {
        Random rand = new Random();
        if (RoomCount == 5)
        {
            CurrentEnemy = Boss.CreateFinalBoss();
            GameArea.GameArray[4, 4] = CurrentEnemy.style;
            Console.WriteLine($"Narazil jsi na bosse: {CurrentEnemy.name}");
        }
        else
        {
            if (rand.Next(100) < 60)
            {
                CurrentEnemy = GenerateRandomEnemy(rand);
                GameArea.GameArray[4, 4] = CurrentEnemy.style;
                Console.WriteLine($"Narazil jsi na nepřítele: {CurrentEnemy.name}");
            }
            else
            {
                ChestOpened = true;
                if (rand.Next(2) == 0)
                {
                    CurrentWeapon = Weapon.GenerateRandomWeapon();
                    Console.WriteLine($"Našel jsi zbraň: {CurrentWeapon.Name} (Damage +{CurrentWeapon.DamageBoost})");
                }
                else
                {
                    CurrentPotion = Potion.GenerateRandomPotion();
                    Console.WriteLine($"Našel jsi lektvar: {CurrentPotion.Name} (Heal {CurrentPotion.HealAmount}, Síla +{CurrentPotion.StrengthBoost})");
                }
            }
        }
    }

    private static Enemy GenerateRandomEnemy(Random rand)
    {
        Enemy[] enemyTypes = {
            Enemy.Factory.CreateBlightclaw(),
            Enemy.Factory.CreateScornfang(),
            Enemy.Factory.CreateGrimspire()
        };

        int randomIndex = rand.Next(enemyTypes.Length);
        return enemyTypes[randomIndex];
    }
}