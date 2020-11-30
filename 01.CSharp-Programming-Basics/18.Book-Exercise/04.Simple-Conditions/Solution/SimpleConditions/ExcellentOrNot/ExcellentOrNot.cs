using System;

namespace ExcellentOrNot
{
    class ExcellentOrNot
    {
        static void Main(string[] args)
        {
            double mark = double.Parse(Console.ReadLine());

            if (mark >= 5.50)
            {
                Console.WriteLine("Excellent!");
            }
            else
            {
                Console.WriteLine("Not excellent.");
            }
        }
    }
}
