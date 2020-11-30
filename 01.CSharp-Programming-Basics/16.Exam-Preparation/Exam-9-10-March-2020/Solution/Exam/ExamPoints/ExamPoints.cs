using System;

namespace ExamPoints
{
    class ExamPoints
    {
        static void Main(string[] args)
        {
            int exe = int.Parse(Console.ReadLine());
            int points = int.Parse(Console.ReadLine());
            string course = Console.ReadLine();

            double bonusPoints = 0.0;

            switch (course)
            {
                case "Basics":
                    if (exe == 1)
                    {
                        bonusPoints = points * 0.08;

                        double deCreased = bonusPoints * 0.2;
                        bonusPoints -= deCreased;
                    }
                    else if (exe == 2)
                    {
                        bonusPoints = points * 0.09;
                    }
                    else if (exe == 3)
                    {
                        bonusPoints = points * 0.09;
                    }
                    else
                    {
                        bonusPoints = points * 0.1;
                    }
                    break;

                case "Fundamentals":
                    if (exe == 1)
                    {
                        bonusPoints = points * 0.11;
                    }
                    else if (exe == 2)
                    {
                        bonusPoints = points * 0.11;
                    }
                    else if (exe == 3)
                    {
                        bonusPoints = points * 0.12;
                    }
                    else
                    {
                        bonusPoints = points * 0.13;
                    }
                    break;

                case "Advanced":
                    if (exe == 1)
                    {
                        bonusPoints = points * 0.14;
                    }
                    else if (exe == 2)
                    {
                        bonusPoints = points * 0.14;
                    }
                    else if (exe == 3)
                    {
                        bonusPoints = points * 0.15;
                    }
                    else
                    {
                        bonusPoints = points * 0.16;
                    }

                    double bonus = bonusPoints * 0.20;
                    bonusPoints += bonus;
                    break;
            }

            Console.WriteLine($"Total points: {bonusPoints:f2}");
        }
    }
}
