using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] inPut = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = inPut[0];
                string[] currentClothe = inPut[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!clothes.ContainsKey(color)) //don't have this color
                {
                    clothes.Add(color, new Dictionary<string, int>());

                    for (int j = 0; j < currentClothe.Length; j++)
                    {
                        if (clothes[color].ContainsKey(currentClothe[j]))
                        {
                            clothes[color][currentClothe[j]]++;
                            continue;
                        }

                        clothes[color].Add(currentClothe[j], 1);
                    }

                }
                else // have this color
                {
                    for (int j = 0; j < currentClothe.Length; j++)
                    {
                        if (clothes[color].ContainsKey(currentClothe[j]))
                        {
                            clothes[color][currentClothe[j]]++;
                            continue;
                        }

                        clothes[color].Add(currentClothe[j], 1);
                    }
                }

            }

            string[] clotheToFind = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string colorToFind = clotheToFind[0];
            string clothe = clotheToFind[1];


            foreach (var currentColor in clothes)
            {
                Console.WriteLine($"{currentColor.Key} clothes:");

                if (currentColor.Key == colorToFind)
                {
                    foreach (var currentClothe in currentColor.Value)
                    {
                        if (currentClothe.Key == clothe)
                        {
                            Console.WriteLine($"* {currentClothe.Key} - {currentClothe.Value} (found!)");
                        }
                        else
                        {
                            Console.WriteLine($"* {currentClothe.Key} - {currentClothe.Value}");
                        }

                    }

                }
                else
                {
                    foreach (var currentClothe in currentColor.Value)
                    {
                        Console.WriteLine($"* {currentClothe.Key} - {currentClothe.Value}");
                    }
                }

            }

        }
    }
}
