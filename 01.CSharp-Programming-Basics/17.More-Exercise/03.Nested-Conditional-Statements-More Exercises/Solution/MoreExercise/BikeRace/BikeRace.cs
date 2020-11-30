using System;

namespace BikeRace
{
    class BikeRace
    {
        static void Main(string[] args)
        {
            int junior = int.Parse(Console.ReadLine());
            int senior = int.Parse(Console.ReadLine());
            string typeRoad = Console.ReadLine();

            int allVolunters = junior + senior;

            double moneyForCharity = 0.0;

            switch (typeRoad)
            {
                case "trail":
                    moneyForCharity = junior * 5.50;
                    moneyForCharity += senior * 7;
                    break;

                case "cross-country":
                    moneyForCharity = junior * 8;
                    moneyForCharity += senior * 9.50;

                    if (allVolunters >= 50)
                    {
                        double discount = moneyForCharity * 0.25;
                        moneyForCharity -= discount;
                    }
                    break;

                case "downhill":
                    moneyForCharity = junior * 12.25;
                    moneyForCharity += senior * 13.75;
                    break;

                case "road":
                    moneyForCharity = junior * 20;
                    moneyForCharity += senior * 21.50;
                    break;
            }

            double tax = moneyForCharity * 0.05;
            moneyForCharity -= tax;

            Console.WriteLine($"{moneyForCharity:f2}");
        }
    }
}
