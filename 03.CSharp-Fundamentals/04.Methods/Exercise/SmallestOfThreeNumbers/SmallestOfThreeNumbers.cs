using System;

namespace SmallestOfThreeNumbers
{
    class SmallestOfThreeNumbers
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int result = SmallestNumber(firstNumber, secondNumber, thirdNumber);

            Console.WriteLine(result);
        }

        public static int SmallestNumber(int firstNum, int secondNum, int thirdNum)
        {
            if (firstNum < secondNum && firstNum < thirdNum)
            {
                return firstNum;
            }
            else if (secondNum < firstNum && secondNum < thirdNum)
            {
                return secondNum;
            }
            else
            {
                return thirdNum;
            }
        }
    }
}
