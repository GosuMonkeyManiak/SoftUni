using System;

namespace EnergyBooster
{
    class EnergyBooster
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine().ToLower();
            string setSize = Console.ReadLine(); //small or big
            int coutOrderSets = int.Parse(Console.ReadLine());

            double needMoney = 0.0;

            switch (fruit)
            {
                case "watermelon":
                    if (setSize == "small")
                    {
                        needMoney += (2 * 56) * coutOrderSets;
                    }
                    else
                    {
                        needMoney += (5 * 28.70) * coutOrderSets;
                    }
                    break;

                case "mango":
                    if (setSize == "small")
                    {
                        needMoney += (2 * 36.66) * coutOrderSets;
                    }
                    else
                    {
                        needMoney += (5 * 19.60) * coutOrderSets;
                    }
                    break;

                case "pineapple":
                    if (setSize == "small")
                    {
                        needMoney += (2 * 42.10) * coutOrderSets;
                    }
                    else
                    {
                        needMoney += (5 * 24.80) * coutOrderSets;
                    }
                    break;

                case "raspberry":
                    if (setSize == "small")
                    {
                        needMoney += (2 * 20) * coutOrderSets;
                    }
                    else
                    {
                        needMoney += (5 * 15.20) * coutOrderSets;
                    }
                    break;
            }

            if (needMoney >= 400 && needMoney <= 1000)
            {
                double discount = needMoney * 0.15;
                needMoney -= discount;
            }
            else if (needMoney > 1000)
            {
                double discount = needMoney * 0.50;
                needMoney -= discount;
            }

            Console.WriteLine($"{needMoney:f2} lv.");
        }
    }
}
