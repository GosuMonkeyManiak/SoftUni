namespace GeneratingVectorsZeroOne
{
    using System;

    public class Program
    {
        public static void Generate(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join("", arr));
                return;
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    arr[index] = i;
                    Generate(arr, index + 1);
                }
            }
        }

        public static void Main()
        {
            int numberOfBits = int.Parse(Console.ReadLine());

            int[] bits = new int[numberOfBits];

            Generate(bits, 0);
        }
    }
}

