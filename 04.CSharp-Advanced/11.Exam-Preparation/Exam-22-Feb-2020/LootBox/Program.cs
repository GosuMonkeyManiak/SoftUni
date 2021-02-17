using System;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstLootBox = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> secondLootBox = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int clailedItems = 0;

            while (firstLootBox.Count > 0 && secondLootBox.Count > 0)
            {
                int firstLoot = firstLootBox.Peek();
                int secondLoot = secondLootBox.Peek();

                if ((firstLoot + secondLoot) % 2 == 0)
                {
                    clailedItems += (firstLoot + secondLoot);
                }
                else
                {
                    firstLootBox.Enqueue(secondLootBox.Pop());
                    continue;
                }

                firstLootBox.Dequeue();
                secondLootBox.Pop();
            }

            if (firstLootBox.Count == 0)
            {
                Console.WriteLine($"First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (clailedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {clailedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {clailedItems}");
            }
        }
    }
}
