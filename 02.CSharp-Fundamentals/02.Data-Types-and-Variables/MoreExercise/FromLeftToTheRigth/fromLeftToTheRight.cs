using System;
using System.Linq;

namespace FromLeftToTheRight
{
    class fromLeftToTheRight
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                long[] numbers = Console.ReadLine().Split().Select(long.Parse).ToArray();

                long currentSum = 0;

                if (numbers[0] > numbers[1])
                {
                    long currentNumber = Math.Abs(numbers[0]);
                    currentSum = 0;

                    while (currentNumber > 0)
                    {
                        currentSum += currentNumber % 10;
                        currentNumber /= 10;
                    }
                }
                else
                {
                    long currentNumber = Math.Abs(numbers[1]);
                    currentSum = 0;

                    while (currentNumber > 0)
                    {
                        currentSum += currentNumber % 10;
                        currentNumber /= 10;
                    }
                }

                Console.WriteLine(currentSum);
            }
        }
    }
}
