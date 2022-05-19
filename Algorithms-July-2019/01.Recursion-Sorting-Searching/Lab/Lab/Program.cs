namespace RecursiveArraySum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static int Sum(int[] arr, int index)
        {
            if (index == arr.Length - 1)
            {
                return arr[index];
            }

            int sum = arr[index] + Sum(arr, index + 1);

            return sum;
        }

        public static void Main()
        {
            int[] elements = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int sum = Sum(elements, 0);

            Console.WriteLine(sum);
        }
    }
}
