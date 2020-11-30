using System;

namespace LeftAndRightSum
{
    class LeftAndRightSum
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                leftSum += num;
            }

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                rightSum += num;
            }

            if (leftSum == rightSum)
            {
                Console.WriteLine("Yes, sum = {0}",leftSum);
            }
            else
            {
                Console.WriteLine("No, diff = {0}",Math.Abs(leftSum - rightSum));
            }
        }
    }
}
