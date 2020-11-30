using System;

namespace PrintingTriangle
{
    class PrintingTriangle
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            for (int i = 1; i <= length; i++)
            {
                PrintLine(1, i);
            }

            for (int i = length - 1; i >= 1; i--)
            {
                PrintLine(1, i);
            }
        }

        public static void PrintLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
