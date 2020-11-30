using System;

namespace Trip
{
    class Trip
    {
        static void Main(string[] args)
        {
            double buget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string distination = "";
            string typeRoom = "";

            double spendMoney = 0.0;

            if (buget <= 100)
            {
                distination = "Bulgaria";

                if (season == "summer")
                {
                    spendMoney = buget * 0.3;
                    typeRoom = "Camp";
                }
                else
                {
                    spendMoney = buget * 0.7;
                    typeRoom = "Hotel";
                }
            }
            else if (buget <= 1000)
            {
                distination = "Balkans";

                if (season == "summer")
                {
                    spendMoney = buget * 0.4;
                    typeRoom = "Camp";
                }
                else
                {
                    spendMoney = buget * 0.8;
                    typeRoom = "Hotel";
                }
            }
            else
            {
                distination = "Europe";
                spendMoney = buget * 0.9;
                typeRoom = "Hotel";
            }

            Console.WriteLine($"Somewhere in {distination}");
            Console.WriteLine($"{typeRoom} - {spendMoney:f2}");
        }
    }
}
