using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDiscovery
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, AllRating> plants = new Dictionary<string, AllRating>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);

                string plant = tokens[0];
                int rarity = int.Parse(tokens[1]);

                if (plants.ContainsKey(plant))
                {
                    plants[plant].Rarity = rarity;
                }
                else
                {
                    plants.Add(plant, new AllRating()
                    {
                        Rating = new List<double>(),
                        Rarity = rarity
                    });
                }
            }

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Exhibition")
                {
                    break;
                }

                string command = tokens[0];

                switch (command)
                {
                    case "Rate":
                        string[] rateCommand = tokens[1]
                            .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                        string ratePlant = rateCommand[0];
                        int rating = int.Parse(rateCommand[1]);

                        if (plants.ContainsKey(ratePlant))
                        {
                            plants[ratePlant].Rating.Add(rating);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;

                    case "Update":
                        string[] updateCommand = tokens[1]
                            .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                        string updatePlant = updateCommand[0];
                        int newRarity = int.Parse(updateCommand[1]);

                        if (plants.ContainsKey(updatePlant))
                        {
                            plants[updatePlant].Rarity = newRarity;
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;

                    case "Reset":
                        string resetPlant = tokens[1];

                        if (plants.ContainsKey(resetPlant))
                        {
                            plants[resetPlant].Rating.Clear();
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;

                    default:
                        Console.WriteLine("error");
                        break;
                }

            }

            foreach (var item in plants)
            {
                int count = item.Value.Rating.Count;
                double sum = 0.0;

                foreach (var number in item.Value.Rating)
                {
                    sum += number;
                }

                item.Value.Rating.Clear();

                if (sum == 0)
                {
                    item.Value.Rating.Clear();
                    item.Value.Rating.Add(0.0);
                }
                else
                {
                    sum /= count;
                    item.Value.Rating.Add(sum);
                }
                
            }

            plants = plants.OrderByDescending(x => x.Value.Rarity)
                .ThenByDescending(x => x.Value.Rating[0])
                .ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in plants)
            {
                Console.WriteLine($"- {item.Key}; Rarity: {item.Value.Rarity}; Rating: {item.Value.Rating.Average():f2}");
            }
        }
    }



}
