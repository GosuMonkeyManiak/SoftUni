using System;

namespace NextLevel
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double needExperience = double.Parse(Console.ReadLine());
            int countOfBattle = int.Parse(Console.ReadLine());

            double allExperience = 0;
            int battles = 0;

            while (allExperience < needExperience && battles < countOfBattle)
            {
                battles++;
                double currentExperience = double.Parse(Console.ReadLine());

                allExperience += currentExperience;

                if (battles % 3 == 0)
                {
                    double bonus = currentExperience * 0.15;
                    allExperience += bonus;
                }

                if (battles % 5 == 0)
                {
                    double less = currentExperience * 0.1;
                    allExperience -= less;
                }

                if (battles % 15 == 0)
                {
                    double bonus = currentExperience * 0.05;
                    allExperience += bonus;
                }
            }

            if (allExperience >= needExperience)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {battles} battles.");
            }
            else
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {needExperience - allExperience:f2} more needed.");
            }
        }
    }
}
