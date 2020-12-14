using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
{
    class ListOperations
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
                if (command == "End")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                    break;
                }

                string[] commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (commands[0])
                {
                    case "Add":
                        int addNumber = int.Parse(commands[1]);
                        numbers.Add(addNumber);
                        break;

                    case "Insert":
                        int element = int.Parse(commands[1]);
                        int insertIndex = int.Parse(commands[2]);

                        if (insertIndex < 0 || insertIndex > numbers.Count - 1) //!!!!
                        {
                            Console.WriteLine("Invalid index");
                            continue;
                        }
                        else
                        {
                            numbers.Insert(insertIndex, element);
                        }
                        break;

                    case "Remove":
                        int removeIndex = int.Parse(commands[1]);

                        if (removeIndex < 0 || removeIndex > numbers.Count - 1) //!!!!
                        {
                            Console.WriteLine("Invalid index");
                            continue;
                        }
                        else
                        {
                            numbers.RemoveAt(removeIndex);
                        }
                        break;

                    case "Shift":
                        if (commands[1] == "left")
                        {
                            int count = int.Parse(commands[2]);

                            for (int i = 0; i < count; i++)
                            {
                                numbers.Add(numbers[0]);
                                numbers.RemoveAt(0);
                            }
                        }
                        else
                        {
                            int count = int.Parse(commands[2]);
                            numbers.Reverse();

                            for (int i = 0; i < count; i++)
                            {
                                numbers.Add(numbers[0]);
                                numbers.RemoveAt(0);
                            }

                            numbers.Reverse();
                        }
                        break;
                }
            }
        }
    }
}
