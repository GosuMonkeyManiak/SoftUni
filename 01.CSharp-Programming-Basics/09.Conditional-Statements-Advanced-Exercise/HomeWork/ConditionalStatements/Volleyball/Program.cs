namespace Volleyball
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            string typeOfYear = Console.ReadLine();
            int holidays = int.Parse(Console.ReadLine());
            int numberOfWeekendTravel = int.Parse(Console.ReadLine());

            double holidaysPlay = holidays * (2.0 / 3.0);
            double homeCityPlay = numberOfWeekendTravel;
            double playInSofia = (48 - numberOfWeekendTravel) * 3 / 4.0;

            double allPlayDays = holidaysPlay + homeCityPlay + playInSofia;

            if (typeOfYear == "leap")
            {
                allPlayDays *= 1.15;
            }

            Console.WriteLine(Math.Floor(allPlayDays));
        }
    }
}