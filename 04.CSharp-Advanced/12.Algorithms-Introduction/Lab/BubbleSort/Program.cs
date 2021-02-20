using System;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 65, 25, 10, 2, 2, 4, 5 };

            numbers = OptimazedBubbleSort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

        static int[] BubbleSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - 1 - i; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }

            return numbers;
        } //stable

        static int[] OptimazedBubbleSort(int[] numbers)
        {
            bool swapped;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < numbers.Length - 1 - i; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }

            return numbers;
        } //stable
    }
}
