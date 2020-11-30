using System;

namespace CalculateRectangleArea
{
    class CalculateRectangleArea
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double area = RectangleArea(width, height);

            Console.WriteLine(area);
        }

        public static double RectangleArea(double width, double height)
        {
            double area = width * height;
            return area;
        }
    }
}
