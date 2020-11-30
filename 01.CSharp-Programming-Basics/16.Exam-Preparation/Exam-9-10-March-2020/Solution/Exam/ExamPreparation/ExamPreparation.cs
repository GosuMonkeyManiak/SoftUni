using System;

namespace ExamPreparation
{
    class ExamPreparation
    {
        static void Main(string[] args)
        {
            int student = int.Parse(Console.ReadLine());
            int exercises = int.Parse(Console.ReadLine());
            int coachEnergy = int.Parse(Console.ReadLine());

            int solved = 0;
            int allQustions = 0;

            while (coachEnergy > 0)
            {
                solved += exercises;
                coachEnergy += exercises * 2;

                student -= exercises;

                int questions = student * 2;
                coachEnergy -= questions * 3;
                allQustions += questions;

                if (coachEnergy < 0)
                {
                    Console.WriteLine("The trainer is too tired!");
                    Console.WriteLine($"Questions answered: {allQustions}");
                    break;
                }

                if (student < 10)
                {
                    Console.WriteLine("The students are too few!");
                    Console.WriteLine($"Problems solved: {solved}");
                    break;
                }
                else
                {
                    int bonus = student / 10;
                    student += bonus;
                }


            }
        }
    }
}
