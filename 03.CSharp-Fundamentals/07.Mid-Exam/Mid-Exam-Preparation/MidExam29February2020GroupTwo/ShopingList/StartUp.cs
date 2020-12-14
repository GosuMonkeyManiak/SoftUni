using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopingList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine()
                .Split('!', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Go Shopping!")
                {
                    for (int i = 0; i < groceries.Count; i++)
                    {
                        if (i == groceries.Count - 1)
                        {
                            Console.Write($"{groceries[i]}");
                        }
                        else
                        {
                            Console.Write($"{groceries[i]}, ");
                        }
                    }

                    break;
                }

                string[] splitcommand = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (splitcommand[0])
                {
                    case "Urgent":

                        string urgentItem = splitcommand[1];

                        if (!groceries.Contains(urgentItem))
                        {
                            groceries.Insert(0, urgentItem);
                        }

                        break;

                    case "Unnecessary":

                        string unNecessaryItem = splitcommand[1];

                        if (groceries.Contains(unNecessaryItem))
                        {
                            groceries.Remove(unNecessaryItem);
                        }
                        break;

                    case "Correct":

                        string oldItem = splitcommand[1];
                        string newItem = splitcommand[2];

                        if (groceries.Contains(oldItem))
                        {
                            int index = Math.Abs(groceries.FindIndex(0, x => x == oldItem));
                            groceries[index] = newItem;
                            
                        }

                        break;

                    case "Rearrange":

                        string rearRange = splitcommand[1];

                        if (groceries.Contains(rearRange))
                        {
                            groceries.Remove(rearRange);
                            groceries.Add(rearRange);
                        }
                        break;
                }

            }

        }

    }

}
