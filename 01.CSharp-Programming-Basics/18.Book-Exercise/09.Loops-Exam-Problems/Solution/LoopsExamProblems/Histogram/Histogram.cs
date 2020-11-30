using System;

namespace Histogram
{
    class Histogram
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int p1Count = 0;
            int p2Count = 0;
            int p3Count = 0;
            int p4Count = 0;
            int p5Count = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 200)
                {
                    p1Count++;
                }
                else if (number <= 399)
                {
                    p2Count++;
                }
                else if (number <= 599)
                {
                    p3Count++;
                }
                else if (number <= 799)
                {
                    p4Count++;
                }
                else
                {
                    p5Count++;
                }
            }

            Console.WriteLine($"{1.0 * p1Count / n * 100:f2}%");
            Console.WriteLine($"{1.0 * p2Count / n * 100:f2}%");
            Console.WriteLine($"{1.0 * p3Count / n * 100:f2}%");
            Console.WriteLine($"{1.0 * p4Count / n * 100:f2}%");
            Console.WriteLine($"{1.0 * p5Count / n * 100:f2}%");
        }
    }
}
