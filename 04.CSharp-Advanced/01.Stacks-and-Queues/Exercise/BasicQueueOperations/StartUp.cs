using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int elementsToAdd = int.Parse(command[0]);
            int elementsToRemove = int.Parse(command[1]);
            int elementLookFor = int.Parse(command[2]);

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>();

            if (elementsToAdd <= 0)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (queue.Count == elementsToAdd)
                {
                    break;
                }

                queue.Enqueue(numbers[i]);
            }

            if (elementsToRemove >= queue.Count)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = 0; i < elementsToRemove; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(elementLookFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
