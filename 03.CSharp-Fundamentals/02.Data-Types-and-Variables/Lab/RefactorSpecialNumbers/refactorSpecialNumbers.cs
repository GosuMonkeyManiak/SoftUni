using System;

namespace RefactorSpecialNumbers
{
    class refactorSpecialNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int currentNumber = i;
                int digitsSum = 0;

                while (currentNumber > 0)
                {
                    digitsSum += currentNumber % 10;
                    currentNumber /= 10;
                }

                bool isSpecial = (digitsSum == 5) || (digitsSum == 7) || (digitsSum == 11);

                Console.WriteLine($"{i} -> {isSpecial}");
            }

        }
    }
}
