using System;

namespace SpecialNumbers
{
    class SpecialNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int num = i;
                int currentSum = 0;

                while (num > 0)
                {
                    int digit = num % 10;
                    currentSum += digit;
                    num /= 10;
                }

                bool isSpecial = currentSum == 5 || currentSum == 7 || currentSum == 11;

                Console.WriteLine($"{i} -> {isSpecial}");
            }
        }
    }
}
