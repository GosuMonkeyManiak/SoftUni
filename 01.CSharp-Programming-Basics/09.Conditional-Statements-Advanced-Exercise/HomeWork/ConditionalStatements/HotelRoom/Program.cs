namespace HotelRoom
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int numberOfNight = int.Parse(Console.ReadLine());

            double moneyForApartment = 0.0;
            double moneyForStudio = 0.0;

            switch (month.ToLower())
            {
                case "may":
                case "october":
                    moneyForStudio = numberOfNight * 50;
                    moneyForApartment = numberOfNight * 65;
                    

                    if (numberOfNight > 14)
                    {
                        moneyForStudio *= (1 - 0.3);
                    }
                    else if (numberOfNight > 7)
                    {
                        moneyForStudio *= (1 - 0.05);
                    }
                    break;

                case "june":
                case "september":
                    moneyForStudio = numberOfNight * 75.20;
                    moneyForApartment = numberOfNight * 68.70;

                    if (numberOfNight > 14)
                    {
                        moneyForStudio *= (1 - 0.2);
                    }
                    break;

                case "july":
                case "august":
                    moneyForStudio = numberOfNight * 76;
                    moneyForApartment = numberOfNight * 77;
                    break;
            }

            if (numberOfNight > 14)
            {
                moneyForApartment *= (1 - 0.1);
            }

            Console.WriteLine($"Apartment: {moneyForApartment:f2} lv.");
            Console.WriteLine($"Studio: {moneyForStudio:f2} lv.");
        }
    }
}
