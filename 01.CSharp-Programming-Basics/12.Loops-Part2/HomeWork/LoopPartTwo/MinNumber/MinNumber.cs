using System;

namespace MinNumber
{
    class MinNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int count = 0;
            int min = int.MaxValue;

            while (count < n)
            {
                int num = int.Parse(Console.ReadLine());

                if (num < min)
                {
                    min = num;
                }

                count++;
            }

            Console.WriteLine(min);
        }
    }
}
