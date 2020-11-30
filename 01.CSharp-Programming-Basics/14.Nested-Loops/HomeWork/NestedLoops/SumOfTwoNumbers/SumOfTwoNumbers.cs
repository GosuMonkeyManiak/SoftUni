using System;

namespace SumOfTwoNumbers
{
    class SumOfTwoNumbers
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());

            bool flag = false;

            int num1 = 0;
            int num2 = 0;
            int count = 0;

            for (int i = start; i <= end; i++)
            {
                for (int j = start; j <= end; j++)
                {
                    count++;
                    if (i + j == magicNum)
                    {
                        num1 = i;
                        num2 = j;
                        flag = true;
                        break;
                    }
                }

                if (flag)
                {
                    break;
                }
            }

            if (flag)
            {
                Console.WriteLine($"Combination N:{count} ({num1} + {num2} = {magicNum})");
            }
            else
            {
                Console.WriteLine($"{count} combinations - neither equals {magicNum}");
            }
        }
    }
}
