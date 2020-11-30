using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Пъзел - 2.60 лв.
            //•	Говореща кукла -3 лв.
            //•	Плюшено мече -4.10 лв.
            //•	Миньон - 8.20 лв.
            //•	Камионче - 2 лв.

            double vacationPrice = double.Parse(Console.ReadLine());
            int countPuzzle = int.Parse(Console.ReadLine());
            int countDoll = int.Parse(Console.ReadLine());
            int countBears = int.Parse(Console.ReadLine());
            int countMiners = int.Parse(Console.ReadLine());
            int countTrucks = int.Parse(Console.ReadLine());

            int allToys = countPuzzle + countDoll + countBears + countMiners + countTrucks;

            double allMoney = 0.0;
            allMoney += countPuzzle * 2.60;
            allMoney += countDoll * 3;
            allMoney += countBears * 4.10;
            allMoney += countMiners * 8.20;
            allMoney += countTrucks * 2;

            if (allToys >= 50)
            {
                double discount = allMoney * 0.25;
                allMoney -= discount;
            }

            double tax = allMoney * 0.1;
            allMoney -= tax;

            if (allMoney >= vacationPrice)
            {
                double remainMoney = allMoney - vacationPrice;
                Console.WriteLine($"Yes! {remainMoney:f2} lv left.");
            }
            else
            {
                double notReamin = vacationPrice - allMoney;
                Console.WriteLine($"Not enough money! {notReamin:f2} lv needed.");
            }
        }
    }
}
