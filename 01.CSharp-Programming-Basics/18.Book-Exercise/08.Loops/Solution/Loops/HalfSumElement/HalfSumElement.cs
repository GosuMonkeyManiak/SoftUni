using System;

namespace HalfSumElement
{
    class HalfSumElement
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int max = int.MinValue;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number > max)
                {
                    max = number;
                }

                sum += number;
            }

            sum -= max;

            if (sum == max)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {max}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(sum - max)}");
            }
        }
    }
}
