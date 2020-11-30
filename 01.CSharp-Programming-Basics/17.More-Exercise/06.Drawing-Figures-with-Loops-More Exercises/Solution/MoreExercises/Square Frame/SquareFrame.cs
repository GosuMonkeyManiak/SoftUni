using System;

namespace SquareFrame
{
    class SquareFrame
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < 1; i++)
            {
                Console.Write('+');
                Console.Write(" ");
                for (int j = 0; j < n - 2; j++)
                {
                    Console.Write('-');
                    Console.Write(" ");
                }
                Console.Write('+');
                Console.WriteLine();
            }

            for (int i = 0; i < n - 2; i++)
            {
                Console.Write('|');
                Console.Write(" ");

                for (int k = 0; k < n - 2; k++)
                {
                    Console.Write('-');
                    Console.Write(" ");
                }
                Console.Write('|');
                Console.WriteLine();
            }

            for (int i = 0; i < 1; i++)
            {
                Console.Write('+');
                Console.Write(" ");
                for (int j = 0; j < n - 2; j++)
                {
                    Console.Write('-');
                    Console.Write(" ");
                }

                Console.Write('+');
            }
        }
    }
}
