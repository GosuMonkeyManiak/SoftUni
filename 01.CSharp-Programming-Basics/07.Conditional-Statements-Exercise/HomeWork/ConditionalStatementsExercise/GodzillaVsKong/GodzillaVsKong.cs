using System;

namespace GodzillaVsKong
{
    class GodzillaVsKong
    {
        static void Main(string[] args)
        {
            double moneyForMovie = double.Parse(Console.ReadLine());
            int countStatist = int.Parse(Console.ReadLine());
            double priceForOneClothesForStatics = double.Parse(Console.ReadLine());

            double costMoney = moneyForMovie * 0.1;

            double moneyForStatists = countStatist * priceForOneClothesForStatics;

            if (countStatist > 150)
            {
                double disCount = moneyForStatists * 0.1;
                moneyForStatists -= disCount;
            }

            costMoney += moneyForStatists;

            if (costMoney <= moneyForMovie)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {moneyForMovie - costMoney:f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {costMoney - moneyForMovie:f2} leva more.");
            }
        }
    }
}
