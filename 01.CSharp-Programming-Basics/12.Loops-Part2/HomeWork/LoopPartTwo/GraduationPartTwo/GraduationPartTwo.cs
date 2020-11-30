using System;

namespace GraduationPartTwo
{
    class GraduationPartTwo
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();

            int classCount = 1;
            double allGrades = 0.0;
            int torn = 0;

            while (classCount <= 12)
            {
                if (torn > 1)
                {
                    break;
                }
                double grade = double.Parse(Console.ReadLine());
                if (grade < 4.00)
                {
                    torn++;
                    continue;
                }
                else
                {
                    classCount++;
                    allGrades += grade;
                }
            }

            double averageGrade = allGrades / 12;

            if (torn > 1)
            {
                Console.WriteLine($"{studentName} has been excluded at {classCount} grade");
            }
            else
            {
                Console.WriteLine($"{studentName} graduated. Average grade: {averageGrade:f2}");
            }
        }
    }
}
