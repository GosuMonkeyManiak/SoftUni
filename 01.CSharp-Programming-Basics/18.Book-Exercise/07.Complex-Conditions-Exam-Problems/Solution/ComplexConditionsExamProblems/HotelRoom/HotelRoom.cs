using System;

namespace HotelRoom
{
    class HotelRoom
    {
        static void Main(string[] args)
        {
            string mounth = Console.ReadLine().ToLower();
            int nights = int.Parse(Console.ReadLine());

            double moneyForApartament = 0.0;
            double moneyForStudio = 0.0;

            switch (mounth)
            {
                case "may":
                case "october":
                    if (nights > 14)
                    {
                        moneyForApartament = nights * 65;
                        double discount = moneyForApartament * 0.1;
                        moneyForApartament -= discount;
                    }
                    else
                    {
                        moneyForApartament = nights * 65;
                    }

                    if (nights > 14)
                    {
                        moneyForStudio = nights * 50;
                        double discount = moneyForStudio * 0.3;
                        moneyForStudio -= discount;
                    }
                    else if (nights > 7)
                    {

                        moneyForStudio = nights * 50;
                        double discount = moneyForStudio * 0.05;
                        moneyForStudio -= discount;
                    }
                    else
                    {
                        moneyForStudio = nights * 50;
                    }
                    break;

                case "june":
                case "september":
                    if (nights > 14)
                    {
                        moneyForApartament = nights * 68.70;
                        double discount = moneyForApartament * 0.1;
                        moneyForApartament -= discount;
                    }
                    else
                    {
                        moneyForApartament = nights * 68.70;
                    }

                    if (nights > 14)
                    {
                        moneyForStudio = nights * 75.20;
                        double discount = moneyForStudio * 0.2;
                        moneyForStudio -= discount;
                    }
                    else
                    {
                        moneyForStudio = nights * 75.20;
                    }
                    break;

                case "july":
                case "august":
                    if (nights > 14)
                    {
                        moneyForApartament = nights * 77;
                        double discount = moneyForApartament * 0.1;
                        moneyForApartament -= discount;
                    }
                    else
                    {
                        moneyForApartament = nights * 77;
                    }

                    moneyForStudio = nights * 76;
                    break;
            }

            Console.WriteLine($"Apartment: {moneyForApartament:f2} lv.");
            Console.WriteLine($"Studio: {moneyForStudio:f2} lv.");
        }
    }
}
