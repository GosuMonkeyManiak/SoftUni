using System;

namespace Grades
{
    class Grades
    {
        static void Main(string[] args)
        {
            int studentOnExam = int.Parse(Console.ReadLine());

            double countTwo = 0;
            double countThree = 0;
            double countFour = 0;
            double countAbove = 0;

            double allGrades = 0;

            for (int i = 0; i < studentOnExam; i++)
            {
                double grade = double.Parse(Console.ReadLine());

                allGrades += grade;

                if (grade >= 2.00 && grade <= 2.99)
                {
                    countTwo++;
                }
                else if (grade <= 3.99)
                {
                    countThree++;
                }
                else if (grade <= 4.99)
                {
                    countFour++;
                }
                else
                {
                    countAbove++;
                }
            }

            Console.WriteLine($"Top students: {countAbove / studentOnExam * 100:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {countFour / studentOnExam * 100:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {countThree / studentOnExam * 100:f2}%");
            Console.WriteLine($"Fail: {countTwo / studentOnExam * 100:f2}%");
            Console.WriteLine($"Average: {allGrades / studentOnExam:f2}");
        }
    }
}
