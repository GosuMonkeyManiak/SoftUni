namespace GraphicEditor.Contracts
{
    public interface IDrawer
    {
        void Draw();

        bool IsMatch(IShape shape);
    }
}