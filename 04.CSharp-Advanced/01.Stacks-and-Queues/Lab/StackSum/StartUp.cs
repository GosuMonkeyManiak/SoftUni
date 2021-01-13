using System;
using System.Linq;
using System.Collections.Generic;

namespace StackSum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command[0].ToLower() == "end")
                {
                    break;
                }

                if (command[0].ToLower() == "add")
                {
                    stack.Push(int.Parse(command[1]));
                    stack.Push(int.Parse(command[2]));
                }
                else //remove
                {
                    int countForRemove = int.Parse(command[1]);

                    if (countForRemove <= stack.Count)
                    {
                        for (int i = 0; i < countForRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

            }

            int sum = 0;

            while (stack.Count > 0)
            {
                sum += stack.Pop();
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
