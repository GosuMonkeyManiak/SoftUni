using System;
using System.Collections.Generic;

namespace CitiesByContinentAndContry
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = info[0];
                string contry = info[1];
                string city = info[2];

                if (!continents.ContainsKey(continent))
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!continents[continent].ContainsKey(contry))
                {
                    continents[continent].Add(contry, new List<string>());
                }

                continents[continent][contry].Add(city);
            }


            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var contry in continent.Value)
                {
                    Console.Write($"  {contry.Key} -> ");
                    Console.Write(string.Join(", ", contry.Value));
                    Console.WriteLine();
                }
            }
        }
    }
}
