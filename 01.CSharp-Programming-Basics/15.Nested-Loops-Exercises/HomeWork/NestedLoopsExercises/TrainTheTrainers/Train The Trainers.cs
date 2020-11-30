using System;

namespace TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int countJudge = int.Parse(Console.ReadLine());

            int countGrades = 0;
            double allGrades = 0;

            while (true)
            {
                string currentNameProject = Console.ReadLine();
                if (currentNameProject == "Finish")
                {
                    Console.WriteLine($"Student's final assessment is {allGrades / countGrades:f2}.");
                    break;
                }

                double currentAvetageGrade = 0;
                double currentGradeSum = 0;

                for (int i = 1; i <= countJudge; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    currentGradeSum += grade;

                    allGrades += grade;
                    countGrades++;
                }

                currentAvetageGrade = currentGradeSum / countJudge;

                Console.WriteLine($"{currentNameProject} - {currentAvetageGrade:f2}.");
                currentAvetageGrade = 0;
                currentGradeSum = 0;
            }
        }
    }
}
