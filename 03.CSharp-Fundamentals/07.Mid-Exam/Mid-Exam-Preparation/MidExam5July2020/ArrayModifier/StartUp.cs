using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayModifier
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (commands[0] == "end")
                {
                    Console.WriteLine(string.Join(", ", numbers));
                    break;
                }

                switch (commands[0])
                {
                    case "swap":

                        int swapIndexFirst = int.Parse(commands[1]);
                        int swapIndexSecond = int.Parse(commands[2]);

                        int temp = numbers[swapIndexFirst];
                        numbers[swapIndexFirst] = numbers[swapIndexSecond];
                        numbers[swapIndexSecond] = temp;
                        break;

                    case "multiply":

                        int multiplyIndexFirst = int.Parse(commands[1]);
                        int multiplyIndexSecond = int.Parse(commands[2]);

                        numbers[multiplyIndexFirst] = numbers[multiplyIndexFirst] * numbers[multiplyIndexSecond];
                        break;

                    case "decrease":

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            numbers[i]--;
                        }
                        break;
                }
            }
        }
    }
}
