using System;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfCharity = int.Parse(Console.ReadLine());

            int numberOfConfectioner = int.Parse(Console.ReadLine());

            int numberOfCakesPerDay = int.Parse(Console.ReadLine());
            int numberOfWafflesPerDay = int.Parse(Console.ReadLine());
            int numberOfPanCakePerDay = int.Parse(Console.ReadLine());

            int allCakes = (numberOfConfectioner * numberOfCakesPerDay) * daysOfCharity;
            int allWaffles = (numberOfConfectioner * numberOfWafflesPerDay) * daysOfCharity;
            int allPancakes = (numberOfConfectioner * numberOfPanCakePerDay) * daysOfCharity;

            decimal collectedMoney = (allCakes * 45.00M) + (allWaffles * 5.80M) + (allPancakes * 3.20M);

            decimal moneyForCharity = collectedMoney - collectedMoney / 8;

            Console.WriteLine($"{moneyForCharity:f2}");
        }
    }
}
