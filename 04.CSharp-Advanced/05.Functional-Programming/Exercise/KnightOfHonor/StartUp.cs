using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightOfHonor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> knights = GetInPut();

            Action<string> format = x => Console.WriteLine($"Sir {x}");

            Print(knights, format);
        }

        static void Print(List<string> knights, Action<string> action)
        {
            for (int i = 0; i < knights.Count; i++)
            {
                action(knights[i]);
            }
        }

        static List<string> GetInPut()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
        }
    }
}
