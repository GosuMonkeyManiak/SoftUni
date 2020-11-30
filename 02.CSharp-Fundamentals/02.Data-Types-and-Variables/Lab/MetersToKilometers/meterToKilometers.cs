using System;

namespace MetersToKilometers
{
    class meterToKilometers
    {
        static void Main(string[] args)
        {
            uint meters = uint.Parse(Console.ReadLine());

            decimal kilometers = meters / 1000.0M;

            Console.WriteLine($"{kilometers:f2}");
        }
    }
}
