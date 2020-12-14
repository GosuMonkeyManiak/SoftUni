using System;
using System.Linq;

namespace MaxSequenceOfEqualElements
{
    class MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int maxCount = 0;
            int currenCount = 1;
            int number = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    currenCount++;
                }
                else
                {
                    if (currenCount > maxCount)
                    {
                        maxCount = currenCount;
                        number = numbers[i];
                    }

                    currenCount = 1;
                }
                if (currenCount > maxCount)
                {
                    maxCount = currenCount;
                    number = numbers[i];
                }
            }

            for (int i = 0; i < maxCount; i++)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
