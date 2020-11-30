using System;

namespace Harvest
{
    class Harvest
    {
        static void Main(string[] args)
        {
            int squareMeterPlain = int.Parse(Console.ReadLine());
            double gravesPerOneSquareMeter = double.Parse(Console.ReadLine());
            int needLiterWine = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double plainForWine = squareMeterPlain * 0.4;
            double graves = plainForWine * gravesPerOneSquareMeter;
            double wine = graves / 2.5;

            if (wine >= needLiterWine)
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wine)} liters.");
                double remainWine = wine - needLiterWine;
                Console.WriteLine($"{Math.Ceiling(remainWine)} liters left -> {Math.Ceiling(remainWine / workers)} liters per person.");
            }
            else
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(needLiterWine - wine)} liters wine needed.");
            }
        }
    }
}
