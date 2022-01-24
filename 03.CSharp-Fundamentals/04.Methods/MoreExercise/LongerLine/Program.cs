namespace LongerLine
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            //double first = Math.Sqrt(Math.Pow(y1, 2) + Math.Pow(x1, 2));
            //double secound = Math.Sqrt(Math.Pow(y2, 2) + Math.Pow(x2, 2));

            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            Console.WriteLine(LongerLine(x1, y1, x2, y2, x3, y3, x4, y4));
        }

        static string LongerLine(
            double x1,
            double y1,
            double x2,
            double y2,
            double x3,
            double y3,
            double x4,
            double y4)
        {
            double firstLineDistance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            double secondLineDistance = Math.Sqrt(Math.Pow(x4 - x3, 2) + Math.Pow(y4 - y3, 2));

            if (firstLineDistance > secondLineDistance)
            {
                double firstPoint = Math.Sqrt(Math.Pow(x1 - 0, 2) + Math.Pow(y1 - 0, 2));
                double secondPoint = Math.Sqrt(Math.Pow(x2 - 0, 2) + Math.Pow(y2 - 0, 2));

                if (firstPoint > secondPoint)
                {
                    return $"({x2}, {y2})({x1}, {y1})";
                }
                else
                {   
                    return $"({x1}, {y1})({x2}, {y2})";
                }
            }
            else
            {
                double thirdPoint = Math.Sqrt(Math.Pow(x3 - 0, 2) + Math.Pow(y3 - 0, 2));
                double fourthPoint = Math.Sqrt(Math.Pow(x4 - 0, 2) + Math.Pow(y4 - 0, 2));

                if (thirdPoint > fourthPoint)
                {
                    return $"({x4}, {y4})({x3}, {y3})";
                }
                else
                {   
                    return $"({x3}, {y3})({x4}, {y4})";
                }
            }
        }
    }
}
