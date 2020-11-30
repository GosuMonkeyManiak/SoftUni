using System;

namespace SkiTrip
{
    class SkiTrip
    {
        static void Main(string[] args)
        {
            //"room for one person" – 18.00 лв за нощувка
            //"apartment" – 25.00 лв за нощувка
            //"president apartment" – 35.00 лв за нощувка

            int days = int.Parse(Console.ReadLine());
            string kindRoom = Console.ReadLine();
            string gradeForHotel = Console.ReadLine();
            int nights = days;

            if (days > 0)
            {
                nights = days - 1;
            }

            double price = 0.0;
            double discount = 0.0;

            if (kindRoom == "room for one person")
            {
                price = nights * 18;
            }
            else if (kindRoom == "apartment")
            {
                price = nights * 25;

                if (nights < 10)
                {
                    discount = price * 0.30;
                    price -= discount;
                }
                else if(nights >= 10 || nights <= 15)
                {
                    discount = price * 0.35;
                    price -= discount;
                }
                else
                {
                    discount = price * 0.50;
                    price -= discount;
                }
            }
            else
            {
                price = nights * 35;

                if (nights < 10)
                {
                    discount = price * 0.10;
                    price -= discount;
                }
                else if(nights >= 10 && nights <= 15)
                {
                    discount = price * 0.15;
                    price -= discount;
                }
                else
                {
                    discount = price * 0.20;
                    price -= discount;
                }
            }

            discount = 0;

            if (gradeForHotel == "positive")
            {
                discount = price * 0.25;
                price += discount;
            }
            else
            {
                discount = price * 0.10;
                price -= discount;
            }

            Console.WriteLine($"{price:f2}");

        }
    }
}
