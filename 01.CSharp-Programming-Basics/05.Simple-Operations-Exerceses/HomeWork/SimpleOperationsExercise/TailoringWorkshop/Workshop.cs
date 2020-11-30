using System;

namespace TailoringWorkshop
{
    class Workshop
    {
        static void Main(string[] args)
        {
            int tableCount = int.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine()); //дължина
            double width = double.Parse(Console.ReadLine()); //широчина

            double squareMetersForTableCloth = tableCount * ((length + 2 * 0.30) * (width + 2 * 0.30));
            double squareMetersForCoach = tableCount * ((length/2) * (length/2));

            double allSum = squareMetersForTableCloth * 7 + squareMetersForCoach * 9;
            double allSumInBGN = allSum * 1.85;

            Console.WriteLine($"{allSum:f2} USD");
            Console.WriteLine($"{allSumInBGN:f2} BGN");
        }
    }
}
