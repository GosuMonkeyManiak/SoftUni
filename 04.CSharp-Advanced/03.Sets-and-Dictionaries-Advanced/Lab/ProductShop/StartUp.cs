using System;
using System.Collections.Generic;

namespace ProductShop
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] infoAboutShops = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                if (infoAboutShops[0] == "Revision")
                {
                    break;
                }

                string shop = infoAboutShops[0];
                string product = infoAboutShops[1];
                double price = double.Parse(infoAboutShops[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                if (!shops[shop].ContainsKey(product))
                {
                    shops[shop].Add(product, 0);
                }

                shops[shop][product] = price;
            }

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
