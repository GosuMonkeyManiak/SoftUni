using System;
using System.Collections.Generic;
using System.Linq;

namespace AddVAT
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Func<string, double> parser = x => double.Parse(x);

            List<double> prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToList();

            List<double> newPrices = GetVAT(prices, x => x * 0.2);

            foreach (var price in newPrices)
            {
                Console.WriteLine($"{price:f2}");
            }

        }

        static List<double> GetVAT(List<double> prices, Func<double,double> condition)
        {
            List<double> newPrices = new List<double>();
 
            for (int i = 0; i < prices.Count; i++)
            {
                newPrices.Add(prices[i] + condition(prices[i]));
            }

            return newPrices;
        }
    }
}
