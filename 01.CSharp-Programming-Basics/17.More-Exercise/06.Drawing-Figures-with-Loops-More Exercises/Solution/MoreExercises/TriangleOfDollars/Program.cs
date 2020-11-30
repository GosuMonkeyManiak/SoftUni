using System;

namespace TriangleOfDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int row = 0; row < n; row++)
            {
                for (int i = 0; i <= row; i++)
                {
                    Console.Write('$');
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
