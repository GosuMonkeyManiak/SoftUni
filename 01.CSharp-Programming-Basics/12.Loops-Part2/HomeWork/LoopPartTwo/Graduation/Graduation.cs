using System;

namespace Graduation
{
    class Graduation
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();

            int classCount = 0;
            double averageGrade = 0.0;
            double allGrade = 0.0;

            while (classCount < 12)
            {
                double grade = double.Parse(Console.ReadLine());

                if (grade < 4.00)
                {
                    continue;
                }
                else
                {
                    allGrade += grade;
                    classCount++;
                }
            }

            averageGrade = allGrade / 12;
            Console.WriteLine($"{studentName} graduated. Average grade: {averageGrade:f2}");
        }
    }
}
