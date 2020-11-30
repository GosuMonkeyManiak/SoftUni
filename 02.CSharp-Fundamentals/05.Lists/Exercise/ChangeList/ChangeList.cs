using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class ChangeList
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                    break;
                }

                string[] commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (commands[0] == "Delete")
                {
                    int element = int.Parse(commands[1]);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] == element)
                        {
                            numbers.Remove(numbers[i]);
                            i -= 1;
                        }
                    }
                }
                else
                {
                    int element = int.Parse(commands[1]);
                    int index = int.Parse(commands[2]);

                    numbers.Insert(index, element);
                }
            }
        }
    }
}
