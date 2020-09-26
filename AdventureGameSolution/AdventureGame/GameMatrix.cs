using System;

namespace AdventureGame
{
    class GameMatrix
    {
        static readonly char[,] matrix = new char[25, 100];

        public static void Create()
        {
            for (int i = 0; i < 100; i++)
            {
                matrix[0, i] = '\u2588';
            }
            for (int i = 1; i < 24; i++)
            {
                matrix[i, 0] = '\u2588';
                for (int j = 1; j < 100; j++)
                {
                    matrix[i, j] = ' ';
                }
                matrix[i, 99] = '\u2588';
            }
            for (int i = 0; i < 100; i++)
            {
                matrix[24, i] = '\u2588';
            }
        }

        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("\n");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("\t");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
