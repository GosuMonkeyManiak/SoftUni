using System;
using System.Collections.Generic;
using System.Linq;

namespace ListsManipulationAdvanced
{
    class LitsManipulationAdvanced
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            int operations = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    if (operations > 0)
                    {
                        Console.WriteLine(string.Join(" ", numbers));
                    }
                    break;
                }

                string[] commadns = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (commadns[0])
                {
                    case "Add":
                        int addNumber = int.Parse(commadns[1]);
                        numbers.Add(addNumber);
                        operations++;
                        break;

                    case "Remove":
                        int removeNumber = int.Parse(commadns[1]);
                        numbers.Remove(removeNumber);
                        operations++;
                        break;

                    case "RemoveAt":
                        int removeAtIndex = int.Parse(commadns[1]);
                        numbers.RemoveAt(removeAtIndex);
                        operations++;
                        break;

                    case "Insert":
                        int number = int.Parse(commadns[1]);
                        int index = int.Parse(commadns[2]);
                        numbers.Insert(index, number);
                        operations++;
                        break;

                    case "Contains":
                        int containsNumber = int.Parse(commadns[1]);
                        bool isContainsThatNumber = numbers.Contains(containsNumber);

                        if (isContainsThatNumber)
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;

                    case "PrintEven":
                        foreach (int item in numbers)
                        {
                            if (item % 2 == 0)
                            {
                                Console.Write($"{item} ");
                            }
                        }

                        Console.WriteLine();
                        break;

                    case "PrintOdd":
                        foreach (int item in numbers)
                        {
                            if (item % 2 != 0)
                            {
                                Console.Write($"{item} ");
                            }
                        }

                        Console.WriteLine();
                        break;

                    case "GetSum":
                        int sum = 0;

                        foreach (int item in numbers)
                        {
                            sum += item;
                        }

                        Console.WriteLine(sum);
                        break;

                    case "Filter":
                        string condition = commadns[1];
                        int conditionNumber = int.Parse(commadns[2]);

                        if (condition == "<")
                        {
                            foreach (int item in numbers)
                            {
                                if (item < conditionNumber)
                                {
                                    Console.Write($"{item} ");
                                }
                            }
                        }
                        else if (condition == ">")
                        {
                            foreach (int item in numbers)
                            {
                                if (item > conditionNumber)
                                {
                                    Console.Write($"{item} ");
                                }
                            }
                        }
                        else if (condition == ">=")
                        {
                            foreach (int item in numbers)
                            {
                                if (item >= conditionNumber)
                                {
                                    Console.Write($"{item} ");
                                }
                            }
                        }
                        else if (condition == "<=")
                        {
                            foreach (int item in numbers)
                            {
                                if (item <= conditionNumber)
                                {
                                    Console.Write($"{item} ");
                                }
                            }
                        }

                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
