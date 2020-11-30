using System;

namespace AreaOfFigures
{
    class AreaOfFigures
    {
        static void Main(string[] args)
        {
            string typeFigure = Console.ReadLine().ToLower();

            double area = 0.0;

            switch (typeFigure)
            {
                case "square":
                    double a = double.Parse(Console.ReadLine());
                    area = a * a;
                    break;

                case "rectangle":
                    double b = double.Parse(Console.ReadLine());
                    double c = double.Parse(Console.ReadLine());
                    area = b * c;
                    break;

                case "circle":
                    double r = double.Parse(Console.ReadLine());
                    area = Math.PI * Math.Pow(r, 2);
                    break;

                case "triangle":
                    double e = double.Parse(Console.ReadLine());
                    double h = double.Parse(Console.ReadLine());
                    area = e * h / 2;
                    break;
            }

            Console.WriteLine($"{area}");
        }
    }
}
