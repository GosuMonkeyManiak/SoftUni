using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRace
{
    class CarRace
    {
        static void Main(string[] args)
        {
            List<int> number = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            double firstCarTime = 0;
            double secondCarTime = 0;

            //firstCar
            for (int i = 0; i < number.Count / 2; i++)
            {
                if (number[i] == 0)
                {
                    double reduce = firstCarTime * 0.2;
                    firstCarTime -= reduce;
                    continue;
                }

                firstCarTime += number[i];
            }

            //secondCar
            for (int i = number.Count - 1; i > number.Count / 2; i--)
            {
                if (number[i] == 0)
                {
                    double reduce = secondCarTime * 0.2;
                    secondCarTime -= reduce;
                    continue;
                }

                secondCarTime += number[i];
            }

            if (firstCarTime < secondCarTime)
            {
                Console.WriteLine($"The winner is left with total time: {firstCarTime}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {secondCarTime}");
            }
        }
    }
}
