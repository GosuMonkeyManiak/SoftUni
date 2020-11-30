using System;

namespace ExamSubmissions
{
    class ExamSubmissions
    {
        static void Main(string[] args)
        {
            int student = int.Parse(Console.ReadLine());
            int exercises = int.Parse(Console.ReadLine());

            double allSubmissions = student * Math.Ceiling(exercises * 2.8);

            int bonusExe = student * (int)(exercises / 3);
            allSubmissions += bonusExe;

            double needKb = 5 * Math.Ceiling(allSubmissions / 10);

            Console.WriteLine($"{needKb} KB needed");
            Console.WriteLine($"{allSubmissions} submissions");
        }
    }
}
