using System;

namespace TicketsForMatch
{
    class TicketsForMatch
    {
        static void Main(string[] args)
        {
            double buget = double.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());

            double moneyForTransport = 0.0;

            if (people >= 1 && people <= 4)
            {
                moneyForTransport = buget * 0.75;
                //75
            }
            else if (people <= 9)
            {
                moneyForTransport = buget * 0.6;
                //60
            }
            else if (people <= 24)
            {
                moneyForTransport = buget * 0.5;
                //50 
            }
            else if (people <= 49)
            {
                moneyForTransport = buget * 0.4;
                //40
            }
            else
            {
                moneyForTransport = buget * 0.25;
                //25
            }

            buget -= moneyForTransport;

            if (type == "VIP")
            {
                double moneyForTicket = people * 499.99;
                buget -= moneyForTicket;
            }
            else
            {
                double moneyForTicket = people * 249.99;
                buget -= moneyForTicket;
            }

            if (buget >= 0)
            {
                Console.WriteLine($"Yes! You have {buget:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(buget):f2} leva.");
            }
        }
    }
}
