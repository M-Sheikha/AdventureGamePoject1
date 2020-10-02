using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class GUI
    {
        private static int worldHeight = 23;
        private static int worldWidth = 98;
        private static int numberOfAbilities = 6;
        private static int left = 10;
        private static int top = 2;

        

        public static void PrintWorld()
        {
            PrintTopOfFrame();
            PrintSidesOfFrame(worldHeight);
            PrintBottomOfFrame();
            Console.WriteLine("\tPress (C) For Characterpanel");
            Console.WriteLine("\tPress (I) For Inventory");
        }

        public static void PrintInventory(Player player)
        {
            PrintTopOfFrame("INVENTORY");
            PrintSidesOfFrame(player.inventory.Count + 2);
            PrintDividingLine();
            PrintSidesOfFrame(2);
            PrintBottomOfFrame();
        }

        public static void PrintCharacterPanel(Player player)
        {
            PrintTopOfFrame("CHARACTER");
            PrintSidesOfFrame(4);
            PrintDividingLine("ABILITIES");
            PrintSidesOfFrame(numberOfAbilities + 1);
            PrintDividingLine("WEAPON");
            PrintSidesOfFrame(2);
            PrintDividingLine("ARMOR");
            PrintSidesOfFrame(3);
            PrintBottomOfFrame();

            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"{player.Name} the {player.Race} {player.Class}");
            PrintStat("Armor Class", player.ArmorClass);
            PrintStat("Hit Points", player.HitPoints);
            top += 2;

            PrintStat("Strength", player.Strength);
            PrintStat("Dextrerity", player.Dexterity);
            PrintStat("Constitution", player.Constitution);
            PrintStat("Intelligence", player.Intelligence);
            PrintStat("Wisdom", player.Wisdom);
            PrintStat("Charisma", player.Charisma);
            top += 2;

            if (player.gear.Count > 0)
            {
                Console.SetCursorPosition(left, top++);
                if (player.gear[0] is Weapon weapon)
                    Console.Write($"{weapon.Name} +{weapon.Damage} Damage");
                top += 2;

                if (player.gear.Count > 1)
                {
                    for (int i = 1; i < player.gear.Count; i++)
                    {
                        Console.SetCursorPosition(left, top++);
                        if (player.gear[i] is Armor armor)
                            Console.Write($"{armor.Name} {armor.ArmorClass} Armor Class");
                    }
                }
            }
        }

        private static void PrintTopOfFrame()
        {
            Console.Write("\n\t\u2554");
            for (int i = 0; i < worldWidth; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2557");
        }

        private static void PrintTopOfFrame(string text)
        {
            Console.Write($"\n\t\u2554\u2550{text}");
            for (int i = 0; i < worldWidth - text.Length - 1; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2557");
        }

        private static void PrintSidesOfFrame(int height)
        {
            for (int i = 0; i < height; i++)
            {
                Console.Write("\t\u2551");
                for (int j = 0; j < worldWidth; j++)
                    Console.Write(" ");
                Console.WriteLine("\u2551");
            }
        }

        private static void PrintBottomOfFrame()
        {
            Console.Write("\t\u255A");
            for (int i = 0; i < worldWidth; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u255D");
        }

        private static void PrintDividingLine()
        {
            Console.Write("\t\u2560");
            for (int i = 0; i < worldWidth; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2563");
        }

        private static void PrintDividingLine(string text)
        {
            Console.Write($"\t\u2560\u2550{text}");
            for (int i = 0; i < worldWidth - text.Length - 1; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2563");
        }

        private static void PrintStat(string stat, int _stat)
        {
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"{stat}: {_stat}");
        }

    }


}
