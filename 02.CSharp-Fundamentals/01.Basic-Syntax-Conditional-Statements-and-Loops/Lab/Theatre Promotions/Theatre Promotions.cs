using System;

namespace Theatre_Promotions
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfDay = Console.ReadLine().ToLower();
            int age = int.Parse(Console.ReadLine());

            int ticketPrice = 0;

            if (age < 0)
            {
                Console.WriteLine("Error!");
                return;
            }

            if (typeOfDay ==  "weekday")
            {
                if ((0 <= age && age <= 18) || (64 < age && age <= 122))
                {
                    ticketPrice = 12;
                }
                else if (age > 18 && age <= 64)
                {
                    ticketPrice = 18;
                }
                else //Error
                {
                    ticketPrice = 0;
                }
            }
            else if (typeOfDay == "weekend")
            {
                if ((0 <= age && age <= 18) || (64 < age && age <= 122))
                {
                    ticketPrice = 15;
                }
                else if (age > 18 && age <= 64)
                {
                    ticketPrice = 20;
                }
                else //Error
                {
                    ticketPrice = 0;
                }
            }
            else //holiday
            {
                if (age >= 0 && age <= 18)
                {
                    ticketPrice = 5;
                }
                else if (age > 18 && age <= 64)
                {
                    ticketPrice = 12;
                }
                else if (age > 64 && age <= 122)
                {
                    ticketPrice = 10;
                }
                else //Error
                {
                    ticketPrice = 0;
                }
            }

            if (ticketPrice != 0)
            {
                Console.WriteLine($"{ticketPrice}$");
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
