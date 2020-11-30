using System;

namespace PointInFigure
{
    class PointInFigure
    {
        static void Main(string[] args)
        {
            int h = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            bool insideFigure1 = (x > 0) && (x < 3 * h) && (y > 0) && (y < h);
            bool insideFigure2 = (x > h) && (x < 2 * h) && (y > h) && (y < 4 * h);
            bool insideBorder = (x > h) && (x < 2 * h) && (y == h);

            bool onBottomF1 = (0 <= x) && (x <= 3 * h) && (y == 0);
            bool onLeftSideF1 = (x == 0) && (y >= 0) && (y <= h);
            bool onRightSideF1 = (x == 3 * h) && (y >= 0) && (y <= h);
            bool onTopSideF1WithoutInsideBorder = ((x >= 0) && (x <= h) && (y == h) || (x >= 2 * h) && (x <= 3 * h) && (y == h));

            bool onLeftSideF2 = (x == h) && (y >= h) && (y <= 4 * h);
            bool onRightSideF2 = (x == 2 * h) && (y >= h) && (y <= 4 * h);
            bool onTopSideF2 = (x >= h) && (x <= 2 * h) && (y == 4 * h);


            if ((insideFigure1) || (insideFigure2) || (insideBorder))
            {
                Console.WriteLine("Inside");
            }
            else if ((onBottomF1) || (onLeftSideF1) || (onRightSideF1) || (onTopSideF1WithoutInsideBorder) || (onLeftSideF2) || (onRightSideF2) || (onTopSideF2))
            {
                Console.WriteLine("border");
            }
            else
            {
                Console.WriteLine("outside");
            }
        }
    }
}
