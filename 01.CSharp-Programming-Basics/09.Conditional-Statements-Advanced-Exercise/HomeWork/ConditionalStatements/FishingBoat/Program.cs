namespace FishingBoat
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numberOfFishermen = int.Parse(Console.ReadLine());

            double moneyToPayFotBoat = 0.0;

            switch (season.ToLower())
            {
                case "spring":
                    moneyToPayFotBoat = 3000;

                    if (numberOfFishermen <= 6)
                    {
                        moneyToPayFotBoat *= (1 - 0.10);
                    }
                    else if (numberOfFishermen <= 11)
                    {
                        moneyToPayFotBoat *= (1 - 0.15);
                    }
                    else
                    {
                        moneyToPayFotBoat *= (1 - 0.25);
                    }

                    if (numberOfFishermen % 2 == 0)
                    {
                        moneyToPayFotBoat *= (1 - 0.05);
                    }
                    break;

                case "summer":
                case "autumn":
                    moneyToPayFotBoat = 4200;

                    if (numberOfFishermen <= 6)
                    {
                        moneyToPayFotBoat *= (1 - 0.10);
                    }
                    else if (numberOfFishermen <= 11)
                    {
                        moneyToPayFotBoat *= (1 - 0.15);
                    }
                    else
                    {
                        moneyToPayFotBoat *= (1 - 0.25);
                    }

                    if (season.ToLower() == "summer" && numberOfFishermen % 2 == 0)
                    {
                        moneyToPayFotBoat *= (1 - 0.05);
                    }
                    break;

                case "winter":
                    moneyToPayFotBoat = 2600;

                    if (numberOfFishermen <= 6)
                    {
                        moneyToPayFotBoat *= (1 - 0.10);
                    }
                    else if (numberOfFishermen <= 11)
                    {
                        moneyToPayFotBoat *= (1 - 0.15);
                    }
                    else
                    {
                        moneyToPayFotBoat *= (1 - 0.25);
                    }

                    if (numberOfFishermen % 2 == 0)
                    {
                        moneyToPayFotBoat *= (1 - 0.05);
                    }
                    break;
            }

            if (budget >= moneyToPayFotBoat)
            {
                Console.WriteLine($"Yes! You have {budget - moneyToPayFotBoat:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {moneyToPayFotBoat - budget:f2} leva.");   
            }
        }
    }
}
