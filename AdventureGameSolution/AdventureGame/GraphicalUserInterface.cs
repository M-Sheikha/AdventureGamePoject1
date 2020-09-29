using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class GraphicalUserInterface
    {
        public static int hight;
        public static int width = 100;
        

        public static void PrintField()
        {
            hight = 25;
            //Skriver ut toppen av ramen
            Console.Write("\n\t\u2554");
            for (int i = 0; i < width - 2; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2557");

            //Sidor av ramen
            for (int i = 0; i < hight - 2; i++)
            {
                Console.Write("\t\u2551");
                for (int j = 0; j < width - 2; j++)                
                    Console.Write(" ");                
                Console.WriteLine("\u2551");
            }

            //Skriver ut botten av ramen
            Console.Write("\t\u255A");
            for (int i = 0; i < width - 2; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u255D");

        }

        public static void PrintInventory()
        {
            hight = Player.inventory.Count + 2;
            //Skriver ut toppen av ramen
            Console.Write("\n\t\u2554\u2550INVENTORY");
            for (int i = 0; i < width - 12; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2557");

            //Sidor av ramen
            for (int i = 0; i < hight; i++)
            {
                Console.Write("\t\u2551");
                for (int j = 0; j < width - 2; j++)
                    Console.Write(" ");
                Console.WriteLine("\u2551");
            }

            //avgränsande linje
            Console.Write("\t\u2560");
            for (int i = 0; i < width - 2; i++)
            {
                Console.Write("\u2550");
            }
            Console.WriteLine("\u2563");

            //sidor på ramen
            for (int i = 0; i < 2; i++)
            {
                Console.Write("\t\u2551");
                for (int j = 0; j < width - 2; j++)
                    Console.Write(" ");
                Console.WriteLine("\u2551");
            }

            //Skriver ut botten av ramen
            Console.Write("\t\u255A");
            for (int i = 0; i < width - 2; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u255D");

        }

        public static void PrintCharacterPanel()
        {
            //skriver ut toppen av ramen
            Console.Write("\n\t\u2554\u2550CHARACTER");
            for (int i = 0; i < width - 12; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2557");

            //skriver ut sidorna av ramen
            //Den första botten av den inre ramen ska komma på sjätte raden efter toppen
            //Sidorna för namn m.m.
            for (int i = 0; i < 5; i++)
            {
                Console.Write("\t\u2551");
                for (int j = 0; j < width - 2; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("\u2551");
            }
            //Skriver ut en linje med text abilities
            Console.Write("\t\u2560\u2550ABILITIES");
            for (int i = 0; i < width - 12; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2563");
            //Skriver ut sidorna för abilities
            for (int i = 0; i < 7; i++)
            {
                Console.Write("\t\u2551");
                for (int j = 0; j < width - 2; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("\u2551");
            }
            //Skriver ut en linje med text gear
            Console.Write("\t\u2560\u2550GEAR");
            for (int i = 0; i < width - 7; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2563");
            //skriver ut sidorna för gear
            for (int i = 0; i < Player.gear.Count + 1; i++)
            {
                Console.Write("\t\u2551");
                for (int j = 0; j < width - 2; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("\u2551");
            }

            //Skriver ut botten av ramen
            Console.Write("\t\u255A");
            for (int i = 0; i < width - 2; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u255D");
        }

        

    }


}
