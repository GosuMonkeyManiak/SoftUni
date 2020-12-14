using System;
using System.Linq;

namespace BonusScoringSystem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numberStudentInCourse = int.Parse(Console.ReadLine());
            int numberLecture = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            double maxScore = 0;
            int attended = 0;

            for (int i = 0; i < numberStudentInCourse; i++)
            {
                int currentAtetnded = int.Parse(Console.ReadLine());

                double currentScore = currentAtetnded * 1.0 / numberLecture * (5 + additionalBonus);

                if (currentScore > maxScore)
                {
                    maxScore = currentScore;
                    attended = currentAtetnded;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxScore)}.");
            Console.WriteLine($"The student has attended {attended} lectures.");
        }
    }
}
