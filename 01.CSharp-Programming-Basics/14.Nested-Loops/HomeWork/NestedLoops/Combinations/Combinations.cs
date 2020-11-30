using System;

namespace Combinations
{
    class Combinations
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int count = 0;

            for (int x1 = 0; x1 <= 25; x1++)
            {
                for (int x2 = 0; x2 <= 25; x2++)
                {
                    for (int x3 = 0; x3 <= 25; x3++)
                    {
                        if (x1 + x2 + x3 == n)
                        {
                            count++;
                        }
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
