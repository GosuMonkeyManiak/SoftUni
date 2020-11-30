using System;

namespace CircleAreaAndPerimeter
{
    class CircleAreaAndPerimeter
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the circle raidus. r = ");
            double r = double.Parse(Console.ReadLine());
            Console.WriteLine("Area = " + (Math.PI * r * r));
            Console.WriteLine("Perimeter = " + (2 * Math.PI * r));
        }
    }
}
