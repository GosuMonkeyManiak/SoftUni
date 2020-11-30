using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> inventory = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Craft!")
                {
                    for (int i = 0; i < inventory.Count; i++)
                    {
                        if (i == inventory.Count - 1)
                        {
                            Console.Write($"{inventory[i]}");
                        }
                        else
                        {
                            Console.Write($"{inventory[i]}, ");
                        }
                    }

                    break;
                }

                string[] splitCommands = command
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (splitCommands[0])
                {
                    case "Collect":

                        string itemToCollect = splitCommands[1];

                        if (!inventory.Contains(itemToCollect))
                        {
                            inventory.Add(itemToCollect);
                        }
                        break;

                    case "Drop":

                        string itemToDrop = splitCommands[1];

                        if (inventory.Contains(itemToDrop))
                        {
                            inventory.Remove(itemToDrop);
                        }
                        break;

                    case "Combine Items":

                        string[] items = splitCommands[1]
                            .Split(':', StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

                        if (inventory.Contains(items[0]))
                        {
                            int test = inventory.FindIndex(0, x => x == items[0]);

                            if (test == inventory.Count - 1)
                            {
                                inventory.Add(items[1]);
                            }
                            else
                            {
                                int oldItemIndex = inventory.FindIndex(0, inventory.Count - 1, x => x == items[0]);
                                inventory.Insert(oldItemIndex + 1, items[1]);
                            }
                        }
                        break;

                    case "Renew":

                        string itemToRenew = splitCommands[1];

                        if (inventory.Contains(itemToRenew))
                        {
                            inventory.Remove(itemToRenew);
                            inventory.Add(itemToRenew);
                        }
                        break;
                }
            }
        }
    }
}
