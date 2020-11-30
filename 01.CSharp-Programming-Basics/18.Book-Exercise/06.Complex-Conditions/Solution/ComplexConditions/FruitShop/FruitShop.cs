using System;

namespace FruitShop
{
    class FruitShop
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine().ToLower();
            string dayOfweek = Console.ReadLine().ToLower();
            double ammount = double.Parse(Console.ReadLine());

            double price = 0.0;

            bool isDayOfWorkWeek = dayOfweek == "monday" || dayOfweek == "tuesday" || dayOfweek == "wednesday" || dayOfweek == "thursday" || dayOfweek == "friday";
            bool isDayOfWeekend = dayOfweek == "saturday" || dayOfweek == "sunday";

            switch (fruit)
            {
                case "banana":
                    if (isDayOfWorkWeek)
                    {
                        price = ammount * 2.50;
                    }
                    else if (isDayOfWeekend)
                    {
                        price = ammount * 2.70;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;

                case "apple":
                    if (isDayOfWorkWeek)
                    {
                        price = ammount * 1.20;
                    }
                    else if (isDayOfWeekend)
                    {
                        price = ammount * 1.25;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;

                case "orange":
                    if (isDayOfWorkWeek)
                    {
                        price = ammount * 0.85;
                    }
                    else if (isDayOfWeekend)
                    {
                        price = ammount * 0.90;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;

                case "grapefruit":
                    if (isDayOfWorkWeek)
                    {
                        price = ammount * 1.45;
                    }
                    else if (isDayOfWeekend)
                    {
                        price = ammount * 1.60;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;

                case "kiwi":
                    if (isDayOfWorkWeek)
                    {
                        price = ammount * 2.70;
                    }
                    else if (isDayOfWeekend)
                    {
                        price = ammount * 3.00;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;

                case "pineapple":
                    if (isDayOfWorkWeek)
                    {
                        price = ammount * 5.50;
                    }
                    else if (isDayOfWeekend)
                    {
                        price = ammount * 5.60;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;

                case "grapes":
                    if (isDayOfWorkWeek)
                    {
                        price = ammount * 3.85;
                    }
                    else if (isDayOfWeekend)
                    {
                        price = ammount * 4.20;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;

                default:
                    Console.WriteLine("error");
                    break;
            }

            Console.WriteLine($"{price:f2}");
        }
    }
}
