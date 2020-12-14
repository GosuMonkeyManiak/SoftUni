using System;

namespace EncryptSortAndPrint
{
    class EncryptSortAndPrint
    {
        static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());

            int[] result = new int[numberOfStrings];

            for (int i = 0; i < numberOfStrings; i++)
            {
                string sequence = Console.ReadLine();

                int currentSum = 0;

                for (int j = 0; j < sequence.Length; j++)
                {
                    char currentChar = sequence[j];

                    switch (currentChar)
                    {
                        case 'a':
                        case 'A':
                        case 'e':
                        case 'E':
                        case 'i':
                        case 'I':
                        case 'o':
                        case 'O':
                        case 'u':
                        case 'U':
                            currentSum += (int)(currentChar * sequence.Length);
                            break;
                        default:
                            currentSum += (int)(currentChar / sequence.Length);
                            break;
                    }
                }

                result[i] = currentSum;
            }

            Array.Sort(result);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
