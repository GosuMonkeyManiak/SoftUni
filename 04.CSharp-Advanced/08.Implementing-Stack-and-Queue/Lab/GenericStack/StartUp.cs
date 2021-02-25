using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack<int> integers = new CustomStack<int>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    for (int i = 1; i <= 2; i++)
                    {
                        foreach (var item in integers)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                }

                command = command.Trim();

                if (command.Length > 3)
                {
                    int[] numbers = command.Substring(command.IndexOf(' '))
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    foreach (var item in numbers)
                    {
                        integers.Push(item);
                    }
                }
                else if (command == "Pop")
                {
                    try
                    {
                        integers.Pop();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No elements");
                    }
                }


            }
        }
    }
}
