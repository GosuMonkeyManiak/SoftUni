using System;
using System.Linq;

namespace TopIntegers
{
    class TopIntegers
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string topIntegers = string.Empty;
            bool isTopInteger = true;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNum = numbers[i];

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] >= currentNum)
                    {
                        isTopInteger = false;
                        break;
                    }
                }

                if (isTopInteger)
                {
                    topIntegers += currentNum + " ";
                }

                isTopInteger = true;
            }

            Console.WriteLine(topIntegers);
        }
    }
}
