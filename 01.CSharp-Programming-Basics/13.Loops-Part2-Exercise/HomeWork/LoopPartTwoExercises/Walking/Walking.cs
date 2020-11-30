using System;

namespace Walking
{
    class Walking
    {
        static void Main(string[] args)
        {
            //10 000 стъпки всеки ден
            int goal = 10000;
            int allSteps = 0;
            bool goingHome = false;

            while (allSteps < goal)
            {
                string steps = Console.ReadLine();
                if (steps == "Going home")
                {
                    int stepToHome = int.Parse(Console.ReadLine());
                    allSteps += stepToHome;
                    goingHome = true;
                    break;
                }

                int stepS = int.Parse(steps);

                allSteps += stepS;
            }

            if (goingHome)
            {
                if (allSteps >= goal)
                {
                    Console.WriteLine("Goal reached! Good job!");
                }
                else
                {
                    Console.WriteLine($"{goal - allSteps} more steps to reach goal.");
                }
            }
            else if (allSteps >= goal)
            {
                Console.WriteLine("Goal reached! Good job!");
            }
            else
            {
                    Console.WriteLine($"{goal - allSteps} more steps to reach goal.");

            }
        }
    }
}
