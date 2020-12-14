using System;
using System.Collections.Generic;
using System.Linq;

namespace HeartDelivery
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> neighborhood = Console.ReadLine()
                .Split('@', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int startIndex = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Love!")
                {
                    break;
                }
                string[] commands = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();


                int jumpLength = int.Parse(commands[1]);// out of range

                startIndex += jumpLength;

                if (startIndex >= neighborhood.Count)
                {
                    startIndex = 0;
                }

                if (neighborhood[startIndex] == 0)
                {
                    Console.WriteLine($"Place {startIndex} already had Valentine's day.");
                    continue;
                }

                neighborhood[startIndex] -= 2;

                if (neighborhood[startIndex] == 0)
                {
                    Console.WriteLine($"Place {startIndex} has Valentine's day.");
                }
            }

            List<int> housesWithZero = neighborhood.Where(x => x == 0).ToList();

            if (housesWithZero.Count == neighborhood.Count)
            {
                Console.WriteLine($"Cupid's last position was {startIndex}.");
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                int houseFailed = neighborhood.Count - housesWithZero.Count;

                Console.WriteLine($"Cupid's last position was {startIndex}.");
                Console.WriteLine($"Cupid has failed {houseFailed} places.");
            }
        }
    }
}
