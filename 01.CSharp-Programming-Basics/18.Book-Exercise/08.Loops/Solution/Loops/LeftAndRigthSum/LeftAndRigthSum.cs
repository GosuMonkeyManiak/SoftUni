using System;

namespace LeftAndRigthSum
{
    class LeftAndRigthSum
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int leftSum = 0;
            int rigthSum = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                leftSum += number;
            }

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                rigthSum += number;
            }

            if (leftSum == rigthSum)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(leftSum - rigthSum)}");
            }
        }
    }
}
