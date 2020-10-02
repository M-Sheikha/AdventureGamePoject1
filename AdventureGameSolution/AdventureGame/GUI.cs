using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class GUI
    {
        private static int worldHeight = 23;
        private static int worldWidth = 99;
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

        public static void CharacterPanel(Player player)
        {
            left = 10;
            top = 2;
            Console.Clear();
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

            if (player.weapon.Count > 0)
            {
                Console.SetCursorPosition(left, top++);
                Console.Write($"{player.weapon[0].Name} +{player.weapon[0].Damage} Damage");
            }
            else
                top++;
            top += 2;

            if (player.armor.Count > 0)
            {
                foreach (var item in player.armor)
                {
                    Console.SetCursorPosition(left, top++);
                    Console.Write($"{item.Name} {item.ArmorClass} Armor Class");
                }
            }
            Console.ReadKey();
            Console.Clear();
            GUI.PrintWorld();
        }

        public static void PrintEncounter()
        {
            left = 10;
            top = 2;

            PrintTopOfFrameWithDivider("ENCOUNTER");
            PrintSidesOfFrameWithDivider(1);
            PrintDividingLineWithDivider();
            PrintSidesOfFrame(10);
            PrintBottomOfFrame();

            Console.SetCursorPosition(left, top);


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

        private static void PrintTopOfFrameWithDivider(string text)
        {
            Console.Write($"\n\t\u2554\u2550{text}");
            for (int i = 0; i < worldWidth / 2 - text.Length - 1; i++)
                Console.Write("\u2550");
            Console.Write("\u2566");
            for (int i = 0; i < 49; i++)
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

        private static void PrintSidesOfFrameWithDivider(int height)
        {
            for (int i = 0; i < height; i++)
            {
                Console.Write("\t\u2551");
                for (int j = 0; j < worldWidth / 2; j++)
                    Console.Write(" ");
                Console.Write("\u2551");
                for (int j = 0; j < worldWidth / 2; j++)
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

        private static void PrintDividingLineWithDivider()
        {
            Console.Write($"\t\u2560");
            for (int i = 0; i < worldWidth / 2; i++)
                Console.Write("\u2550");
            Console.Write("\u2569");
            for (int i = 0; i < worldWidth / 2; i++)
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
