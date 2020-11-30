using System;

namespace FruitShop
{
    class FruitShop
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double ammount = double.Parse(Console.ReadLine());
            double lastPrice = 0.0;

            switch (dayOfWeek)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    if (fruit == "banana")
                    {
                        lastPrice = ammount * 2.50;
                    }
                    else if (fruit == "apple")
                    {
                        lastPrice = ammount * 1.20;
                    }
                    else if (fruit == "orange")
                    {
                        lastPrice = ammount * 0.85;
                    }
                    else if (fruit == "grapefruit")
                    {
                        lastPrice = ammount * 1.45;
                    }
                    else if (fruit == "kiwi")
                    {
                        lastPrice = ammount * 2.70;
                    }
                    else if (fruit == "pineapple")
                    {
                        lastPrice = ammount * 5.50;
                    }
                    else if (fruit == "grapes")
                    {
                        lastPrice = ammount * 3.85;
                    }
                    else
                    {
                        Console.WriteLine("error");
                        return;
                    }
                    break;

                case "Saturday":
                case "Sunday":
                    if (fruit == "banana")
                    {
                        lastPrice = ammount * 2.70;
                    }
                    else if (fruit == "apple")
                    {
                        lastPrice = ammount * 1.25;
                    }
                    else if (fruit == "orange")
                    {
                        lastPrice = ammount * 0.90;
                    }
                    else if (fruit == "grapefruit")
                    {
                        lastPrice = ammount * 1.60;
                    }
                    else if (fruit == "kiwi")
                    {
                        lastPrice = ammount * 3.00;
                    }
                    else if (fruit == "pineapple")
                    {
                        lastPrice = ammount * 5.60;
                    }
                    else if (fruit == "grapes")
                    {
                        lastPrice = ammount * 4.20;
                    }
                    else
                    {
                        Console.WriteLine("error");
                        return;
                    }
                    break;

                default:
                    Console.WriteLine("error");return;
                    break;
            }

            Console.WriteLine($"{lastPrice:f2}");
        }
    }
}
