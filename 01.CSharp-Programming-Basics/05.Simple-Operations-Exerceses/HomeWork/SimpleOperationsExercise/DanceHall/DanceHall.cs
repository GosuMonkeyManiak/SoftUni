using System;

namespace DanceHall
{
    class DanceHall
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double wardrobeSide = double.Parse(Console.ReadLine());

            double allArea = (length * 100) * (width * 100);
            double squareArea = (wardrobeSide * 100) * (wardrobeSide * 100);
            double beachArea = allArea / 10;

            double freeArea = (allArea - squareArea) - beachArea;

            double dancers = freeArea / (40 + 7000);

            Console.WriteLine(Math.Floor(dancers));
        }
    }
}
