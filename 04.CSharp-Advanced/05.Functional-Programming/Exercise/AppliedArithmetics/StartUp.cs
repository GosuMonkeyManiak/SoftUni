using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string inPut = Console.ReadLine();
                if (inPut == "end")
                {
                    break;
                }

                if (inPut == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                    continue;
                }

                Func<int, int> operation = GetOperation(inPut);

                DoOperation(numbers, operation);
            }


        }

        static void DoOperation(List<int> numbers, Func<int, int> operation)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] = operation(numbers[i]);
            }
        }

        static Func<int, int> GetOperation(string inPut)
        {
            switch (inPut)
            {
                case "add": return x => x + 1;
                case "multiply": return x => x * 2;
                case "subtract": return x => x - 1;
                default: return null;
            }
        }
    }
}
