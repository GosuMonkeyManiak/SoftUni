using System;

namespace SmallShop
{
    class SmallShop
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine().ToLower();
            string city = Console.ReadLine().ToLower();
            double ammount = double.Parse(Console.ReadLine());

            double price = 0.0;

            switch (product)
            {
                case "coffee":
                    if (city == "sofia")
                    {
                        price = ammount * 0.50;
                    }
                    else if (city == "plovdiv")
                    {
                        price = ammount * 0.40;
                    }
                    else
                    {
                        price = ammount * 0.45;
                    }
                    break;

                case "water":
                    if (city == "sofia")
                    {
                        price = ammount * 0.80;
                    }
                    else if (city == "plovdiv")
                    {
                        price = ammount * 0.70;
                    }
                    else
                    {
                        price = ammount * 0.70;
                    }
                    break;

                case "beer":
                    if (city == "sofia")
                    {
                        price = ammount * 1.20;
                    }
                    else if (city == "plovdiv")
                    {
                        price = ammount * 1.15;
                    }
                    else
                    {
                        price = ammount * 1.10;
                    }
                    break;

                case "sweets":
                    if (city == "sofia")
                    {
                        price = ammount * 1.45;
                    }
                    else if (city == "plovdiv")
                    {
                        price = ammount * 1.30;
                    }
                    else
                    {
                        price = ammount * 1.35;
                    }
                    break;

                case "peanuts":
                    if (city == "sofia")
                    {
                        price = ammount * 1.60;
                    }
                    else if (city == "plovdiv")
                    {
                        price = ammount * 1.50;
                    }
                    else
                    {
                        price = ammount * 1.55;
                    }
                    break;
            }

            Console.WriteLine(price);
        }
    }
}
