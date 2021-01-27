using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateForNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Predicate<string> predicate = x => x.Length <= nameLength;

            GetSpecialNames(names, predicate);
            Print(names);

        }

        static void Print(List<string> names)
        {
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }
        }

        static void GetSpecialNames(List<string> names, Predicate<string> predicate)
        {
            for (int i = 0; i < names.Count; i++)
            {
                if (!predicate(names[i]))
                {
                    names.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
