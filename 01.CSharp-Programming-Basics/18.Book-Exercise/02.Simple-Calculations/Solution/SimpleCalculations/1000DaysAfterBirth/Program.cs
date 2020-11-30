using System;
using System.Globalization;

namespace _1000DaysAfterBirth
{
    class Program
    {
        static void Main(string[] args)
        {

            string dateTime = Console.ReadLine();

            DateTime date = DateTime.ParseExact(dateTime, "dd-MM-yyyy",CultureInfo.InvariantCulture);

            date = date.AddDays(1000);

            Console.WriteLine(date.ToString("dd-MM-yyyy"));

        }
    }
}
