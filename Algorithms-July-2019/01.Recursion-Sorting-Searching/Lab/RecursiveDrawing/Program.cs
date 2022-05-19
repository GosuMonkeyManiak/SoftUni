namespace RecursiveDrawing
{
    using System;

    public class Program
    {
        public static void Print(int n)
        {
            if (n == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', n));

            Print(n - 1);

            Console.WriteLine(new string('#', n));
        }

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Print(n);
        }
    }
}
