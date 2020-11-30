using System;

namespace VegetableMarket
{
    class VegetableMarket
    {
        static void Main(string[] args)
        {
            double vegePrice = double.Parse(Console.ReadLine());
            double fruitPrice = double.Parse(Console.ReadLine());
            int vegeKg = int.Parse(Console.ReadLine());
            int fruitKg = int.Parse(Console.ReadLine());

            double allIncome = (vegeKg * vegePrice) + (fruitKg * fruitPrice);

            double euro = allIncome / 1.94;

            Console.WriteLine($"{euro:f2}");

        }
    }
}
