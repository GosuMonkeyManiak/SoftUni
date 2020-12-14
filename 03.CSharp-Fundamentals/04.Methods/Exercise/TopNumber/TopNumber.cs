using System;

namespace TopNumber
{
    class TopNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                bool result = SumOfDigitDibisibleByEigth(i) && IsHoldOneOddDigit(i);

                if (result)
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool SumOfDigitDibisibleByEigth(int number)
        {
            int sumOfDigits = 0;

            while (number > 0 )
            {
                sumOfDigits += number % 10;
                number /= 10;
            }

            if (sumOfDigits % 8 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool IsHoldOneOddDigit(int number)
        {
            int countOddDigits = 0;

            while (number > 0)
            {
                if ((number % 10) % 2 != 0)
                {
                    countOddDigits++;
                }

                number /= 10;
            }

            if (countOddDigits >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
