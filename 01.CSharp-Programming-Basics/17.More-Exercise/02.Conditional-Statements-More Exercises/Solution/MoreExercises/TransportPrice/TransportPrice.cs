using System;

namespace TransportPrice
{
    class TransportPrice
    {
        static void Main(string[] args)
        {
            //inPut 
            //km and day or night
            //bus to 20 km
            //train to 100km
            int km = int.Parse(Console.ReadLine());
            string partOfDay = Console.ReadLine();

            double price = 0;

            if (km >= 100)
            {
                price = km * 0.06;
            }
            else if (km >= 20)
            {
                price = km * 0.09;
            }
            else
            {
                double startPrice = 0.70;

                if (partOfDay == "day")
                {
                    price += startPrice;
                    price += km * 0.79;
                }
                else
                {
                    price += startPrice;
                    price += km * 0.90;
                }
            }

            Console.WriteLine($"{price:f2}");
        }
    }
}
