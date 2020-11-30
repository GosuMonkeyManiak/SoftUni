using System;

namespace BeehivePopulation
{
    class BeehivePopulation
    {
        static void Main(string[] args)
        {
            int startPopulation = int.Parse(Console.ReadLine());
            int years = int.Parse(Console.ReadLine());

            for (int i = 1; i <= years; i++)
            {
                int newBees = (startPopulation / 10) * 2;
                startPopulation += newBees;

                if (i > 1 && i % 5 == 0)
                {
                    int imigramet = (startPopulation / 50) * 5;
                    startPopulation -= imigramet;
                }

                int dieBees = (startPopulation / 20) * 2;
                startPopulation -= dieBees;
            }

            Console.WriteLine($"Beehive population: {startPopulation}");
        }
    }
}
