using System;
using GraphicEditor.Contracts;
using GraphicEditor.Models;

namespace GraphicEditor.Drawers
{
    public class CircleDrawer : IDrawer
    {
        public void Draw()
        {
            Console.WriteLine("Drawing circle");
        }

        public bool IsMatch(IShape shape)
        {
            return shape is Circle;
        }
    }
}