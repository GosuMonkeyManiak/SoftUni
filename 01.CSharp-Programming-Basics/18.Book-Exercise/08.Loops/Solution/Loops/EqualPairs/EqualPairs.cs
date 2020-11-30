using System;

namespace EqualPairs
{
    class EqualPairs
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sumFirstPair = 0;
            int curretnSumPair = 0;

            int maxReamin = 0;

            for (int i = 1; i <= n; i++)
            {
                if (i == 1)
                {
                    int firstNum = int.Parse(Console.ReadLine());
                    int secondNum = int.Parse(Console.ReadLine());
                    sumFirstPair = firstNum + secondNum;
                }
                else
                {
                    int currentNum1 = int.Parse(Console.ReadLine());
                    int currentNum2 = int.Parse(Console.ReadLine());
                    curretnSumPair = currentNum1 + currentNum2;
                }

                if (i > 1)
                {
                    int currentRemain = Math.Abs(sumFirstPair - curretnSumPair);

                    if (currentRemain > maxReamin)
                    {
                        maxReamin = currentRemain;
                    }

                    sumFirstPair = curretnSumPair;
                }
            }

            if (maxReamin == 0)
            {
                Console.WriteLine($"Yes, value={sumFirstPair}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={maxReamin}");
            }
        }
    }
}
