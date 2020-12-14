using System;

namespace PalinDromeIntegers
{
    class PalinDromeIntegers
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string number = Console.ReadLine();
                if (number == "END")
                {
                    break;
                }

                Palidrome(number);
            }
        }

        static void Palidrome(string number)
        {
            bool isPalidrome = true;

            for (int i = 0; i < number.Length / 2; i++)
            {
                if (number[i] != number[number.Length - i - 1])
                {
                    isPalidrome = false;
                    break;
                }
            }

            if (isPalidrome)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
