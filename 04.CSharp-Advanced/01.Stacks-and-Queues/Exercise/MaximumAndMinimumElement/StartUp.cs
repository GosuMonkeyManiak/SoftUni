using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int repeats = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < repeats; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int query = int.Parse(tokens[0]);

                switch (query)
                {
                    case 1:
                        int numberForPush = int.Parse(tokens[1]);

                        numbers.Push(numberForPush);
                        break;

                    case 2:

                        if (numbers.Count == 0)
                        {
                            continue;
                        }

                        numbers.Pop();
                        break;

                    case 3:

                        if (numbers.Count == 0)
                        {
                            continue;
                        }

                        Console.WriteLine(numbers.Max());
                        break;

                    case 4:

                        if (numbers.Count == 0)
                        {
                            continue;
                        }

                        Console.WriteLine(numbers.Min());
                        break;
                }

            }

            Console.WriteLine(string.Join(", ", numbers));

        }
    }
}
