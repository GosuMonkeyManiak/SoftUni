using System;
using System.Collections.Generic;
using System.Linq;

namespace Crafting
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> parts = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (commands[0] == "Done")
                {
                    Console.WriteLine($"You crafted {string.Join("", parts)}!");
                    break;
                }

                switch (commands[0])
                {
                    case "Move":

                        int moveIndex = int.Parse(commands[2]);

                        if (moveIndex < 0 || moveIndex > parts.Count - 1)
                        {
                            break;
                        }

                        if (commands[1] == "Left" && moveIndex > 0)
                        {
                            int leftIndex = moveIndex - 1;

                            string temp = parts[leftIndex];
                            parts[leftIndex] = parts[moveIndex];
                            parts[moveIndex] = temp;
                        }
                        else if (commands[1] == "Right")
                        {
                            if (moveIndex < parts.Count - 1)
                            {
                                int rigthIndex = moveIndex + 1;

                                string temp = parts[rigthIndex];
                                parts[rigthIndex] = parts[moveIndex];
                                parts[moveIndex] = temp;
                            }
                        }

                        break;

                    case "Check":

                        if (parts.Count <= 0)
                        {
                            break;
                        }

                        if (commands[1] == "Even")
                        {
                            for (int i = 0; i < parts.Count; i++)
                            {
                                if (i % 2 == 0)
                                {
                                    Console.Write($"{parts[i]} ");
                                }
                            }

                            Console.WriteLine();
                        }
                        else
                        {
                            for (int i = 0; i < parts.Count; i++)
                            {
                                if (i % 2 != 0)
                                {
                                    Console.Write($"{parts[i]} ");
                                }
                            }

                            Console.WriteLine();
                        }

                        break;
                }
            }
        }
    }
}
