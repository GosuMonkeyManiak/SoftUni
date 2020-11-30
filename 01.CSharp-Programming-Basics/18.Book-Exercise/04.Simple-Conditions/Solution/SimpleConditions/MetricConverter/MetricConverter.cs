using System;

namespace MetricConverter
{
    class MetricConverter
    {
        static void Main(string[] args)
        {
            double inPutPrameter = double.Parse(Console.ReadLine());
            string from = Console.ReadLine().ToLower();
            string until = Console.ReadLine().ToLower();

            double result = 0.0;

            if (from == "m")
            {
                if (until == "mm")
                {
                    result = inPutPrameter * 1000;
                }
                else if (until == "cm")
                {
                    result = inPutPrameter * 100;
                }
                else if (until == "mi")
                {
                    result = inPutPrameter * 0.000621371192;
                }
                else if (until == "in")
                {
                    result = inPutPrameter * 39.3700787;
                }
                else if (until == "km")
                {
                    result = inPutPrameter * 0.001;
                }
                else if (until == "ft")
                {
                    result = inPutPrameter * 3.2808399;
                }
                else if (until == "yd")
                {
                    result = inPutPrameter * 1.093613;
                }
            }
            else if (from == "mm")
            {
                if (until == "m")
                {
                    result = inPutPrameter / 1000;
                }
                else if (until == "cm")
                {
                    double temp = inPutPrameter / 1000;
                    result = temp * 100;
                }
                else if (until == "mi")
                {
                    double temp = inPutPrameter / 1000;
                    result = temp * 0.000621371192;
                }
                else if (until == "in")
                {
                    double temp = inPutPrameter / 1000;
                    result = temp * 39.3700787;
                }
                else if (until == "km")
                {
                    double temp = inPutPrameter / 1000;
                    result = temp * 0.001;
                }
                else if (until == "ft")
                {
                    double temp = inPutPrameter / 1000;
                    result = temp * 3.2808399;
                }
                else if (until == "yd")
                {
                    double temp = inPutPrameter / 1000;
                    result = temp * 1.0936133;
                }
            }
            else if (from == "cm")
            {
                if (until == "mm")
                {
                    double temp = inPutPrameter / 100;
                    result = temp * 1000;
                }
                else if (until == "m")
                {
                    result = inPutPrameter / 100;
                }
                else if (until == "mi")
                {
                    double temp = inPutPrameter / 100;
                    result = temp * 0.000621371192;
                }
                else if (until == "in")
                {
                    double temp = inPutPrameter / 100;
                    result = temp * 39.3700787;
                }
                else if (until == "km")
                {
                    double temp = inPutPrameter / 100;
                    result = temp * 0.001;
                }
                else if (until == "ft")
                {
                    double temp = inPutPrameter / 100;
                    result = temp * 3.2808399;
                }
                else if (until == "yd")
                {
                    double temp = inPutPrameter / 100;
                    result = temp * 1.0936133;
                }
            }
            else if (from == "mi")
            {
                if (until == "mm")
                {
                    double temp = inPutPrameter / 0.000621371192;
                    result = temp * 1000;
                }
                else if (until == "cm")
                {
                    double temp = inPutPrameter / 0.000621371192;
                    result = temp * 100;
                }
                else if (until == "m")
                {
                    result = inPutPrameter / 0.000621371192;
                }
                else if (until == "in")
                {
                    double temp = inPutPrameter / 0.000621371192;
                    result = temp * 39.3700787;
                }
                else if (until == "km")
                {
                    double temp = inPutPrameter / 0.000621371192;
                    result = temp * 0.001;
                }
                else if (until == "ft")
                {
                    double temp = inPutPrameter / 0.000621371192;
                    result = temp * 3.2808399;
                }
                else if (until == "yd")
                {
                    double temp = inPutPrameter / 0.000621371192;
                    result = temp * 1.0936133;
                }
            }
            else if (from == "in")
            {
                if (until == "mm")
                {
                    double temp = inPutPrameter / 39.3700787;
                    result = temp * 1000;
                }
                else if (until == "cm")
                {
                    double temp = inPutPrameter / 39.3700787;
                    result = temp * 100;
                }
                else if (until == "mi")
                {
                    double temp = inPutPrameter / 39.3700787;
                    result = temp * 0.000621371192;
                }
                else if (until == "m")
                {
                    result = inPutPrameter / 39.3700787;
                }
                else if (until == "km")
                {
                    double temp = inPutPrameter / 39.3700787;
                    result = temp * 0.001;
                }
                else if (until == "ft")
                {
                    double temp = inPutPrameter / 39.3700787;
                    result = temp * 3.2808399;
                }
                else if (until == "yd")
                {
                    double temp = inPutPrameter / 39.3700787;
                    result = temp * 1.0936133;
                }
            }
            else if (from == "km")
            {
                if (until == "mm")
                {
                    double temp = inPutPrameter / 0.001;
                    result = temp * 1000;
                }
                else if (until == "cm")
                {
                    double temp = inPutPrameter / 0.001;
                    result = temp * 100;
                }
                else if (until == "mi")
                {
                    double temp = inPutPrameter / 0.001;
                    result = temp * 0.000621371192;
                }
                else if (until == "in")
                {
                    double temp = inPutPrameter / 0.001;
                    result = temp * 39.3700787;
                }
                else if (until == "m")
                {
                    result = inPutPrameter / 0.001;
                }
                else if (until == "ft")
                {
                    double temp = inPutPrameter / 0.001;
                    result = temp * 3.2808399;
                }
                else if (until == "yd")
                {
                    double temp = inPutPrameter / 0.001;
                    result = temp * 1.0936133;
                }
            }
            else if (from == "ft")
            {
                if (until == "mm")
                {
                    double temp = inPutPrameter / 3.2808399;
                    result = temp * 1000;
                }
                else if (until == "cm")
                {
                    double temp = inPutPrameter / 3.2808399;
                    result = temp * 100;
                }
                else if (until == "mi")
                {
                    double temp = inPutPrameter / 3.2808399;
                    result = temp * 0.000621371192;
                }
                else if (until == "in")
                {
                    double temp = inPutPrameter / 3.2808399;
                    result = temp * 39.3700787;
                }
                else if (until == "km")
                {
                    double temp = inPutPrameter / 3.2808399;
                    result = temp * 0.001;
                }
                else if (until == "m")
                {
                    result = inPutPrameter / 3.2808399;
                }
                else if (until == "yd")
                {
                    double temp = inPutPrameter / 3.2808399;
                    result = temp * 1.0936133;
                }
            }
            else if (from == "yd")
            {
                if (until == "mm")
                {
                    double temp = inPutPrameter / 1.0936133;
                    result = temp * 1000;
                }
                else if (until == "cm")
                {
                    double temp = inPutPrameter / 1.0936133;
                    result = temp * 100;
                }
                else if (until == "mi")
                {
                    double temp = inPutPrameter / 1.0936133;
                    result = temp * 0.000621371192;
                }
                else if (until == "in")
                {
                    double temp = inPutPrameter / 1.0936133;
                    result = temp * 39.3700787;
                }
                else if (until == "km")
                {
                    double temp = inPutPrameter / 1.0936133;
                    result = temp * 0.001;
                }
                else if (until == "ft")
                {
                    double temp = inPutPrameter / 1.0936133;
                    result = temp * 3.2808399;
                }
                else if (until == "m")
                {
                    result = inPutPrameter / 1.0936133;
                }
            }

            Console.WriteLine(result);
        }
    }
}
