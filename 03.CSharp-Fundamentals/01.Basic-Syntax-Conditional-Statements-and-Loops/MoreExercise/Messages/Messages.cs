using System;

namespace Messages
{
    class Messages
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            string result = "";

            int digitLength = 0;
            int mainDigit = 0;
            int offSet = 0;

            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber == 0)
                {
                    result += " ";
                    continue;
                }

                int temp = currentNumber;

                while (temp > 0)
                {
                    temp /= 10;
                    digitLength++;
                }

                mainDigit = currentNumber % 10;
                offSet = (mainDigit - 2) * 3;

                if (mainDigit == 8 || mainDigit == 9)
                {
                    offSet++;
                }

                int letterIndex = (offSet + digitLength - 1);

                result += alphabet[letterIndex].ToString();

                digitLength = 0;

            }

            Console.WriteLine(result);
        }
    }
}
