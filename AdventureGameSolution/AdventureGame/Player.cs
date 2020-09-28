using System;

namespace AdventureGame
{
    class Player : Entity
    {
        // SPELAREN ============================================================

        // Spelaren ärver från klassen entity men kan även förflytta sig till 
        // skillnad från övriga varelser som står stilla.

        // Spelaren har en väska med plats för föremål och kan plocka upp
        // föremål från spelplanen.

        // Spelaren kan interagera med andra varelser i världen (motståndare)
        // genom att ställa sig på samma position. Då sker ett möte.

        public static void Print(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("*");
        }

        static void PrintEmpty(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }

        public static void Move(ref int x, ref int y)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (x > 10)
                    {
                        PrintEmpty(x, y);
                        x--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (x < 105)
                    {
                        PrintEmpty(x, y);
                        x++;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (y > 3)
                    {
                        PrintEmpty(x, y);
                        y--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (y < 25)
                    {
                        PrintEmpty(x, y);
                        y++;
                    }
                    break;
                case ConsoleKey.I:
                    Console.Clear();
                    GraphicalUserInterface.PrintInventory();
                    Console.ReadLine();
                    Console.Clear();                    
                    GraphicalUserInterface.PrintField();
                    break;
                case ConsoleKey.C:
                    Console.Clear();
                    GraphicalUserInterface.PrintCharacterPanel();
                    Console.ReadLine();
                    Console.Clear();
                    GraphicalUserInterface.PrintField();
                    break;
            }
        }

    }
}
