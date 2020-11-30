using System;

namespace AreaAndTourCircle
{
    class AreaAndTourCircle
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());

            double area = Math.PI * Math.Pow(r,2);
            double tour = 2 * Math.PI * r;

            Console.WriteLine($"{area:f2}");
            Console.WriteLine($"{tour:f2}");
        }
    }
}
