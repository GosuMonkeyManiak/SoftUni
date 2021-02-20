using System;

namespace SelectionSort
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = { 4, 5, 3, 2, 4, 1 };

            numbers = StableSelectionSort(numbers);

            Console.WriteLine(string.Join(" ", numbers));

            string[] text = { "paper", "true", "soap", "floppy", "flower" };

            text = SelectionSortStrings(text);

            Console.WriteLine(string.Join(" ", text));
        }

        static int[] SelectionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int minElementIndex = i;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[minElementIndex] > numbers[j])
                    {
                        minElementIndex = j;
                    }
                }

                if (minElementIndex != i)
                {
                    int element = numbers[i];
                    numbers[i] = numbers[minElementIndex];
                    numbers[minElementIndex] = element;
                }
            }

            return numbers;
        } //sort numbers

        static string[] SelectionSortStrings(string[] text)
        {
            for (int i = 0; i < text.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < text.Length; j++)
                {
                    if (text[minIndex].CompareTo(text[j]) > 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    string temp = text[i];
                    text[i] = text[minIndex];
                    text[minIndex] = temp;
                }
            }

            return text;
        } //sort text

        static int[] StableSelectionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[minIndex] > numbers[j])
                    {
                        minIndex = j;
                    }
                }

                int key = numbers[minIndex];

                while (minIndex > i)
                {
                    numbers[minIndex] = numbers[minIndex - 1];
                    minIndex--;
                }

                numbers[i] = key;
            }

            return numbers;
        }
    }
}
