using System;
using SimpleEnemyFightUpgrade.Domain;
using SimpleEnemyFightUpgrade.Domain.Commands;
using SimpleEnemyFightUpgrade.Domain.Entities;
using SimpleEnemyFightUpgrade.Domain.Room;
// ReSharper disable All
#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace SimpleEnemyFightUpgrade
{
    class Program
    {
        static void Main(string[] args)
        {
            GameArea.CreateGameArray();

            Player Cat = new Player("Shadowstride", "\ud83d\ude3d", 100, 5);
            GameArea.DrawPlayer(Cat);
            RoomSystem.RoomStart(RoomSystem.RoomCount);
            GameArea.DrawGameArray();
            
            while (Cat.Hp > 0)
            {
                Console.WriteLine("Zadej příkaz (move, attack, search, use potion):");
                string cmd = Console.ReadLine().ToLower().Trim();
                CommandFunction.ConsoleInput(cmd, Cat);
                GameArea.DrawGameArray();
            }
            
            Console.WriteLine("Konec hry!");
        }
    }
}