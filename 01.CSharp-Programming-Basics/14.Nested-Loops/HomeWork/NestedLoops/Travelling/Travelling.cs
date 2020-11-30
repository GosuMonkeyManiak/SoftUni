using System;

namespace Travelling
{
    class Travelling
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string distination = Console.ReadLine();
                if (distination == "End")
                {
                    break;
                }

                int buget = int.Parse(Console.ReadLine());

                while (buget > 0)
                {
                    int currentMoney = int.Parse(Console.ReadLine());
                    buget -= currentMoney;
                }

                Console.WriteLine($"Going to {distination}!");
            }
        }
    }
}
