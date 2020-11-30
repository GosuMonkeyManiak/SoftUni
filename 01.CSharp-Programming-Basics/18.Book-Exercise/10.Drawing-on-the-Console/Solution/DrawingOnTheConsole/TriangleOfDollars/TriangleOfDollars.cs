using System;

namespace TriangleOfDollars
{
    class TriangleOfDollars
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (i == 1)
                {
                    Console.Write('$');
                    Console.WriteLine();
                }
                else
                {
                    Console.Write('$');
                    for (int j = 1; j <= i - 1; j++)
                    {
                        Console.Write(" $");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
