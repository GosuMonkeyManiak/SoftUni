using System;

namespace Shapes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IDrawable rectangle = new Rectangle(4, 8);

            rectangle.Draw();

            IDrawable circle = new Circle(6);

            circle.Draw();
        }
    }
}
