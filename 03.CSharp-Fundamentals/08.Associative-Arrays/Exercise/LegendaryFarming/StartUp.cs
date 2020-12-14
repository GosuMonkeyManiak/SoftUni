using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legendaryMaterials = new Dictionary<string, int>();
            legendaryMaterials.Add("shards", 0);
            legendaryMaterials.Add("fragments", 0);
            legendaryMaterials.Add("motes", 0);

            Dictionary<string, int> junk = new Dictionary<string, int>();

            string winnerKey = null;
            bool isHavaAWinner = false;

            while (true)
            {
                List<string> resource = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                for (int i = 1; i < resource.Count; i += 2)
                {
                    string currentResource = resource[i].ToLower();

                    if (legendaryMaterials.ContainsKey(currentResource))
                    {
                        legendaryMaterials[currentResource] += int.Parse(resource[i - 1]);

                        if (legendaryMaterials[currentResource] >= 250)
                        {
                            winnerKey = currentResource;
                            isHavaAWinner = true;
                            break;
                        }
                    }
                    else //junk
                    {
                        if (junk.ContainsKey(currentResource))
                        {
                            junk[currentResource] += int.Parse(resource[i - 1]);
                        }
                        else
                        {
                            junk.Add(currentResource, int.Parse(resource[i - 1]));
                        }
                    }
                }

                if (isHavaAWinner)
                {
                    if (winnerKey == "shards")
                    {
                        Console.WriteLine("Shadowmourne obtained!");
                    }
                    else if (winnerKey == "fragments")
                    {
                        Console.WriteLine($"Valanyr obtained!");
                    }
                    else
                    {
                        Console.WriteLine($"Dragonwrath obtained!");
                    }

                    legendaryMaterials[winnerKey] -= 250;
                    break;
                }

            }

            legendaryMaterials = legendaryMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in legendaryMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            junk = junk.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in junk)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

    }
}
