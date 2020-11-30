using System;

namespace SuitcasesLoad
{
    class SuitcasesLoad
    {
        static void Main(string[] args)
        {
            double volumeRack = double.Parse(Console.ReadLine());
            int count = 1;
            int suitCases = 0;

            while (volumeRack > 0)
            {
                string textSuitcase = Console.ReadLine();
                if (textSuitcase == "End")
                {
                    Console.WriteLine("Congratulations! All suitcases are loaded!");
                    break;
                }

                double volumeSuitcas = 0;

                if (count % 3 == 0)
                {
                    volumeSuitcas = double.Parse(textSuitcase);
                    double increased = volumeSuitcas * 0.1;
                    volumeSuitcas += increased;
                    suitCases++;
                }
                else
                {
                    volumeSuitcas = double.Parse(textSuitcase);
                    suitCases++;
                }

                volumeRack -= volumeSuitcas;

                count++;
            }

            if (volumeRack < 0)
            {
                Console.WriteLine("No more space!");
                suitCases--;
            }

            Console.WriteLine($"Statistic: {suitCases} suitcases loaded.");
        }
    }
}
