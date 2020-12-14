using System;
using System.Linq;

namespace EqualSums
{
    class EqualSums
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            if (numbers.Length == 1)
            {
                Console.WriteLine(0);
                return;
            }

            bool isEqual = false;
            int index = -1;

            for (int curr = 0; curr < numbers.Length; curr++)
            {
                int rigthSum = 0;

                for (int rigth = curr + 1; rigth < numbers.Length; rigth++)
                {
                    rigthSum += numbers[rigth];
                }

                int leftSum = 0;

                for (int left = curr - 1; left >= 0; left--)
                {
                    leftSum += numbers[left];
                }

                if (rigthSum == leftSum)
                {
                    isEqual = true;
                    index = curr;
                    break;
                }
            }

            if (isEqual)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
