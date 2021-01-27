using System;
using System.Collections.Generic;
using System.Linq;

namespace ActionPoint
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> names = InPut();

            Action<string> format = x => Console.WriteLine(x);

            Print(names, format);
        }

        static void Print(List<string> names, Action<string> format)
        {
            for (int i = 0; i < names.Count; i++)
            {
                format(names[i]);
            }
        }

        static List<string> InPut()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
        }
    }
}
