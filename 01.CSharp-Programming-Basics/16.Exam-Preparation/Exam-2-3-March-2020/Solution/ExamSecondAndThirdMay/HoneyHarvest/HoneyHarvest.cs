using System;

namespace HoneyHarvest
{
    class HoneyHarvest
    {
        static void Main(string[] args)
        {
            string typeFlower = Console.ReadLine().ToLower();
            int numberFlowers = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double allHoneys = 0;

            switch (typeFlower)
            {
                case "sunflower":
                    if (season == "Spring")
                    {
                        allHoneys = numberFlowers * 10;
                    }
                    else if (season == "Summer")
                    {
                        allHoneys = numberFlowers * 8;
                    }
                    else
                    {
                        allHoneys = numberFlowers * 12;
                    }
                    break;

                case "daisy":
                    if (season == "Spring")
                    {
                        allHoneys = numberFlowers * 12;
                        double tempBonus = allHoneys * 0.1;
                        allHoneys += tempBonus;
                    }
                    else if (season == "Summer")
                    {
                        allHoneys = numberFlowers * 8;
                    }
                    else
                    {
                        allHoneys = numberFlowers * 6;
                    }
                    break;//Warning

                case "lavender":
                    if (season == "Spring")
                    {
                        allHoneys = numberFlowers * 12;
                    }
                    else if (season == "Summer")
                    {
                        allHoneys = numberFlowers * 8;
                    }
                    else
                    {
                        allHoneys = numberFlowers * 6;
                    }
                    break;

                case "mint":
                    if (season == "Spring")
                    {
                        allHoneys = numberFlowers * 10;
                        double tempBonus = allHoneys * 0.1;
                        allHoneys += tempBonus;
                    }
                    else if (season == "Summer")
                    {
                        allHoneys = numberFlowers * 12;
                    }
                    else
                    {
                        allHoneys = numberFlowers * 6;
                    }
                    break;//warnning
            }

            //if season == Summer 10% more honey
            //if season == Autumn 5% not more honey

            if (season == "Summer")
            {
                double bonus = allHoneys * 0.1;
                allHoneys += bonus;
            }
            else if (season == "Autumn")
            {
                double decreased = allHoneys * 0.05;
                allHoneys -= decreased;
            }

            Console.WriteLine($"Total honey harvested: {allHoneys:f2}");
        }
    }
}
