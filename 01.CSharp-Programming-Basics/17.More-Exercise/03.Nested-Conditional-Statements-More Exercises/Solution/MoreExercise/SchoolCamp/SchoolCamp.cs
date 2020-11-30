using System;

namespace SchoolCamp
{
    class SchoolCamp
    {
        static void Main(string[] args)
        {
            //intPut
            //season / boys,girls,mixed / numberStudent? / numberNight
            string season = Console.ReadLine();
            string typeStudent = Console.ReadLine();
            int numberStudent = int.Parse(Console.ReadLine());
            int numberNights = int.Parse(Console.ReadLine());

            double needMoney = 0.0;
            string typeSport = "";

            if (season == "Winter")
            {
                if (typeStudent == "boys" || typeStudent == "girls")
                {
                    needMoney = numberNights * 9.60 * numberStudent;

                    if (typeStudent == "boys")
                    {
                        typeSport = "Judo";
                    }
                    else
                    {
                        typeSport = "Gymnastics";
                    }
                }
                else
                {
                    needMoney = numberNights * 10 * numberStudent;
                    typeSport = "Ski";
                }
            }
            else if (season == "Spring")
            {
                if (typeStudent == "boys" || typeStudent == "girls")
                {
                    needMoney = numberNights * 7.20 * numberStudent;

                    if (typeStudent == "boys")
                    {
                        typeSport = "Tennis";
                    }
                    else
                    {
                        typeSport = "Athletics";
                    }
                }
                else
                {
                    needMoney = numberNights * 9.50 * numberStudent;
                    typeSport = "Cycling";
                }
            }
            else // Summer
            {
                if (typeStudent == "boys" || typeStudent == "girls")
                {
                    needMoney = numberNights * 15 * numberStudent;

                    if (typeStudent == "boys")
                    {
                        typeSport = "Football";
                    }
                    else
                    {
                        typeSport = "Volleyball";
                    }
                }
                else
                {
                    needMoney = numberNights * 20 * numberStudent;
                    typeSport = "Swimming";
                }
            }

            double discount = 0.0;

            if (numberStudent >= 50)
            {
                discount = needMoney * 0.50;
                needMoney -= discount;
            }
            else if (numberStudent >= 20)
            {
                discount = needMoney * 0.15;
                needMoney -= discount;
            }
            else if (numberStudent >= 10)
            {
                discount = needMoney * 0.05;
                needMoney -= discount;
            }

            Console.WriteLine($"{typeSport} {needMoney:f2} lv.");
        }
    }
}
