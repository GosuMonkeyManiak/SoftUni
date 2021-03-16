using System.Collections.Generic;
using GraphicEditor.Contracts;

namespace GraphicEditor
{
    public class GraphicEditor
    {
        private List<IDrawer> drawers;

        public GraphicEditor(List<IDrawer> drawers)
        {
            this.drawers = new List<IDrawer>(drawers);
        }

        public void DrawShape(IShape shape)
        {
            foreach (var drawer in drawers)
            {
                if (drawer.IsMatch(shape))
                {
                    drawer.Draw();
                    return;
                }
            }
        }
    }
}