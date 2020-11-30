using System;

namespace MetricConverter
{
    class MetricConverter
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            string from = Console.ReadLine();
            string Out = Console.ReadLine();

            if (from == "m")
            {
                if (Out == "cm")
                {
                    num *= 100;
                }
                else if (Out == "mm")
                {
                    num *= 1000;
                }
            }
            else if (from == "cm")
            {
                if (Out == "m")
                {
                    num /= 100;
                }
                else if (Out == "mm")
                {
                    num *= 10;
                }
            }
            else if (from == "mm")
            {
                if (Out == "cm")
                {
                    num /= 10;
                }
                else if (Out == "m")
                {
                    num /= 1000;
                }
            }

            Console.WriteLine($"{num:f3}");
        }
    }
}
