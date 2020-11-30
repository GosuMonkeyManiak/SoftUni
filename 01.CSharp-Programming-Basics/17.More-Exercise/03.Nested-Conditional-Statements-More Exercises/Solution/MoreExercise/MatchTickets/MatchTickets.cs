using System;

namespace MatchTickets
{
    class MatchTickets
    {
        static void Main(string[] args)
        {
            //•	VIP – 499.99 лева.
            //•	Normal – 249.99 лева.

            double buget = double.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            int guys = int.Parse(Console.ReadLine());

            double price = buget;
            double transportPrice = 0.0;

            if (guys >= 1 && guys <= 4)
            {
                transportPrice = buget * 0.75;
            }
            else if (guys <= 9)
            {
                transportPrice = buget * 0.60;
            }
            else if (guys <= 24)
            {
                transportPrice = buget * 0.50;
            }
            else if (guys <= 49)
            {
                transportPrice = buget * 0.40;
            }
            else
            {
                transportPrice = buget * 0.25;
            }

            price -= transportPrice;

            if (type == "VIP")
            {
                price -= guys * 499.99;

                if (price >= 0)
                {
                    Console.WriteLine($"Yes! You have {price:f2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money! You need {Math.Abs(price):f2} leva.");
                }
            }
            else
            {
                price -= guys * 249.99;

                if (price >= 0)
                {
                    Console.WriteLine($"Yes! You have {price:f2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money! You need {Math.Abs(price):f2} leva.");
                }
            }
        }
    }
}
