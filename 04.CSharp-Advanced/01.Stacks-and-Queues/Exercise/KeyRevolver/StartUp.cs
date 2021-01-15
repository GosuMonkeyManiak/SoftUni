using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine()); // 0-100
            int barrelSize = int.Parse(Console.ReadLine()); // 1-5000

            int[] inPutBullets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> availableBullets = new Stack<int>(inPutBullets); // 1-100

            int[] inPutLocks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> availableLocks = new Queue<int>(inPutLocks); // 1-100

            int valueOfIntelligance = int.Parse(Console.ReadLine()); // 1-1000000

            int currentBarrel = barrelSize;
            int shootBullets = 0;

            while (availableLocks.Any())
            {
                if (availableBullets.Any() && currentBarrel == 0)
                {
                    if (availableBullets.Count < currentBarrel)
                    {
                        currentBarrel = availableBullets.Count;
                    }
                    else
                    {
                        currentBarrel = barrelSize;
                    }

                    Console.WriteLine("Reloading!");
                }
                else if (availableBullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {availableLocks.Count}");
                    return;
                }

                int currentBullet = availableBullets.Peek();
                int currecntLock = availableLocks.Peek();

                if (currentBullet <= currecntLock)
                {
                    Console.WriteLine("Bang!");
                    availableBullets.Pop();
                    availableLocks.Dequeue();

                    currentBarrel--;
                    shootBullets++;
                    continue;
                }
                else
                {
                    Console.WriteLine("Ping!");
                    availableBullets.Pop();

                    currentBarrel--;
                    shootBullets++;
                    continue;
                }

            }

            if (availableBullets.Any() && currentBarrel == 0)
            {
                if (availableBullets.Count < currentBarrel)
                {
                    currentBarrel = availableBullets.Count;
                }
                else
                {
                    currentBarrel = barrelSize;
                }

                Console.WriteLine("Reloading!");
            }

            int moneyForBullets = shootBullets * bulletPrice;
            valueOfIntelligance -= moneyForBullets;


            Console.WriteLine($"{availableBullets.Count} bullets left. Earned ${valueOfIntelligance}");
        }
    }
}
