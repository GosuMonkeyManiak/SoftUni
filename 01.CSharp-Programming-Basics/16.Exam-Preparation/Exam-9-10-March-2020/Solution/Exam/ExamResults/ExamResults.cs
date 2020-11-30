using System;

namespace ExamResults
{
    class ExamResults
    {
        static void Main(string[] args)
        {
            bool isCheat = false;

            while (true)
            {
                string student = Console.ReadLine();
                if (student == "Midnight")
                {
                    break;
                }

                int studentPoints = 0;

                for (int i = 1; i <= 6; i++)
                {
                    int pointsForExe = int.Parse(Console.ReadLine());

                    if (pointsForExe < 0)
                    {
                        Console.WriteLine($"{student} was cheating!");
                        isCheat = true;
                        break;
                    }

                    studentPoints += pointsForExe;
                }

                if (isCheat)
                {
                    isCheat = false;
                    continue;
                }

                double equalization = Math.Floor((1.0 * studentPoints / 600) * 100);
                double mark = equalization * 0.06;

                if (mark > 5)
                {
                    for (int first = 0; first < 19; first++)
                    {
                        Console.Write("=");
                    }
                    Console.WriteLine();

                    Console.Write("|");

                    for (int space1 = 0; space1 < 3; space1++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write("CERTIFICATE");

                    for (int space2 = 0; space2 < 3; space2++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write("|");

                    Console.WriteLine();

                    Console.Write("|");
                    for (int space2 = 0; space2 < 4; space2++)
                    {
                        Console.Write(" ");
                    }

                    Console.Write($"{mark:f2}/6.00");

                    for (int space2 = 0; space2 < 4; space2++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write("|");
                                       
                    Console.WriteLine();
                    for (int last = 0; last < 19; last++)
                    {
                        Console.Write("=");
                    }

                    Console.WriteLine();
                    Console.Write($"Issued to {student}");
                    Console.WriteLine();
                }
                else if (mark < 3)
                {
                    Console.WriteLine($"{student} - 2.00");
                }
                else
                {
                    Console.WriteLine($"{student} - {mark:f2}");
                }
            }
        }
    }
}
