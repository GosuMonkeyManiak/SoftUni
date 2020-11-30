using System;

namespace SmartLily
{
    class SmartLily
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double priceForWashingMachine = double.Parse(Console.ReadLine());
            int priceForToy = int.Parse(Console.ReadLine());

            int moneyForBirthday = 10;
            int toys = 0;
            int saveMoney = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    saveMoney += moneyForBirthday;
                    moneyForBirthday += 10;
                    saveMoney -= 1;
                }
                else
                {
                    toys++;
                }
            }

            double allMoney = saveMoney + (toys * priceForToy);

            if (allMoney >= priceForWashingMachine)
            {
                Console.WriteLine($"Yes! {allMoney - priceForWashingMachine:f2}");
            }
            else
            {
                Console.WriteLine($"No! {priceForWashingMachine - allMoney:f2}");
            }
        }
    }
}
