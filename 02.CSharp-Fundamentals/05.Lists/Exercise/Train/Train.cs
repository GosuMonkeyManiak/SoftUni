using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Train
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string passangers = Console.ReadLine();
                if (passangers == "end")
                {
                    Console.WriteLine(string.Join(" ", wagons));
                    break;
                }

                string[] support = passangers.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (support[0] == "Add")
                {
                    int numberPassangers = int.Parse(support[1]);
                    wagons.Add(numberPassangers);
                }
                else
                {
                    int numberPassangers = int.Parse(support[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {

                        int currentCapacity = maxCapacity - wagons[i];
                        if (currentCapacity >= numberPassangers)
                        {
                            wagons[i] += numberPassangers;
                            break;
                        }
                        
                    }
                }
            }
        }
    }
}
