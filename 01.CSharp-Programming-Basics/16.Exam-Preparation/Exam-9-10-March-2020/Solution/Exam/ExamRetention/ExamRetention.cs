using System;

namespace ExamRetention
{
    class ExamRetention
    {
        static void Main(string[] args)
        {
            int student = int.Parse(Console.ReadLine());
            int seasons = int.Parse(Console.ReadLine());

            for (int i = 1; i <= seasons; i++)
            {
                double firstExam = Math.Ceiling(student * 0.9);
                double secondExam = Math.Ceiling(firstExam * 0.9);

                double contie = Math.Ceiling(secondExam * 0.8);

                double preWrite = 0;

                if (i % 3 == 0)
                {
                    double bonusStudent = Math.Ceiling(contie * 0.15);
                    preWrite = bonusStudent;
                }
                else
                {
                    double bonusStudent = Math.Ceiling(contie * 0.05);
                    preWrite = bonusStudent;
                }

                student = (int)(contie + preWrite);
            }

            Console.WriteLine($"Students: {student}");
        }
    }
}
