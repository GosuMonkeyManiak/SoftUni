using System;

namespace NumberToOneHundredLikeText
{
    class NumberToOneHundredLikeText
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string firstDigit = "";
            string secondDigit = "";

            if (number < 10)
            {
                if (number == 0)
                {
                    firstDigit = "zero";
                }
                else if (number == 1)
                {
                    firstDigit = "one";
                }
                else if (number == 2)
                {
                    firstDigit = "two";
                }
                else if (number == 3)
                {
                    firstDigit = "three";
                }
                else if (number == 4)
                {
                    firstDigit = "four";
                }
                else if (number == 5)
                {
                    firstDigit = "five";
                }
                else if (number == 6)
                {
                    firstDigit = "six";
                }
                else if (number == 7)
                {
                    firstDigit = "seven";
                }
                else if (number == 8)
                {
                    firstDigit = "eighth";
                }
                else
                {
                    firstDigit = "nine";
                }

                Console.WriteLine(firstDigit);
            }
            else if (number < 20)
            {
                int lastDigit = number % 10;

                if (lastDigit == 1)
                {
                    Console.WriteLine("eleven");
                }
                else if (lastDigit == 2)
                {
                    Console.WriteLine("twelve");
                }
                else if (lastDigit == 3)
                {
                    Console.WriteLine("thirteen");
                }
                else if (lastDigit == 4)
                {
                    Console.WriteLine("fourteen");
                }
                else if (lastDigit == 5)
                {
                    Console.WriteLine("fifteen");
                }
                else if (lastDigit == 6)
                {
                    Console.WriteLine("sixteen");
                }
                else if (lastDigit == 7)
                {
                    Console.WriteLine("seventeen");
                }
                else if (lastDigit == 8)
                {
                    Console.WriteLine("eighteen");
                }
                else
                {
                    Console.WriteLine("nineteen");
                }
            }
            else if (number < 100)
            {
                bool flag = false;
                int lastDigit = number % 10;
                number /= 10;

                //last Digit
                if (lastDigit == 0)
                {
                    secondDigit = "";
                    flag = true;
                }
                else if (lastDigit == 1)
                {
                    secondDigit = "one";
                }
                else if (lastDigit == 2)
                {
                    secondDigit = "two";
                }
                else if (lastDigit == 3)
                {
                    secondDigit = "three";
                }
                else if (lastDigit == 4)
                {
                    secondDigit = "four";
                }
                else if (lastDigit == 5)
                {
                    secondDigit = "five";
                }
                else if (lastDigit == 6)
                {
                    secondDigit = "six";
                }
                else if (lastDigit == 7)
                {
                    secondDigit = "seven";
                }
                else if (lastDigit == 8)
                {
                    secondDigit = "eighth";
                }
                else
                {
                    secondDigit = "nine";
                }

                //firstDigit
                if (number == 1)
                {
                    firstDigit = "ten";
                }
                else if (number == 2)
                {
                    firstDigit = "twenty";
                }
                else if (number == 3)
                {
                    firstDigit = "thirty";
                }
                else if (number == 4)
                {
                    firstDigit = "forty";
                }
                else if (number == 5)
                {
                    firstDigit = "fifty";
                }
                else if (number == 6)
                {
                    firstDigit = "sixty";
                }
                else if (number == 7)
                {
                    firstDigit = "seventy";
                }
                else if (number == 8)
                {
                    firstDigit = "eighty";
                }
                else
                {
                    firstDigit = "ninety";
                }

                if (flag)
                {
                    Console.WriteLine($"{firstDigit}");
                }
                else
                {
                    Console.WriteLine($"{firstDigit} {secondDigit}");
                }
            }
            else
            {
                Console.WriteLine("one hundred");
            }
        }
    }
}
