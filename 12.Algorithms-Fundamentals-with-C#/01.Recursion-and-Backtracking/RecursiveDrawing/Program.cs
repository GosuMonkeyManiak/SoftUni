namespace RecursiveDrawing
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            DrawFigure(n);
        }

        public static void DrawFigure(int n)
        {
            if (n == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', n));

            DrawFigure(n - 1);

            Console.WriteLine(new string('#', n));
        }
    }
}