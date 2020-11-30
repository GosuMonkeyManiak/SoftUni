using System;

namespace SpecialsNumbers
{
    class SpecialsNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1111; i < 9999; i++)
            {
                int num = i;
                int fourthDigit = num % 10;
                num /= 10;
                int thirdDigit = num % 10;
                num /= 10;
                int secondDigit = num % 10;
                num /= 10;
                int firstDigit = num % 10;

                if (fourthDigit == 0 || thirdDigit == 0 || secondDigit == 0)
                {
                    continue;
                }

                if (n % fourthDigit == 0 && n % thirdDigit == 0 && n % secondDigit == 0 && n % firstDigit == 0)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
