using System;

namespace Harvest
{
    class Harvest
    {
        static void Main(string[] args)
        {
            //inPut
            //x square metees wine plane
            //40% fore wine 
            //1 square meters income Y kg grapes
            //1 liter wine need 2.5 kg grapes
            //Z wine for sell

            int grapesPlane = int.Parse(Console.ReadLine());
            double grapesLeterFromOneSquareMeters = double.Parse(Console.ReadLine());
            int needLitersForSell = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double grapesForWine = grapesPlane * 0.4;
            double wineKg = grapesForWine * grapesLeterFromOneSquareMeters;
            double wineLites = wineKg / 2.5;

            if (wineLites < needLitersForSell)
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(needLitersForSell - wineLites)} liters wine needed.");
            }
            else
            {
                double leftLiters = wineLites - needLitersForSell;
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wineLites)} liters.");
                Console.WriteLine($"{Math.Ceiling(leftLiters)} liters left -> {Math.Ceiling(leftLiters / workers)} liters per person.");
            }

        }
    }
}
