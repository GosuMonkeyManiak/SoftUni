using System;

namespace CelsiusТоFrarenheit
{
    class CelsiusТоFrarenheit
    {
        static void Main(string[] args)
        {
            double celsius = double.Parse(Console.ReadLine());

            double fahrenheit = celsius * 1.8 + 32.00;

            Console.WriteLine($"{fahrenheit:f2}");
        }
    }
}
