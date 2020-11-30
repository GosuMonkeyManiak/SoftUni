using System;

namespace MaxNumber
{
    class MaxNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int count = 0;
            int max = int.MinValue;

            while (count < n)
            {
                int num = int.Parse(Console.ReadLine());

                if (num > max)
                {
                    max = num;
                }

                count++;
            }
            Console.WriteLine(max);
        }
    }
}
