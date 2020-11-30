using System;

namespace TwoDRectangleArea
{
    class TwoDRectangleArea
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double width = Math.Max(x1, x2) - Math.Min(x1, x2);
            double height = Math.Max(y1, y2) - Math.Min(y1, y2);

            Console.WriteLine(width * height);
            Console.WriteLine(2 * (width + height));
        }
    }
}
