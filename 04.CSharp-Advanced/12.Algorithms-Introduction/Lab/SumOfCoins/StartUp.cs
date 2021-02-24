using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfCoins
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var availableCoins = new[] { 1, 2, 5 };
            var targetSum = 2031154123;

            try
            {
                var selectedCoins = ChooseCoins(availableCoins, targetSum);

                Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
                foreach (var selectedCoin in selectedCoins)
                {
                    Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
        }

        static Dictionary<int, int> ChooseCoins(int[] coins, int targetSum)
        {
            var sortedCoins = coins.OrderByDescending(x => x).ToList();
            var result = new Dictionary<int, int>();

            for (int i = 0; i < sortedCoins.Count; i++)
            {
                var currentCoin = sortedCoins[i];
                var numbersOfCoinsToTake = targetSum / currentCoin;
                targetSum %= currentCoin;

                if (numbersOfCoinsToTake > 0)
                {
                    result.Add(currentCoin, numbersOfCoinsToTake);
                }
            }

            if (targetSum != 0)
            {
                throw new Exception();
            }

            return result;
        }
    }
}
