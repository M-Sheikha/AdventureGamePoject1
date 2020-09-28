using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class GraphicalUserInterface
    {
        public static int hight = 25;
        public static int width = 100;
        

        public static void PrintField()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
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
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            //Skriver ut toppen av ramen
            Console.Write("\n\t\u2554\u2550INVENTORY");
            for (int i = 0; i < width - 12; i++)
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
    }
}
