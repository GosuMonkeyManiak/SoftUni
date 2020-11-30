using System;

namespace FootballLeague
{
    class FootballLeague
    {
        static void Main(string[] args)
        {
            int stadionCapacity = int.Parse(Console.ReadLine());
            int allFens = int.Parse(Console.ReadLine());

            int firstTeamFens = 0; // A And B
            int secondTeamFens = 0; //V and G
            double sectorA = 0;
            double sectorB = 0;
            double sectorV = 0;
            double sectorG = 0;

            for (int i = 0; i < allFens; i++)
            {
                string sector = Console.ReadLine();

                if (sector == "A")
                {
                    firstTeamFens++;
                    sectorA++;
                }
                else if (sector == "B")
                {
                    firstTeamFens++;
                    sectorB++;
                }
                else if (sector == "V")
                {
                    secondTeamFens++;
                    sectorV++;
                }
                else
                {
                    secondTeamFens++;
                    sectorG++;
                }

            }


            Console.WriteLine($"{(sectorA / allFens) * 100:f2}%");
            Console.WriteLine($"{(sectorB / allFens) * 100:f2}%");
            Console.WriteLine($"{(sectorV / allFens) * 100:f2}%");
            Console.WriteLine($"{(sectorG / allFens) * 100:f2}%");
            Console.WriteLine($"{(allFens / (double)stadionCapacity) * 100:f2}%");

        }
    }
}
