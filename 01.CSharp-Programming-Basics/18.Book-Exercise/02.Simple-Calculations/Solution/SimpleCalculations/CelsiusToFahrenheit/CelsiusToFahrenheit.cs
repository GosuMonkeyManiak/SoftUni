using System;

namespace CelsiusToFahrenheit
{
    class CelsiusToFahrenheit
    {
        static void Main(string[] args)
        {
            double celsius = double.Parse(Console.ReadLine());

            double fahrenheit = (celsius * 9) / 5 + 32;

            Console.WriteLine(Math.Round(fahrenheit, 2));
        }
    }
}
