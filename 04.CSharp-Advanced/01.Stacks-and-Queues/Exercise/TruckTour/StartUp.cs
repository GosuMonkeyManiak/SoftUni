using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int countOfStations = int.Parse(Console.ReadLine());

            Queue<StationInfo> stations = new Queue<StationInfo>();

            for (int i = 0; i < countOfStations; i++)
            {
                int[] infoForStation = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                StationInfo currentStation = new StationInfo
                {
                    GivePetrol = infoForStation[0],
                    DistanceToNextStation = infoForStation[1],
                    IndexOfStaion = i
                };

                stations.Enqueue(currentStation);
            }

            int truckFuel = stations.Peek().GivePetrol;
            int stationIndex = stations.Peek().IndexOfStaion;
            int distanceToNext = stations.Peek().DistanceToNextStation;

            int index = 0;
            int startIndex = 0;
            int smallestIndex = -1;

            while (true)
            {
                int fuelToNexStation = distanceToNext;

                if (fuelToNexStation > truckFuel)
                {
                    stations.Enqueue(stations.Dequeue());

                    truckFuel = stations.Peek().GivePetrol;
                    stationIndex = stations.Peek().IndexOfStaion;
                    distanceToNext = stations.Peek().DistanceToNextStation;

                    startIndex = stationIndex;
                    index = stationIndex;
                    continue;
                }

                truckFuel -= fuelToNexStation;

                stations.Enqueue(stations.Dequeue());

                truckFuel += stations.Peek().GivePetrol;
                stationIndex = stations.Peek().IndexOfStaion;
                distanceToNext = stations.Peek().DistanceToNextStation;

                index++;
                if (index > countOfStations - 1)
                {
                    index = 0;
                }

                if (index == startIndex)
                {
                    smallestIndex = startIndex;
                    break;
                }
            }

            Console.WriteLine(smallestIndex);
        }
    }
}
