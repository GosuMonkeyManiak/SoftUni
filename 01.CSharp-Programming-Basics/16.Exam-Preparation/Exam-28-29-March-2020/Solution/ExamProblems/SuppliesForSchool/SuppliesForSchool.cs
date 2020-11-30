using System;

namespace SuppliesForSchool
{
    class SuppliesForSchool
    {
        static void Main(string[] args)
        {
            //•	Пакет химикали - 5.80 лв 
            //•	Пакет маркери -7.20 лв
            //•	Препарат - 1.20 лв(за литър)

            int pens = int.Parse(Console.ReadLine());
            int markes = int.Parse(Console.ReadLine());
            double sanitizer = double.Parse(Console.ReadLine()); //liter
            double percentDiscount = double.Parse(Console.ReadLine());

            double neededMoney = 0;
            neededMoney += pens * 5.80;
            neededMoney += markes * 7.20;
            neededMoney += sanitizer * 1.20;

            percentDiscount = percentDiscount / 100;
            double discount = neededMoney * percentDiscount;

            neededMoney -= discount;

            Console.WriteLine($"{neededMoney:f3}");
        }
    }
}
