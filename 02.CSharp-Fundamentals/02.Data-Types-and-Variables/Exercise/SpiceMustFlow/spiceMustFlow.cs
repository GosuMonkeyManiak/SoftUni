using System;

namespace SpiceMustFlow
{
    class spiceMustFlow
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());

            int totalSpice = 0;
            ushort workedDays = 0;

            while (startingYield >= 100)
            {
                totalSpice += startingYield;

                if (totalSpice >= 26)
                {
                    totalSpice -= 26;
                }

                startingYield -= 10;
                workedDays++;
            }

            if (totalSpice >= 26)
            {
                totalSpice -= 26;
            }

            Console.WriteLine(workedDays);
            Console.WriteLine(totalSpice);

        }
    }
}
