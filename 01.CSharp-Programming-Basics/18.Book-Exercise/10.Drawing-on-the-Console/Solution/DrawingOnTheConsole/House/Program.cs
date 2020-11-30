using System;

namespace House
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int starts = 1;
            if (n % 2 == 0)
            {
                starts++;
            }

            int roofLength = (int)Math.Ceiling(n / 2f);

            for (int i = 0; i < roofLength; i++)
            {
                int padding = (n - starts) / 2;

                Console.Write(new string('-',padding));
                Console.Write(new string('*',starts));
                Console.Write(new string('-', padding));
                Console.WriteLine();

                starts += 2;
            }

            int floorLength = (int)Math.Floor(n / 2f);

            for (int i = 0; i < floorLength; i++)
            {
                Console.Write("|");
                Console.Write(new string('*',n - 2));
                Console.Write("|");
                Console.WriteLine();
            }
        }
    }
}
