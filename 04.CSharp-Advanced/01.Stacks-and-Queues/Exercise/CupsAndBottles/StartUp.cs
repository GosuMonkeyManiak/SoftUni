using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] inPutCups = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> cups = new Queue<int>(inPutCups); // 1-500

            int[] inPutBottles = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> bottles = new Stack<int>(inPutBottles); // 1-500

            int wasteWater = 0;

            int currentCup = -1;
            int currentBottle = -1;

            while (cups.Any())
            {
                if (currentBottle == 0 && bottles.Any())
                {
                    currentBottle = bottles.Peek();
                }
                else if (bottles.Count == 0)
                {
                    Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                    Console.WriteLine($"Wasted litters of water: {wasteWater}");
                    return;
                }

                currentCup = cups.Peek();
                currentBottle = bottles.Peek();

                if (currentCup > currentBottle)
                {
                    while (currentCup != 0) //until
                    {
                        if (currentBottle == 0 && bottles.Any())
                        {
                            currentBottle = bottles.Peek();
                        }
                        else if (bottles.Count == 0)
                        {
                            Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                            Console.WriteLine($"Wasted litters of water: {wasteWater}");
                            return;
                        }

                        currentCup -= currentBottle; //1

                        if (currentCup <= 0)
                        {
                            int remain = Math.Abs(currentCup);
                            wasteWater += remain;

                            currentBottle = 0;

                            cups.Dequeue();
                            bottles.Pop();
                            break;
                        }

                        bottles.Pop();
                        currentBottle = 0;
                    }
                }
                else //currentCup <= currentBottle
                {
                    int remain = currentBottle - currentCup;

                    currentBottle = 0;
                    wasteWater += remain;

                    cups.Dequeue();
                    bottles.Pop();
                }

            }

            Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            Console.WriteLine($"Wasted litters of water: {wasteWater}");

        }
    }
}
