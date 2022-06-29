namespace Generating01Vectors
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] vector = new int[n];

            GenerateVector(vector, 0);
        }

        public static void GenerateVector(int[] vector, int idx)
        {
            if (idx == vector.Length)
            {
                Console.WriteLine(string.Join(string.Empty, vector));
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                vector[idx] = i;

                GenerateVector(vector, idx + 1);
            }
        }
    }
}