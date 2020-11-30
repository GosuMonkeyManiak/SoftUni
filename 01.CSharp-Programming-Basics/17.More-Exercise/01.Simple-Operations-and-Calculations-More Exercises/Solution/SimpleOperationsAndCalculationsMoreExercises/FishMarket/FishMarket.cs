using System;

namespace FishMarket
{
    class FishMarket
    {
        static void Main(string[] args)
        {
            double priceKgSkumriq = double.Parse(Console.ReadLine());
            double priceKgCaca = double.Parse(Console.ReadLine());

            double kgPalamut = double.Parse(Console.ReadLine());
            double kgSafrit = double.Parse(Console.ReadLine());
            int kgMussels = int.Parse(Console.ReadLine());

            //mussels - 7.50
            //safrit - 80% more of caca
            //palamut - 60% more of skumriq

            double musselsPrice = 7.50;
            double safritPrice = priceKgCaca * 0.8;
            safritPrice += priceKgCaca;
            double palamutPrice = priceKgSkumriq * 0.6;
            palamutPrice += priceKgSkumriq;

            double allPrice = kgPalamut * palamutPrice;
            allPrice += kgSafrit * safritPrice;
            allPrice += kgMussels * musselsPrice;

            Console.WriteLine($"{allPrice:f2}");
        }
    }
}
