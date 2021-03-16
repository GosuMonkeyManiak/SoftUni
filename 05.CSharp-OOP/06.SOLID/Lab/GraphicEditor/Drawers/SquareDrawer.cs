using System;
using GraphicEditor.Contracts;
using GraphicEditor.Models;

namespace GraphicEditor.Drawers
{
    public class SquareDrawer : IDrawer
    {
        public void Draw()
        {
            Console.WriteLine("Drawing square");
        }

        public bool IsMatch(IShape shape)
        {
            return shape is Square;
        }
    }
}