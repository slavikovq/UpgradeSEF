using SimpleEnemyFightUpgrade.Domain.Entities;
// ReSharper disable All

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace SimpleEnemyFightUpgrade.Domain;

public class GameArea
{
    public static string[,] GameArray;
    private static int GameArraySize = 9;

    public static void CreateGameArray()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        GameArray = new string[GameArraySize, GameArraySize];
        for (int i = 0; i < GameArraySize; i++)
        {
            for (int j = 0; j < GameArraySize; j++)
            {
                if (i == 0 || j == 0 || i == GameArraySize - 1 || j == GameArraySize - 1)
                {
                    GameArray[i, j] = "\ud83d\udcae";
                }
                else
                {
                    GameArray[i, j] = "  ";
                }
            }
        }
    }

    public static void DrawPlayer(Player player)
    {
        GameArray[2, 4] = player.Style;
    }

    public static void DrawGameArray()
    {
        for (int i = 0; i < GameArraySize; i++)
        {
            for (int j = 0; j < GameArraySize; j++)
            {
                Console.Write(GameArray[i, j] + "  ");
            }
            Console.WriteLine();
        }
    }
    
}