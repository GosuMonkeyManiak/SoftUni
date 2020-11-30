using System;

namespace OddEvenSum
{
    class OddEvenSum
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int OddSum = 0;
            int EvenSum = 0;

            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    EvenSum += num;
                }
                else
                {
                    OddSum += num;
                }
            }

            if (OddSum == EvenSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = {0}",OddSum);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("Diff = {0}",Math.Abs(OddSum - EvenSum));
            }
        }
    }
}
