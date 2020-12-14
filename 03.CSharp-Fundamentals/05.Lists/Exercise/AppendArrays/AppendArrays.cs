using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArrays
{
    class AppendArrays
    {
        static void Main(string[] args)
        {
            string arr = Console.ReadLine();

            string[] support = arr.Split("|", StringSplitOptions.RemoveEmptyEntries).ToArray();

            List<int> result = new List<int>();

            for (int i = support.Length - 1; i >= 0; i--)
            {
                int[] arrs = support[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                foreach (int item in arrs)
                {
                    result.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
