using System;
using System.Collections.Generic;
using System.Linq;

namespace TreasureFinder
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> keys = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string cryptMessage = Console.ReadLine();
                if (cryptMessage == "find")
                {
                    break;
                }

                string result = string.Empty;
                int index = 0;

                for (int i = 0; i < cryptMessage.Length; i++)
                {
                    if (index > keys.Count - 1)
                    {
                        index = 0;
                    }

                    char currentChar = cryptMessage[i];
                    int number = (int)currentChar - keys[index];
                    currentChar = (char)number;

                    index++;

                    result += currentChar;
                }

                int leftTreasureIndex = result.IndexOf('&') + 1;
                int rigthTreasureIndex = result.LastIndexOf('&');

                string treasure = result.Substring(leftTreasureIndex, rigthTreasureIndex - leftTreasureIndex);

                int leftCoordinatesIndex = result.IndexOf('<') + 1;
                int rigthCoordinateIndex = result.LastIndexOf('>');

                string coordinates = result.Substring(leftCoordinatesIndex, rigthCoordinateIndex - leftCoordinatesIndex);

                Console.WriteLine($"Found {treasure} at {coordinates}");
            }
        }
    }
}
