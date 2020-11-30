using System;

namespace HousePainting
{
    class HousePainting
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double frontWall = (x * x) - (1.2 * 2); // green
            double backWall = x * x; //green 

            double sideWallRight = (x * y) - (1.5 * 1.5); //green
            double sideWallLeftl = (x * y) - (1.5 * 1.5); //green

            double allAreaForWalls = frontWall + backWall + sideWallLeftl + sideWallRight;

            double roofSideRight = x * y;
            double roofSideLeft = x * y;
            double roofTriangleFront = (x * h) / 2;
            double roofTriangleBack = (x * h) / 2;

            double allAreaForRoof = roofSideLeft + roofSideRight + roofTriangleFront + roofTriangleBack;

            double greenPaint = allAreaForWalls / 3.4;
            double redPaint = allAreaForRoof / 4.3;

            Console.WriteLine($"{greenPaint:f2}");
            Console.WriteLine($"{redPaint:f2}");
        }
    }
}
