using System;
using System.Collections.Generic;
using System.Linq;

namespace ShootForTheWin
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int shotTargets = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    Console.Write($"Shot targets: {shotTargets} -> ");
                    foreach (int item in targets)
                    {
                        Console.Write($"{item} ");
                    }
                    break;
                }
                int indexToShot = int.Parse(command);

                if (indexToShot < 0 || indexToShot > targets.Length - 1)
                {
                    continue;
                }

                if (targets[indexToShot] == -1)
                {
                    continue;
                }

                int currentValue = targets[indexToShot];

                targets[indexToShot] = -1;
                shotTargets++;

                for (int i = 0; i < targets.Length; i++)
                {
                    if (targets[i] <= currentValue && targets[i] != -1)
                    {
                        targets[i] += currentValue;
                    }
                    else if (targets[i] != -1)
                    {
                        targets[i] -= currentValue;
                    }
                }

            }
        }
    }
}
