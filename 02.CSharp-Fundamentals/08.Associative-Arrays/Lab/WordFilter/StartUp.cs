using System;
using System.Collections.Generic;
using System.Linq;

namespace WordFilter
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x.Length % 2 == 0)
                .ToList();

            foreach (var item in words)
            {
                Console.WriteLine(item);
            }
        }
    }
}
