using System;

namespace Matrix
{
    class Matrix
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Matrixs(number);
        }

        static void Matrixs(int number)
        {
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
