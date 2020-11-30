using System;

namespace ExactSumOfNumbers
{
    class ExactSumOfNumbers
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());

            decimal sum = 0M;

            for (int i = 0; i < n; i++)
            {
                decimal number = decimal.Parse(Console.ReadLine());
                sum += number;
            }

            Console.WriteLine(sum);
        }
    }
}
