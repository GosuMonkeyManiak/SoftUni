using System;

namespace CleverLily
{
    class CleverLily
    {
        static void Main(string[] args)
        {
            int liliYears = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            int priceForOneToy = int.Parse(Console.ReadLine());

            int toys = 0;
            int money = 0;
            int moneyforBirth = 10;

            for (int i = 1; i <= liliYears; i++)
            {
                if (i % 2 == 0)
                {
                    money += moneyforBirth;
                    money -= 1;
                    moneyforBirth += 10;
                }
                else
                {
                    toys++;
                }
            }

            int toysMoney = toys * priceForOneToy;
            money += toysMoney;

            if (money >= washingMachinePrice)
            {
                Console.WriteLine($"Yes! {money - washingMachinePrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {washingMachinePrice - money:f2}");
            }

        }
    }
}
