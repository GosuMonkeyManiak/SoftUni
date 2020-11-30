using System;

namespace PointOnRectangleBorder
{
    class PointOnRectangleBorder
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            bool rightBorder = (x == x2) && (y >= y1 && y <= y2);
            bool leftBorder = (x == x1) && (y >= y1 && y <= y2);

            bool upBorder = (y == y1) && (x >= x1 && x <= x2);
            bool downBorder = (y == y2) && (x >= x1 && x <= x2);

            if (rightBorder || leftBorder || upBorder || downBorder)
            {
                Console.WriteLine("Border");
            }
            else
            {
                Console.WriteLine("Inside / Outside");
            }

        }
    }
}
