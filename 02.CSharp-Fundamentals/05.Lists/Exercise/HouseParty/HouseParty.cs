using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseParty
{
    class HouseParty
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> guests = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();

                string[] commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (commands.Length == 3)
                {
                    //Add
                    bool isInTheList = false;

                    foreach (string item in guests)
                    {
                        if (item == commands[0])
                        {
                            isInTheList = true;
                        }
                    }

                    if (isInTheList)
                    {
                        Console.WriteLine($"{commands[0]} is already in the list!");
                    }
                    else
                    {
                        guests.Add(commands[0]);
                    }
                }
                else
                {
                    //remove
                    bool isInTheList = false;

                    foreach (string item in guests)
                    {
                        if (item == commands[0])
                        {
                            isInTheList = true;
                        }
                    }

                    if (isInTheList)
                    {
                        guests.Remove(commands[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{commands[0]} is not in the list!");
                    }
                }
            }

            for (int i = 0; i < guests.Count; i++)
            {
                Console.WriteLine(guests[i]);
            }
        }
    }
}
