using System;

namespace SymbolInMatrix
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string inPut = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = inPut[col];
                }
            }

            char someChar = char.Parse(Console.ReadLine());


            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == someChar)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{someChar} does not occur in the matrix");
        }
    }
}
