namespace AlcoholMarket
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            double whiskeyPrice = double.Parse(Console.ReadLine());

            double beеrLiters = double.Parse(Console.ReadLine());
            double wineLiters = double.Parse(Console.ReadLine());
            double rakiqLiters = double.Parse(Console.ReadLine());
            double whiskeyLiters = double.Parse(Console.ReadLine());

            double rakiqPrice = whiskeyPrice / 2;
            double winePrice = rakiqPrice - (rakiqPrice * 0.40);
            double beerPrice = rakiqPrice - (rakiqPrice * 0.80);

            double neededMoneyForAlcohol = (whiskeyLiters * whiskeyPrice)
                                           + (rakiqLiters * rakiqPrice)
                                           + (wineLiters * winePrice)
                                           + (beеrLiters * beerPrice);

            Console.WriteLine($"{neededMoneyForAlcohol:f2}");
        }
    }
}
