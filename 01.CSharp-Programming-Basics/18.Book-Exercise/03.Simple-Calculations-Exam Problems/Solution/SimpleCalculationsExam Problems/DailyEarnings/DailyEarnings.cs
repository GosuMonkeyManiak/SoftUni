using System;

namespace DailyEarnings
{
    class DailyEarnings
    {
        static void Main(string[] args)
        {
            int workDayInMonth = int.Parse(Console.ReadLine());
            double moneyForDay = double.Parse(Console.ReadLine());
            double dolarInlev = double.Parse(Console.ReadLine());

            double moneyForOneMonth = workDayInMonth * moneyForDay;//dolar
            double moneyForOneYear = (moneyForOneMonth * 12) + (moneyForOneMonth * 2.5);//dolar

            double tax = moneyForOneYear * 0.25;//dolar
            moneyForOneYear -= tax;//dolar

            moneyForOneYear *= dolarInlev;

            Console.WriteLine($"{moneyForOneYear / 365:f2}");

        }
    }
}
