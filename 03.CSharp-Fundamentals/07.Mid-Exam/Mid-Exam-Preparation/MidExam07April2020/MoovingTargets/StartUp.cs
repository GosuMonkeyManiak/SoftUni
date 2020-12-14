using System;
using System.Collections.Generic;
using System.Linq;

namespace MoovingTargets
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();

            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (commands[0] == "End")
                {
                    Console.WriteLine(string.Join('|', targets));
                    break;
                }


                switch (commands[0])
                {
                    case "Shoot":

                        int indexShoot = int.Parse(commands[1]);
                        int shootPower = int.Parse(commands[2]);

                        if (indexShoot < 0 || indexShoot > targets.Count - 1)
                        {
                            break;
                        }

                        if (targets[indexShoot] <= 0)
                        {
                            targets.RemoveAt(indexShoot);
                            break;
                        }

                        targets[indexShoot] -= shootPower;

                        if (targets[indexShoot] <= 0)
                        {
                            targets.RemoveAt(indexShoot);
                        }
                        break;

                    case "Add":

                        int addIndex = int.Parse(commands[1]);
                        int addValue = int.Parse(commands[2]);

                        if (addIndex < 0 || addIndex > targets.Count - 1)
                        {
                            Console.WriteLine("Invalid placement!");
                            break;
                        }

                        targets.Insert(addIndex, addValue);
                        break;

                    case "Strike":

                        int strikeIndex = int.Parse(commands[1]);
                        int strikeRadius = int.Parse(commands[2]);

                        if (strikeIndex < 0 + strikeRadius || strikeIndex > targets.Count - 1 - strikeRadius)
                        {
                            Console.WriteLine("Strike missed!");
                            break;
                        }

                        targets.RemoveRange(strikeIndex - strikeRadius, strikeRadius * 2 + 1);
                        break;
                }
            }
        }
    }
}
