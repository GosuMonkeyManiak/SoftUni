using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int elementsHaveToPush = int.Parse(command[0]);
            int elementsHaveToPop = int.Parse(command[1]);
            int elementForLooking = int.Parse(command[2]);

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();

            if (elementsHaveToPush <= 0)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == elementsHaveToPush - 1)
                {
                    break;
                }

                stack.Push(numbers[i]);
            }

            if (elementsHaveToPop >= stack.Count)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = 0; i < elementsHaveToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(elementForLooking))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
