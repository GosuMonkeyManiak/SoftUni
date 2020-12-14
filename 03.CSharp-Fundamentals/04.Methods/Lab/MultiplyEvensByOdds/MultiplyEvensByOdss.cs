using System;

namespace MultiplyEvensByOdds
{
    class MultiplyEvensByOdss
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int evenDigits = GetSumOfEvenDigits(number);
            int oddDigits = GetSumOfOddDigits(number);
            int result = GetMultipleOfEvenAndOdds(evenDigits, oddDigits);

            Console.WriteLine(result);
        }

        public static int GetSumOfEvenDigits(int number)
        {
            number = Math.Abs(number);

            int sumOfDigits = 0;

            while (number > 0)
            {
                if ((number % 10) % 2 == 0)
                {
                    sumOfDigits += number % 10;
                }
                number /= 10;
            }

            return sumOfDigits;
        }

        public static int GetSumOfOddDigits(int number)
        {
            number = Math.Abs(number);

            int sumOfOddDigits = 0;

            while (number > 0)
            {
                if ((number % 10) % 2 != 0)
                {
                    sumOfOddDigits += number % 10;
                }
                number /= 10;
            }

            return sumOfOddDigits;
        }

        public static int GetMultipleOfEvenAndOdds(int evenDigits, int oddDigits)
        {
            return evenDigits * oddDigits;
        }
    }
}
