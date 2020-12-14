using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationBasics
{
    class ListManipulationBasics
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

                string[] commadns = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (commadns[0])
                {
                    case "Add":
                        int addNumber = int.Parse(commadns[1]);
                        numbers.Add(addNumber);
                        break;

                    case "Remove":
                        int removeNumber = int.Parse(commadns[1]);
                        numbers.Remove(removeNumber);
                        break;

                    case "RemoveAt":
                        int removeAtIndex = int.Parse(commadns[1]);
                        numbers.RemoveAt(removeAtIndex);
                        break;

                    case "Insert":
                        int number = int.Parse(commadns[1]);
                        int index = int.Parse(commadns[2]);
                        numbers.Insert(index, number);
                        break;
                }
            }
        }
    }
}
