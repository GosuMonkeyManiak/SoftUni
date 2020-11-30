using System;
using System.Runtime.InteropServices.ComTypes;

namespace ExamPreparation
{
    class ExamPreparation
    {
        static void Main(string[] args)
        {
            int nastyMarks = int.Parse(Console.ReadLine());

            double averageScore = 0.0;
            double sum = 0.0;
            int countNastyMark = 0;
            bool isFalsed = true;
            int Problems = 0;
            string lastProblem = "";

            while (countNastyMark < nastyMarks)
            {
                string nameExe = Console.ReadLine();
                if (nameExe == "Enough")
                {
                    isFalsed = false;
                    break;
                }

                int markExe = int.Parse(Console.ReadLine());
                if (markExe <= 4)
                {
                    countNastyMark++;
                }

                sum += markExe;
                lastProblem = nameExe;
                Problems++;
            }

            averageScore = sum / Problems;

            if (isFalsed)
            {
                Console.WriteLine($"You need a break, {nastyMarks} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {averageScore:f2}");
                Console.WriteLine($"Number of problems: {Problems}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}
