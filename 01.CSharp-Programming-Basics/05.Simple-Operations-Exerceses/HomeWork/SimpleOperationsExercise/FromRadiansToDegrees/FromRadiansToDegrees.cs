using System;

namespace FromRadiansToDegrees
{
    class FromRadiansToDegrees
    {
        static void Main(string[] args)
        {
            double rad = double.Parse(Console.ReadLine());

            double degrees = rad * 180 / Math.PI;

            Console.WriteLine(Math.Round(degrees));
        }
    }
}
