using System;

namespace ExcellentResult
{
    class Program
    {
        static void Main(string[] args)
        {
            double great = double.Parse(Console.ReadLine());

            if (great >= 5.50)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}
