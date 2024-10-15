using SimpleEnemyFightUpgrade.Domain.Entities;
using SimpleEnemyFightUpgrade.Domain.Room;
// ReSharper disable All
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

namespace SimpleEnemyFightUpgrade.Domain.Commands;

public class CommandFunction
{
    public static void ConsoleInput(string cmd, Player player)
    {
        Console.Clear();

        switch (cmd)
        {
            case "move":
                RoomSystem.RoomCount++;
                RoomSystem.RoomStart(RoomSystem.RoomCount);
                break;

            case "attack":
                if (RoomSystem.CurrentEnemy != null)
                {
                    while (player.Hp > 0 && RoomSystem.CurrentEnemy.hp > 0)
                    {
                        player.Attack(RoomSystem.CurrentEnemy);
                        RoomSystem.CurrentEnemy.Attack(player);
                    }
                    if (RoomSystem.CurrentEnemy.hp <= 0)
                    {
                        Console.WriteLine($"Porazil jsi {RoomSystem.CurrentEnemy.name}!");
                        RoomSystem.CurrentEnemy = null;
                    }
                }
                else
                {
                    Console.WriteLine("Není zde žádný nepřítel k útoku.");
                }
                break;

            case "use potion":
                if (RoomSystem.CurrentPotion != null)
                {
                    player.Hp += RoomSystem.CurrentPotion.HealAmount;
                    player.Damage += RoomSystem.CurrentPotion.StrengthBoost;
                    Console.WriteLine($"Použil jsi {RoomSystem.CurrentPotion.Name}. Zdraví: {player.Hp}, Poškození: {player.Damage}");
                    RoomSystem.CurrentPotion = null;
                }
                else
                {
                    Console.WriteLine("Nemáš žádný lektvar k použití.");
                }
                break;

            case "search":
                RoomSystem.RoomStart(RoomSystem.RoomCount);
                break;

            default:
                Console.WriteLine("Neplatný příkaz");
                break;
        }
    }
}
