using System;

namespace SquareOfStars
{
    class SquareOfStars
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();

            for (int i = 1; i <= n - 2; i++)
            {
                Console.Write('*');
                for (int k = 1; k <= n - 2; k++)
                {
                    Console.Write(" ");
                }
                Console.Write('*');
                Console.WriteLine();
            }

            for (int i = 1; i <= n; i++)
            {
                Console.Write('*');
            }
        }
    }
}
