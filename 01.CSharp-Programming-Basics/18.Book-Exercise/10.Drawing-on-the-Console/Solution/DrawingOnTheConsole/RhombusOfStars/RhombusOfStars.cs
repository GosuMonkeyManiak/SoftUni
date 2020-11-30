using System;

namespace RhombusOfStars
{
    class RhombusOfStars
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int support = n;

            if (n == 1)
            {
                Console.WriteLine("*");
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int k = 1; k <= n - i; k++)
                {
                    Console.Write(" ");
                }

                Console.Write("*");

                for (int j = 1; j < i; j++)
                {
                    Console.Write(" *");
                }
                Console.WriteLine();
            }

            support -= 2;

            for (int m = 1; m <= n - 1; m++)
            {
                for (int k = m; k > 0; k--)
                {
                    Console.Write(" ");
                }

                Console.Write("*");

                for (int i = 1; i <= support; i++)
                {
                    Console.Write(" *");
                }

                Console.WriteLine();

                support -= 1;
            }
        }
    }
}
