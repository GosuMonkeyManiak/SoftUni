using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    class StartUp
    {
        static void Main(string[] args)
        {

            int numbersOfWave = int.Parse(Console.ReadLine());

            List<int> plates = new List<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int index = 0;

            Stack<int> orcs = new Stack<int>();

            for (int i = 1; i <= numbersOfWave; i++)
            {
                orcs = new Stack<int>(Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse));

                if (i % 3 == 0)
                {
                    int plate = int.Parse(Console.ReadLine());
                    plates.Add(plate);
                }


                while (orcs.Count > 0 && plates.Count > 0)
                {
                    int plate = plates[index];
                    int orc = orcs.Peek();

                    if (plate == orc)
                    {
                        plates.RemoveAt(index);
                        orcs.Pop();
                    }
                    else if (plate > orc)
                    {
                        orcs.Pop();
                        plates[index] -= orc;

                        if (plates[index] <= 0)
                        {
                            plates.RemoveAt(index);
                        }
                        //decrease a first plate
                    }
                    else if (orc > plate)
                    {
                        plates.RemoveAt(index);
                        orc -= plate;

                        if (orc <= 0)
                        {
                            orcs.Pop();
                        }
                        else
                        {
                            orcs.Pop();
                            orcs.Push(orc);
                        }

                    }

                }

                if (plates.Count <= 0)
                {
                    break;
                }
            }

            if (plates.Count > 0)
            {
                Console.WriteLine($"The people successfully repulsed the orc's attack.");
            }
            else
            {
                Console.WriteLine($"The orcs successfully destroyed the Gondor's defense.");
            }

            if (orcs.Count > 0)
            {
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }

            if (plates.Count > 0)
            {
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
