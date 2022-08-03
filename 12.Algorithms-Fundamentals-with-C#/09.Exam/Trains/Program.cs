namespace Trains
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            double[] arrivalTime = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            double[] departureTime = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<int, bool> platforms = new Dictionary<int, bool>();
            int platformNumber = 1;

            Queue<int> usedPlaforms = new Queue<int>();

            for (int i = 0; i < arrivalTime.Length - 1; i++)
            {
                if (i != 0 && usedPlaforms.Count > 0)
                {
                    int used = usedPlaforms.Dequeue();
                    platforms[used] = false;
                }

                if (departureTime[i] > arrivalTime[i + 1])
                {
                    var freePlatformKey = platforms.FirstOrDefault(x => x.Value == false).Key;

                    if (freePlatformKey == 0)
                    {
                        platforms.Add(platformNumber++, true);
                        usedPlaforms.Enqueue(platformNumber);
                    }
                    else
                    {
                        usedPlaforms.Enqueue(freePlatformKey);
                        platforms[freePlatformKey] = true;
                    }
                }
            }

            Console.WriteLine(platforms.Count);
        }
    }
}