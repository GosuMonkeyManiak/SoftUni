using System;

namespace ChangeBureau
{
    class ChangeBureau
    {
        static void Main(string[] args)
        {
            int bitCoint = int.Parse(Console.ReadLine());
            double chinaCoint = double.Parse(Console.ReadLine());
            double commission = double.Parse(Console.ReadLine());

            //need euro
            double lev = bitCoint * 1168;
            double dollar = chinaCoint * 0.15;
            lev += dollar * 1.76;

            double euro = lev / 1.95;

            double taxForcommission = (commission / 100) * euro;
            euro -= taxForcommission;

            Console.WriteLine($"{euro:f2}");
        }
    }
}
