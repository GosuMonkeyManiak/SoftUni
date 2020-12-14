using System;

namespace StrongNumber
{
    class Strong
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int temp = number;

            int sum = 0;

            while (true)
            {
                int currentNumber = number % 10;
                number /= 10;

                if (number <= 0 && currentNumber <= 0)
                {
                    if (temp == sum)
                    {
                        Console.WriteLine("yes");
                    }
                    else
                    {
                        Console.WriteLine("no");
                    }
                    break;
                }

                int currentSum = 1;

                for (int i = 1; i <= currentNumber; i++)
                {
                    currentSum *= i;
                }

                sum += currentSum;
                currentSum = 1;
            }
        }
    }
}
