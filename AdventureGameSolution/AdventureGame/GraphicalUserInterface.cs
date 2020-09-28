using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class GraphicalUserInterface
    {
        public static int width = 100;

        public static void PrintField()
        {
            //Skriver ut toppen av ramen
            Console.Write("\n\t\u2554");
            for (int i = 0; i < width - 2; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2557");
            
        }
    }
}
