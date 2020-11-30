using System;

namespace TruckDriver
{
    class TruckDriver
    {
        static void Main(string[] args)
        {
            //one season 4 month
            string season = Console.ReadLine();
            double kilometerForMonth = double.Parse(Console.ReadLine());

            double kilometerForSeason = 4 * kilometerForMonth;
            double inCome = 0.0;

            if (kilometerForMonth <= 5000)
            {
                if (season == "Spring" || season == "Autumn")
                {
                    inCome = kilometerForSeason * 0.75;
                }
                else if (season == "Summer")
                {
                    inCome = kilometerForSeason * 0.90;
                }
                else
                {
                    inCome = kilometerForSeason * 1.05;
                }
            }
            else if (kilometerForMonth <= 10000)
            {
                if (season == "Spring" || season == "Autumn")
                {
                    inCome = kilometerForSeason * 0.95;
                }
                else if (season == "Summer")
                {
                    inCome = kilometerForSeason * 1.10;
                }
                else
                {
                    inCome = kilometerForSeason * 1.25;
                }
            }
            else if (kilometerForMonth <= 20000)
            {
                inCome = kilometerForSeason * 1.45;
            }

            double tax = inCome * 0.10;
            inCome -= tax;

            Console.WriteLine($"{inCome:f2}");
        }
    }
}
