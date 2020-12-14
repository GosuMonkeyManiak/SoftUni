using System;
using System.Linq;

namespace ZigZagArray
{
    class ZigZagArray
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] firstArr = new int[n];
            int[] secondArr = new int[n];

            int Count = 0;

            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    string[] input = Console.ReadLine().Split().ToArray();
                    secondArr[Count] = int.Parse(input[0]);
                    firstArr[Count] = int.Parse(input[1]);
                    Count++;
                }
                else
                {
                    string[] input = Console.ReadLine().Split().ToArray();
                    firstArr[Count] = int.Parse(input[0]);
                    secondArr[Count] = int.Parse(input[1]);
                    Count++;
                }
            }

            Console.WriteLine(string.Join(" ",firstArr));
            Console.WriteLine(string.Join(" ",secondArr));
        }
    }
}
