using System;

namespace DivideWithoutRemainder
{
    class DivideWithoutRemainder
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double p1Count = 0.0;
            double p2Count = 0.0;
            double p3Count = 0.0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num % 2 == 0)
                {
                    p1Count++;
                }
                if (num % 3 == 0)
                {
                    p2Count++;
                }
                if (num % 4 == 0)
                {
                    p3Count++;
                }
            }

            double p1 = p1Count / n * 100;
            double p2 = p2Count / n * 100;
            double p3 = p3Count / n * 100;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
        }
    }
}
