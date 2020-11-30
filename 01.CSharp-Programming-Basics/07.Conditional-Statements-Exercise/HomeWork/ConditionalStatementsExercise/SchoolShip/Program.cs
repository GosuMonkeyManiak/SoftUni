using System;

namespace SchoolShip
{
    class Program
    {
        static void Main(string[] args)
        {
            double inCome = double.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());
            double minimalSalary = double.Parse(Console.ReadLine());

            double socialScholarShip = 0.0;
            double excellentScholarship = 0.0;

            if (inCome > minimalSalary)
            {
                Console.WriteLine("You cannot get a scholarship!");
                return;
            }
            if (averageGrade >= 5.5)
            {
                excellentScholarship = averageGrade * 25;
            }
            if (inCome < minimalSalary && averageGrade > 4.5)
            {
                socialScholarShip = minimalSalary * 0.35;
            }

            socialScholarShip = Math.Floor(socialScholarShip);
            excellentScholarship = Math.Floor(excellentScholarship);

            if (excellentScholarship > socialScholarShip)
            {
                Console.WriteLine($"You get a scholarship for excellent results {excellentScholarship} BGN");
            }
            else
            {
                Console.WriteLine($"You get a Social scholarship {socialScholarShip} BGN");
            }
        }
    }
}
