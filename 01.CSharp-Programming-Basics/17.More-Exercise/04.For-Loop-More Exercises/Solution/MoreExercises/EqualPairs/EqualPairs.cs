using System;

namespace EqualPairs
{
    class EqualPairs
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int num = 0;
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int sum1 = 0;
            int sum2 = 0;
            int diff = 0;

            for (int i = 1; i <= n; i++)
            {
                if (i == 1)
                {
                    num = int.Parse(Console.ReadLine());
                    num1 = int.Parse(Console.ReadLine());
                    sum1 = num + num1;
                    
                }
                else
                {
                    num2 = int.Parse(Console.ReadLine());
                    num3 = int.Parse(Console.ReadLine());
                    sum2 = num2 + num3;

                    if (Math.Abs(sum1 - sum2) > diff)
                    {
                        diff = Math.Abs(sum1 - sum2);
                    }

                    sum1 = sum2;
                }
            }

            if (diff > 0)
            {
                Console.WriteLine($"No, maxdiff={diff}");
            }
            else
            {
                Console.WriteLine($"Yes, value={sum1}");
            }
        }
    }
}
