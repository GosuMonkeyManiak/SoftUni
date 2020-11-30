using System;

namespace TriangleOf55Stars
{
    class TriangleOf55Stars
    {
        static void Main(string[] args)
        {
            for (int row = 1; row <= 10; row++)
            {
                for (int i = 1; i <= row; i++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
