using System;
using System.Linq;
using System.Numerics;

namespace JaggedArrayManipulator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            decimal[][] jaggedArray = new decimal[rows][];

            for (int row = 0; row < rows; row++)
            {
                decimal[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(decimal.Parse)
                    .ToArray();

                jaggedArray[row] = new decimal[elements.Length];

                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    jaggedArray[row][col] = elements[col];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    Multiply(jaggedArray[row]);
                    Multiply(jaggedArray[row + 1]);
                }
                else
                {
                    Divide(jaggedArray[row]);
                    Divide(jaggedArray[row + 1]);
                }
            }

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length > 0)
                {
                    if (tokens[0] == "End")
                    {
                        break;
                    }
                }

                if (tokens.Length == 4)
                {
                    string command = tokens[0];
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    decimal value = decimal.Parse(tokens[3]);

                    bool isValid = (row >= 0 && row < jaggedArray.Length) &&
                                   (col >= 0 && col < jaggedArray[row].Length);
                    if (!isValid)
                    {
                        continue;
                    }

                    if (command == "Add")
                    {
                        jaggedArray[row][col] += value;
                    }
                    else if (command == "Subtract")
                    {
                        jaggedArray[row][col] -= value;
                    }

                }

            }

            Print(jaggedArray);

        }

        static void Multiply(decimal[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i] * 2;
            }
        }

        static void Divide(decimal[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i] / 2;
            }
        }

        static void Print(decimal[][] array)
        {
            for (int row = 0; row < array.Length; row++)
            {
                for (int col = 0; col < array[row].Length; col++)
                {
                    Console.Write(array[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
