using System;

namespace Shapes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Shape rectangle = new Circle(6);

            Console.WriteLine(rectangle.Draw());
        }
    }
}
