using System;
using System.Collections.Generic;
using System.Linq;

namespace Messaging
{
    class Messaging
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string str = Console.ReadLine();

            string result = "";

            List<char> chars = str.ToCharArray().ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];

                int sumOfDigits = 0;

                while (currentNumber > 0)
                {
                    sumOfDigits += currentNumber % 10;
                    currentNumber /= 10;
                }

                if (sumOfDigits > str.Length - 1)
                {
                    int timeBiggers = sumOfDigits / str.Length;
                    sumOfDigits -= timeBiggers * str.Length;

                    result += chars[sumOfDigits];
                    chars.RemoveAt(sumOfDigits);
                    
                }
                else
                { 
                    result += chars[sumOfDigits];
                    chars.RemoveAt(sumOfDigits);
                }
            }

            Console.WriteLine(result);
        }
    }
}
