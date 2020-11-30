using System;
using System.Net.NetworkInformation;

namespace FlowersShop
{
    class FlowersShop
    {
        static void Main(string[] args)
        {
            int hrizantemi = int.Parse(Console.ReadLine());
            int rose = int.Parse(Console.ReadLine());
            int laleta = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string holyDay = Console.ReadLine();

            double price = 0;

            if (holyDay == "Y")
            {
                if (season == "Spring" || season == "Summer")
                {
                    price += hrizantemi * 2.00;
                    price += rose * 4.10;
                    price += laleta * 2.50;
                }
                else
                {
                    price += hrizantemi * 3.75;
                    price += rose * 4.50;
                    price += laleta * 4.15;
                }

                double percent1 = price * 0.15;
                price += percent1;

                if (season == "Spring" && laleta > 7)
                {
                    double percent = price * 0.05;
                    price -= percent;
                }
                if (season == "Winter" && rose >= 10)
                {
                    double percent = price * 0.10;
                    price -= percent;
                }

                int allFlower = hrizantemi + rose + laleta;

                if (allFlower > 20)
                {
                    double percent = price * 0.20;
                    price -= percent;
                }

            }
            else
            {
                if (season == "Spring" || season == "Summer")
                {
                    price += hrizantemi * 2.00;
                    price += rose * 4.10;
                    price += laleta * 2.50;
                }
                else
                {
                    price += hrizantemi * 3.75;
                    price += rose * 4.50;
                    price += laleta * 4.15;
                }

                if (season == "Spring" && laleta > 7)
                {
                    double percent = price * 0.05;
                    price -= percent;
                }
                if (season == "Winter" && rose >= 10)
                {
                    double percent = price * 0.10;
                    price -= percent;
                }

                int allFlower = hrizantemi + rose + laleta;

                if (allFlower > 20)
                {
                    double percent = price * 0.20;
                    price -= percent;
                }
            }

            price += 2;

            Console.WriteLine($"{price:f2}");
        }
    }
}
