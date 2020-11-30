using System;

namespace SmallShop
{
    class SmallShop
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double ammount = double.Parse(Console.ReadLine());
            double money = 0.0;

            switch (city)
            {
                case "Sofia":
                    if (product == "coffee")
                    {
                        money = ammount * 0.50;
                    }
                    else if (product == "water")
                    {
                        money = ammount * 0.80;
                    }
                    else if (product == "beer")
                    {
                        money = ammount * 1.20;
                    }
                    else if (product == "sweets")
                    {
                        money = ammount * 1.45;
                    }
                    else
                    {
                        money = ammount * 1.60;
                    }
                    break;

                case "Plovdiv":
                    if (product == "coffee")
                    {
                        money = ammount * 0.40;
                    }
                    else if (product == "water")
                    {
                        money = ammount * 0.70;
                    }
                    else if (product == "beer")
                    {
                        money = ammount * 1.15;
                    }
                    else if (product == "sweets")
                    {
                        money = ammount * 1.30;
                    }
                    else
                    {
                        money = ammount * 1.50;
                    }
                    break;

                case "Varna":
                    if (product == "coffee")
                    {
                        money = ammount * 0.45;
                    }
                    else if (product == "water")
                    {
                        money = ammount * 0.70;
                    }
                    else if (product == "beer")
                    {
                        money = ammount * 1.10;
                    }
                    else if (product == "sweets")
                    {
                        money = ammount * 1.35;
                    }
                    else
                    {
                        money = ammount * 1.55;
                    }
                    break;

                default:
                    break;
            }

            Console.WriteLine(money);
        }
    }
}
