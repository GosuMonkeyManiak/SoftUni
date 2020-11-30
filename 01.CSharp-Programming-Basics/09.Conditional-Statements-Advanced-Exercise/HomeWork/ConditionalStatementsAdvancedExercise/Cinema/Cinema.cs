using System;

namespace Cinema
{
    class Cinema
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int allSeat = r * c;

            double income = 0.0;

            if (type == "Premiere")
            {
                income = allSeat * 12;
            }
            else if (type == "Normal")
            {
                income = allSeat * 7.50;
            }
            else if (type == "Discount")
            {
                income = allSeat * 5;
            }

            Console.WriteLine($"{income:f2} leva");
        }
    }
}
