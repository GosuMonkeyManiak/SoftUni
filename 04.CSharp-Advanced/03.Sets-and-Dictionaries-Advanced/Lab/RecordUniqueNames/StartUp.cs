using System;
using System.Collections.Generic;

namespace RecordUniqueNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> uniqueName = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();

                uniqueName.Add(name);
            }

            foreach (var name in uniqueName)
            {
                Console.WriteLine(name);
            }
        }
    }
}
