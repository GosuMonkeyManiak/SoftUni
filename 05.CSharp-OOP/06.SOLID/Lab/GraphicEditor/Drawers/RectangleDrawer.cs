using System;
using GraphicEditor.Contracts;
using GraphicEditor.Models;

namespace GraphicEditor.Drawers
{
    public class RectangleDrawer : IDrawer
    {
        public void Draw()
        {
            Console.WriteLine("Drawing rectangle");
        }

        public bool IsMatch(IShape shape)
        {
            return shape is Rectangle;
        }
    }
}