using System;

namespace AverageNumber
{
    class AverageNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double sum = 0.0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;
            }

            Console.WriteLine($"{sum / n:f2}");
        }
    }
}
