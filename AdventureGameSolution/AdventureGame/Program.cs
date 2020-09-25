using System;
using System.Windows.Input;

namespace AdventureGame
{
    class Program
    {
        static readonly char[,] maze = new char[25, 100];

        static void Main(string[] args)
        {

            var items = Items.MakeItems();

            Player player1 = new Player("Harald", "Dwarf", 120, 10);
            Console.WriteLine(player1.Damage);

            Console.ReadLine();





            Console.ForegroundColor = ConsoleColor.DarkCyan;
            
            MakeMaze();
            PrintMaze();

            int xAxis = 20;
            int yAxis = 20;
            
            Console.CursorVisible = false;

            do
            {
                Console.SetCursorPosition(xAxis, yAxis);
                Console.Write("*");
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (xAxis > 10)
                            {
                                Console.SetCursorPosition(xAxis, yAxis);
                                Console.Write(" ");
                                xAxis--;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (xAxis < 105)
                            {
                                Console.SetCursorPosition(xAxis, yAxis);
                                Console.Write(" ");
                                xAxis++;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (yAxis > 3)
                            {
                                Console.SetCursorPosition(xAxis, yAxis);
                                Console.Write(" ");
                                yAxis--;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (yAxis < 25)
                            {
                                Console.SetCursorPosition(xAxis, yAxis);
                                Console.Write(" ");
                                yAxis++;
                            }
                            break;
                    }
                }
            } while (true);


           


        }

        /*
             0 1 2 3 4 5 6 7 8 9  x
          0  # # # # # # # # # #
          1  # 1 2 3 4 5 6 7 8 #
          2  # 1 2 3 4 5 6 7 8 #
          3  # # # # # # # # # #
          y
        */

        static void MakeMaze()
        {
            for (int i = 0; i < 100; i++)
            {
                maze[0, i] = '\u2588';
                //Console.Write('\u2588');

            }
            for (int i = 1; i < 24; i++)
            {
                maze[i, 0] = '\u2588';
                for (int j = 1; j < 100; j++)
                {
                    maze[i, j] = ' ';
                }
                maze[i, 99] = '\u2588';
            }
            for (int i = 0; i < 100; i++)
            {
                maze[24, i] = '\u2588';
            }
        }

        static void PrintMaze()
        {
            Console.WriteLine("\n");
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                Console.Write("\t");
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
