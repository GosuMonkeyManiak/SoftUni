using System;

namespace ConterStrike
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int startEnergy = int.Parse(Console.ReadLine());

            int wins = 0;

            while (true)
            {
                string distanceToEnemy = Console.ReadLine();
                if (distanceToEnemy == "End of battle")
                {
                    Console.WriteLine($"Won battles: {wins}. Energy left: {startEnergy}");
                    break;
                }

                if (startEnergy < int.Parse(distanceToEnemy))
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wins} won battles and {startEnergy} energy");
                    break;
                }

                startEnergy -= int.Parse(distanceToEnemy);
                wins++;

                if (wins % 3 == 0)
                {
                    startEnergy += wins;
                }
            }
        }
    }
}
