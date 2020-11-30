using System;

namespace WeatherForecast
{
    class WeatherForecastPTTwo
    {
        static void Main(string[] args)
        {
            double forecast = double.Parse(Console.ReadLine());

            if (forecast < 5)
            {
                Console.WriteLine("unknown");
            }
            else if (forecast <= 11.9)
            {
                Console.WriteLine("Cold");
            }
            else if (forecast <= 14.9)
            {
                Console.WriteLine("Cool");
            }
            else if (forecast <= 20)
            {
                Console.WriteLine("Mild");
            }
            else if (forecast <= 25.9)
            {
                Console.WriteLine("Warm");
            }
            else if (forecast <= 35)
            {
                Console.WriteLine("Hot");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
