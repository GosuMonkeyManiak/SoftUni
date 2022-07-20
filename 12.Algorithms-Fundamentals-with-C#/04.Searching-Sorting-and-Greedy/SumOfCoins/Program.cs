namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .ToArray();

            int target = int.Parse(Console.ReadLine());

            Dictionary<int, int> usedCoins = new Dictionary<int, int>();

            for (int i = 0; i < coins.Length; i++)
            {
                int coin = coins[i];
                int currentNumberOfCoins = target / coins[i];

                if (currentNumberOfCoins != 0)
                {
                    usedCoins[coin] = currentNumberOfCoins;
                }

                target %= coins[i];
            }

            if (target != 0)
            {
                Console.WriteLine("Error");
            }
            else
            {
                Console.WriteLine($"Number of coins to take: {usedCoins.Sum(kvp => kvp.Value)}");

                foreach (var (key, value) in usedCoins)
                {
                    Console.WriteLine($"{value} coin(s) with value {key}");
                }
            }
        }
    }
}